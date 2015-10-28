using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Linq;
using System.Xml;
using System.Collections;
using ketoansoft.app.Class.Global;
using Microsoft.Win32;

namespace ketoansoft.app
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        #region Data
        private bool Load_Server()
        {
            try
            {
                string lenh = "SELECT CONVERT(sysname, SERVERPROPERTY('servername'))";
                DataTable dt = new DataTable();
                dt = Class.Data.XLDLRepo.ReadData(lenh);
                if (dt.Rows.Count > 0)
                {
                    txtNameServer.Text = dt.Rows[0][0].ToString();
                }
                return true;
            }
            catch { lblMsg.Text = "Lỗi kết nối! Hãy tắt và mở lại chương trình"; return false; }
        }
        private bool Load_Database()
        {
            try
            {
                if (txtNameServer.Text != "")
                {
                    cboNameDatabase.Text = "";
                    cboNameDatabase.Items.Clear();
                    //using (var con = new SqlConnection("Data Source=" + txtNameServer.Text + "; Integrated Security=True;"))
                    using (var con = new SqlConnection("Data Source=" + txtNameServer.Text + ";Persist Security Info=True;User ID=" + txtUser.Text + ";Password=" + txtPassword.Text + ""))
                    {
                        con.Open();
                        DataTable databases = con.GetSchema("Databases");
                        if (databases != null)
                        {
                            foreach (DataRow database in databases.Rows)
                            {
                                String databaseName = database.Field<String>("database_name");
                                short dbID = database.Field<short>("dbid");
                                if (databaseName != "master" && databaseName != "tempdb" && databaseName != "model" && databaseName != "msdb")
                                    cboNameDatabase.Items.Add(databaseName);
                            }
                        }
                        con.Close();
                    }
                }
                return true;
            }
            catch { return false; }
        }
        private bool Logon(string ServerName, string DatabaseName, string UserName, string Password)
        {
            try
            {
                string connectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";Persist Security Info=True;User ID=" + UserName + ";Password=" + Password + "";
                var con = new SqlConnection(connectionString);
                con.Open();
                //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //config.ConnectionStrings.ConnectionStrings["ketoansoft.app.Properties.Settings.dbConnectionString"].ConnectionString = connectionString;
                //config.Save(ConfigurationSaveMode.Modified, true);
                //ConfigurationManager.RefreshSection("connectionStrings");
                
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ketoansoft.app.Properties.Settings.dbConnectionString"];
                SqlConnectionStringBuilder builder;
                dbVstoreAppDataContext db;

                if (null != settings)
                {
                    string connection = settings.ConnectionString;
                    builder = new SqlConnectionStringBuilder(connection);
                    // passwordTextBox being the control where joe the user actually enters his credentials
                    builder.DataSource = ServerName;
                    builder.InitialCatalog = DatabaseName;
                    builder.UserID = UserName;
                    builder.Password = Password;
                    db = new dbVstoreAppDataContext(builder.ConnectionString);
                    Const.builder = builder;
                    Const.ConnectionString = connectionString;
                    return true;
                }
               
                return false;
            }
            catch { return false; }
        }
        private void ReadXML()
        {
            try
            {
                ArrayList Arr = new ArrayList();
                Arr = Unit.ReadDatabaseXML();
                string ServerName = Arr[0].ToString();
                string DatabaseName = Arr[1].ToString();
                string UserName = Arr[2].ToString();
                string Password = Arr[3].ToString();
                if (Logon(ServerName, DatabaseName, UserName, Password))
                {
                    this.Hide();
                    fTerm _form = new fTerm();
                    _form.ShowDialog();
                    this.Close();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        private bool CheckActivate()
        {
            try
            {
                ArrayList Arr = new ArrayList();
                Arr = Unit.ReadActivateXML();
                string Appcode = Arr[0].ToString();
                string HardwareID = HardwareInfo.GetHDDSerialNo();
                string keyValue = Security.Encrypt(HardwareID, Appcode);
                try
                {
                    RegistryKey RegMachine = Registry.LocalMachine;
                    RegistryKey RegSoftware = RegMachine.OpenSubKey("Software", true);
                    if (RegSoftware != null)
                    {
                        RegistryKey RegMine = RegSoftware.OpenSubKey("Ketoan", true);
                        if (RegMine != null)
                        {
                            String Tmp = "";
                            try
                            {
                                Tmp = RegMine.GetValue("KetoanKey").ToString();
                            }
                            catch
                            {
                                btnLogon.Enabled = false;
                                btnListData.Enabled = false;
                                btnSearchDatabase.Enabled = false;
                                MessageBox.Show("You must activate ketoan key...", "Ketoan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RegMine.Close();
                                RegMachine.Close();
                                RegSoftware.Close();
                                return false;
                            }
                            if (Tmp != "")
                            {
                                if (Tmp != keyValue)
                                {
                                    btnLogon.Enabled = false;
                                    btnListData.Enabled = false;
                                    btnSearchDatabase.Enabled = false;
                                    MessageBox.Show("Read ketoan key is validation. You should activate again!", "Activate");
                                    RegMine.Close();
                                    RegMachine.Close();
                                    RegSoftware.Close();
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("You must activate ketoan key...", "Ketoan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnLogon.Enabled = false;
                                btnListData.Enabled = false;
                                btnSearchDatabase.Enabled = false;
                                return false;
                            }
                            RegMine.Close();
                        }
                        else
                        {
                            MessageBox.Show("You must activate ketoan key...", "Ketoan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLogon.Enabled = false;
                            btnListData.Enabled = false;
                            btnSearchDatabase.Enabled = false;
                            return false;
                        }
                        RegSoftware.Close();
                    }
                    RegMachine.Close();
                }
                catch
                {
                    MessageBox.Show("You must activate ketoan key...", "Ketoan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLogon.Enabled = false;
                    btnListData.Enabled = false;
                    btnSearchDatabase.Enabled = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); btnLogon.Enabled = false;
                btnSearchDatabase.Enabled = false;
                btnListData.Enabled = false; return false;
            }
            return false;
        }
        #endregion

        #region Event
        private void fLogin_Load(object sender, EventArgs e)
        {
            //if (!CheckActivate()) return;
            if(!Const.ISCHANGEDATABASE)
                ReadXML();
            Load_Server();
        }
        private void cboNameServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Database();
        }
        private void btnLogon_Click(object sender, EventArgs e)
        {
            if (Logon(txtNameServer.Text, cboNameDatabase.Text, txtUser.Text, txtPassword.Text))
            {
                this.Hide();
                Unit.WriteDatabaseXML(txtNameServer.Text, cboNameDatabase.Text, txtUser.Text, txtPassword.Text);
                fTerm _form = new fTerm();
                _form.ShowDialog();
                this.Close();
            }
            else {
                MessageBox.Show("Tài khoản và mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnListData_Click(object sender, EventArgs e)
        {
            if (Load_Database())
                MessageBox.Show("Đã lấy danh sách database!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Tài khoản và mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnSearchDatabase_Click(object sender, EventArgs e)
        {
            Load_Server();
        }
        #endregion
    }
}
