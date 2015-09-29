using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Activate
{
    public partial class frmActivate : Form
    {
        private RegistryKey RegMachine, RegSoftware, RegMine;
        public frmActivate()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGetHardwareID_Click(object sender, EventArgs e)
        {
            txtHardwareID.Text = HardwareInfo.GetHDDSerialNo();
        }
        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (txtKhachhang.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập tên khách hàng!", "Thông báo");
                return;
            } 
            if (txtAppcode.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập Appcode!", "Thông báo");
                return;
            } 
            if (txtHardwareID.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập hardware ID!", "Thông báo");
                return;
            }
            int ID = 0;
            DataTable dtCustomer = XLDLRepo.ReadData("Select * from dbo.Customer where Appcode ='" + txtAppcode.Text + "'");
            if (dtCustomer != null && dtCustomer.Rows.Count > 0)
            {
                DataRow row = dtCustomer.Rows[0];
                ID = Utils.CIntDef(row["ID"], 0);
                bool IsActive = Utils.CBoolDef(row["IsActive"], false);
                int Appnumber = Utils.CIntDef(row["Appnumber"], 0);
                if (!IsActive)
                {
                    MessageBox.Show("Khách hàng có appcode " + txtAppcode.Text + " chưa được kích hoạt!", "Thông báo");
                    return;
                }
                int count = 0;
                DataTable dtCustomerSetup = XLDLRepo.ReadData("Select * from dbo.CustomerSetup where CustomerID =" + ID + "");
                if (dtCustomerSetup != null && dtCustomerSetup.Rows.Count > 0)
                {
                    count = dtCustomerSetup.Rows.Count;
                }
                if (Appnumber <= count)
                {
                    MessageBox.Show("Số máy cài đặt vượt mức cho phép!", "Thông báo");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Appcode không hợp lệ!", "Thông báo");
                return;
            }
            try
            {
                string keyValue = Security.Encrypt(txtHardwareID.Text, txtAppcode.Text);
                RegMachine = Registry.LocalMachine;
                RegSoftware = RegMachine.OpenSubKey("Software", true);
                if (RegMachine == null) return;
                if (RegSoftware != null)
                {
                    if (RegSoftware.OpenSubKey("Ketoan") != null)
                    {
                        RegSoftware.DeleteSubKeyTree("Ketoan");
                    }
                    RegSoftware.CreateSubKey("Ketoan");
                    RegMine = RegSoftware.OpenSubKey("Ketoan", true);
                    if (RegMine != null)
                    {
                        RegMine.SetValue("KetoanKey", keyValue);
                        RegMine.Close();
                    }
                    RegSoftware.Close();
                    MessageBox.Show("You activated ketoan key successfull...", "Ketoan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable dtCustomerSetup = XLDLRepo.ReadData("Select * from dbo.CustomerSetup where CustomerID =" + ID + " and HddSeriID = '" + txtHardwareID.Text + "'");
                    if (dtCustomerSetup != null && dtCustomerSetup.Rows.Count > 0)
                    {
                        XLDLRepo.DataCommand("UPDATE dbo.CustomerSetup SET [Fullname] = '" + txtKhachhang.Text + "' WHERE CustomerID=" + ID + " and HddSeriID = '" + txtHardwareID.Text + "'");
                    }
                    else
                    {
                        XLDLRepo.DataCommand("Insert into dbo.CustomerSetup(Fullname, HddSeriID, CustomerID, CreatedDate) values('" + txtKhachhang.Text + "','" + txtHardwareID.Text + "'," + ID + ",'" + DateTime.Now + "')");
                    }
                }
                RegMachine.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("Error activated ketoan key..." + E.Source.ToString(), "Ketoan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
