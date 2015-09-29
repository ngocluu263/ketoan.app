using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ketoansoft.app.Class.Data;
using System.Collections;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app
{
    public partial class TaoDatabaseMoi : Form
    {
        private string dataSqlPath = "";
        public TaoDatabaseMoi()
        {
            InitializeComponent();
        }

        private void TaoDatabaseMoi_Load(object sender, EventArgs e)
        {
            btnOk.Enabled = true;
            dataSqlPath = Application.StartupPath + "\\DATASQL\\";
            txtThumucluu.Text = dataSqlPath;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtTenDatabase.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa nhập tên database!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string DatabaseName = txtTenDatabase.Text;
            string fileBak = dataSqlPath + "SQLDefault.bak";
            string dataFilePath = dataSqlPath + DatabaseName + ".mdf";
            string logFilePath = dataSqlPath + DatabaseName + "_log.ldf";
            string s = "";
            s += "RESTORE DATABASE " + DatabaseName;
            s += " FROM DISK=N'" + fileBak + "'";
            s += " WITH";
            s += "  FILE=1,";
            s += "    MOVE 'db_ketoan' TO '" + dataFilePath + "',";
            s += "    MOVE 'db_ketoan_log' TO '" + logFilePath + "'";
            s += " ALTER DATABASE " + DatabaseName;
            s += "              MODIFY FILE (NAME='db_ketoan', NEWNAME='" + DatabaseName + "');";
            s += " ALTER DATABASE " + DatabaseName;
            s += "              MODIFY FILE (NAME='db_ketoan_log', NEWNAME='" + DatabaseName + "_log');";
            XLDLRepo.DataCommand(s);
            txtTenDatabase.Text = "";
            MessageBox.Show("Tạo database mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
