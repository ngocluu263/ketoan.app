using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ketoansoft.app.Class.Data;
using ketoansoft.app.Components.clsVproUtility;

namespace ketoansoft.app.UIs
{
    public partial class ThemSoCongNoTheoTungHoaDon : Form
    {
        private KTTKRepo _KTTKRepo = new KTTKRepo();
        private KTDTPNRepo _KTDTPNRepo = new KTDTPNRepo();
        private KTCNHoaDonRepo _KTCNHoaDonRepo = new KTCNHoaDonRepo();
        private List<KT_CNHoaDon> _listCNHoaDon = new List<KT_CNHoaDon>();
        public ThemSoCongNoTheoTungHoaDon()
        {
            InitializeComponent();
        }
        private void ThemSoCongNoTheoTungHoaDon_Load(object sender, EventArgs e)
        {
            LoadTK();
            LoadDTPNNo();
        }

        #region load cbo
        private void LoadGrid()
        {
            gridData.DataSource = null;
            gridData.DataSource = _listCNHoaDon;
            gridData.RefreshDataSource();
            gridView1.RefreshData();
        }
        private void LoadTK()
        {
            _KTTKRepo = new KTTKRepo();
            List<string> list = new List<string>() { "131", "136", "141", "331", "336" };
            cboTaikhoan.DataSource = _KTTKRepo.GetByListMaTK(list);
            cboTaikhoan.DisplayMember = "MA_TK";
            cboTaikhoan.ValueMember = "ID";
            cboTaikhoan.DropDownColumns = "MA_TK,TEN_TK";
            cboTaikhoan.SelectedIndex = -1;
        }
        private void cboTaikhoan_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_TK")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        private void LoadDTPNNo()
        {
            _KTDTPNRepo = new KTDTPNRepo();
            cboMaDT.DataSource = _KTDTPNRepo.GetAll();
            cboMaDT.DisplayMember = "MA_DTPN";
            cboMaDT.ValueMember = "ID";
            cboMaDT.DropDownColumns = "MA_DTPN,TEN_DTPN";
            cboMaDT.SelectedIndex = -1;
        }
        private void cboMaDT_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_DTPN")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        #endregion

        #region cbo change
        private void cboTaikhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            _KTTKRepo = new KTTKRepo();
            var item = _KTTKRepo.GetById(Utils.CIntDef(cboTaikhoan.SelectedValue, 0));
            if (item != null)
                txtTenTaikhoan.Text = item.TEN_TK; 
        }
        private void cboMaDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            _KTDTPNRepo = new KTDTPNRepo();
            var item = _KTDTPNRepo.GetById(Utils.CIntDef(cboMaDT.SelectedValue, 0));
            if (item != null)
                txtTenDT.Text = item.TEN_DTPN;
        }
        #endregion

        #region text changed
        private void txtDuNoVnd_TextChanged(object sender, EventArgs e)
        {
            txtDuNoVnd.Text = string.Format("{0:#,#}", Utils.CDecDef(txtDuNoVnd.Text, 0));
            txtDuNoVnd.SelectionStart = txtDuNoVnd.Text.Length;
        }
        private void txtDuNoUsd_TextChanged(object sender, EventArgs e)
        {
            txtDuNoUsd.Text = string.Format("{0:#,#}", Utils.CDecDef(txtDuNoUsd.Text, 0));
            txtDuNoUsd.SelectionStart = txtDuNoUsd.Text.Length;
        }
        private void txtDuCoVnd_TextChanged(object sender, EventArgs e)
        {
            txtDuCoVnd.Text = string.Format("{0:#,#}", Utils.CDecDef(txtDuCoVnd.Text, 0));
            txtDuCoVnd.SelectionStart = txtDuCoVnd.Text.Length;
        }
        private void txtDuCoUsd_TextChanged(object sender, EventArgs e)
        {
            txtDuCoUsd.Text = string.Format("{0:#,#}", Utils.CDecDef(txtDuCoUsd.Text, 0));
            txtDuCoUsd.SelectionStart = txtDuCoUsd.Text.Length;
        }
        #endregion

        #region button click
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnTiep_Click(object sender, EventArgs e)
        {
            if (cboTaikhoan.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn Tài khoản!", "Thông báo");
                return;
            }
            if (cboMaDT.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn mã ĐT!", "Thông báo");
                return;
            }
            if (txtSoHoaDon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa nhập số hóa đơn!", "Thông báo");
                return;
            }
            KT_CNHoaDon CNHoaDon = new KT_CNHoaDon();
            CNHoaDon.MA_TK = cboTaikhoan.Text;
            CNHoaDon.MA_DTPN = cboMaDT.Text;
            CNHoaDon.TEN_DTPN = txtTenDT.Text;
            CNHoaDon.SO_HOADON = txtSoHoaDon.Text;
            CNHoaDon.SR_HOADON = txtSeriHD.Text;
            DateTime? temp = null;
            if (Utils.CDateDef(dtpNgayHD.Value, DateTime.MinValue) != DateTime.MinValue)
                temp = Utils.CDateDef(dtpNgayHD.Value, DateTime.MinValue);
            CNHoaDon.NGAY_HOADON = temp;
            temp = null;
            if (Utils.CDateDef(dtpNgaydaohan.Value, DateTime.MinValue) != DateTime.MinValue)
                temp = Utils.CDateDef(dtpNgaydaohan.Value, DateTime.MinValue);
            CNHoaDon.NGAY_DH = temp;
            CNHoaDon.DUNO_VND = Utils.CDblDef(txtDuNoVnd.Text.Replace(",", ""), 0);
            CNHoaDon.DUNO_USD = Utils.CDblDef(txtDuNoUsd.Text.Replace(",", ""), 0);
            CNHoaDon.DUCO_VND = Utils.CDblDef(txtDuCoVnd.Text.Replace(",", ""), 0);
            CNHoaDon.DUCO_USD = Utils.CDblDef(txtDuCoUsd.Text.Replace(",", ""), 0);
            
            _listCNHoaDon.Add(CNHoaDon);

            LoadGrid();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_listCNHoaDon != null && _listCNHoaDon.Count > 0)
            {
                _KTCNHoaDonRepo = new KTCNHoaDonRepo();
                _KTCNHoaDonRepo.Create(_listCNHoaDon);

                MessageBox.Show("Lưu thành công", "Thông báo");
                //_KTCNHoaDonRepo = new KTCNHoaDonRepo();
                //LoadGrid();
                this.Close();
            }
        }
        #endregion

    }
}
