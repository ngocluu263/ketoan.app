using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ketoansoft.app.Class.Data;
using ketoansoft.app.Components.clsVproUtility;

namespace ketoansoft.app.UIs
{
    public partial class ThemDoiTuongPhapNhan : DevComponents.DotNetBar.Metro.MetroForm
    {
        private KTDTPNRepo _KTDTPNRepo = new KTDTPNRepo();
        private KTNHOMHHRepo _KTNHOMHHRepo = new KTNHOMHHRepo();
        public ThemDoiTuongPhapNhan()
        {
            InitializeComponent();
        }

        #region Funtion
        private bool Check_Empt()
        {
            if (txtMaDT.Text == "")
                errorProvider1.SetError(txtMaDT, "Mã đối tượng không được trống!");
            else if(txtTenDT.Text == "")
                errorProvider1.SetError(txtTenDT, "Tên đối tượng không được trống!");
            else
                return true;
            return false;
        }
        #endregion

        #region Data
        private void LoadDMNhom()
        {
            _KTNHOMHHRepo = new KTNHOMHHRepo();
            cboMaNhom.DataSource = _KTNHOMHHRepo.GetAll();
            cboMaNhom.DisplayMember = "MA_NHOM";
            cboMaNhom.ValueMember = "ID";
            cboMaNhom.DropDownColumns = "MA_NHOM,TEN_NHOM";
            cboMaNhom.SelectedIndex = -1;
        }
        private bool SaveData()
        {
            try
            {
                KT_DTPN obj = new KT_DTPN();
                obj.MA_DTPN = txtMaDT.Text;
                obj.TEN_DTPN = txtTenDT.Text;
                obj.MA_SO_THUE = txtMST.Text;
                obj.DIA_CHI = txtDiaChi.Text;
                obj.DIEN_THOAI = txtDienThoai.Text;
                if (chkInfo.Checked)
                {
                    obj.TK_NH = txtSoTKNganHang.Text;
                    obj.TEN_TKNH = txtTenTKNganHang.Text;
                    obj.MA_TT = txtMaNVTiepThi.Text;
                    obj.TEN_TT = txtTenNVTiepThi.Text;
                    obj.DIA_CHI_GH = txtDiaChiGiaoHang.Text;
                    obj.LIEN_HE = txtLienHe.Text;
                    obj.MA_NHOM = cboMaNhom.Text;
                    obj.TEN_NHOM = txtTenNhom.Text;
                    obj.CK_PT = Utils.CDblDef(txtChietKhau, 0);
                }
                _KTDTPNRepo.Create(obj);
                return true;
            }
            catch { return false; }
        }
        #endregion

        #region Event

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Check_Empt())
            {
                if (SaveData())
                {
                    MessageBox.Show("Đã cập nhật thành công!", "Thông báo");
                    this.Close();
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void chkInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInfo.Checked)
            {
                groupBox1.Enabled = true;
                LoadDMNhom();
            }
            else groupBox1.Enabled = false;
        }
        private void txtChietKhau_TextChanged(object sender, EventArgs e)
        {
            txtChietKhau.Text = string.Format("{0:#,#}", Utils.CDecDef(txtChietKhau.Text, 0));
            txtChietKhau.SelectionStart = txtChietKhau.Text.Length;
        }
        private void cboMaNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNhom.Text != "" && cboMaNhom.Text != null)
            {
                _KTNHOMHHRepo = new KTNHOMHHRepo();
                var item = _KTNHOMHHRepo.GetById(Utils.CIntDef(cboMaNhom.SelectedValue, 0));
                if (item != null)
                    txtTenNhom.Text = item.TEN_NHOM;
            }
        }
        #endregion
    }
}