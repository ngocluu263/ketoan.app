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
using ketoansoft.app.Class.Global;
using System.Globalization;

namespace ketoansoft.app.UIs
{
    public partial class XemVaSuaChungTuGoc : Form
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTLCTGRepo _KTLCTGRepo = new KTLCTGRepo();
        private KT_CTuGocRepo _KT_CTuGocRepo = new KT_CTuGocRepo();
        public XemVaSuaChungTuGoc()
        {
            InitializeComponent();
        }
        private void XemVaSuaChungTuGoc_Load(object sender, EventArgs e)
        {
            LoadLoaiChungTu();
            LoadSoChungTu();
            cboThang.Text = fTerm._month;
            btnXemtonghop_Click(null, null);
        }

        private void getInfo()
        {
            _KT_CTuGocRepo = new KT_CTuGocRepo();
            int id = Utils.CIntDef(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID"), 0);
            KT_CTuGoc obj = _KT_CTuGocRepo.GetById(id);
            if (obj != null)
            {
                txtLoai.Text = obj.MA_CTU;
                txtSo.Text = obj.SO_CTU;
                txtNgay.Text = "";
                if (obj.NGAY_CTU != null)
                    txtNgay.Text = obj.NGAY_CTU.Value.ToString("dd/MM/yyyy");
                txtDiengiai.Text = obj.DIEN_GIAI;
                txtTenKH.Text = obj.TEN_KH;
                txtSoHD.Text = obj.HD_SO;
                txtNgayHD.Text = "";
                if (obj.HD_NGAY != null)
                txtNgayHD.Text = obj.HD_NGAY.Value.ToString("dd/MM/yyyy");
                txtSeriHD.Text = obj.HD_SR;

                //txtUsdTienHang.Text = string.Format("", o
                txtUsdChietkhau.Text = string.Format("{0:#,###}", obj.CHIET_KHAU_USD);
                txtUsdTienthue.Text = string.Format("{0:#,###}", obj.TIEN_THUE_USD);
                txtUsdTongtien.Text = string.Format("{0:#,###}", obj.TONG_TIEN_USD);

                txtVndTienhang.Text = string.Format("{0:#,###}", obj.TIEN_HANG);
                //txtVndChietkhau1.Text = string.Format("{0:#,###}", obj.CHIET_KHAU_VND);
                txtVndChietkhau2.Text = string.Format("{0:#,###}", obj.CHIET_KHAU_VND);
                //txtVndTienthue1.Text = string.Format("{0:#,###}", obj.TIEN_THUE_VND);
                txtVndTienthue2.Text = string.Format("{0:#,###}", obj.TIEN_THUE_VND);
                txtVndTongtien.Text = string.Format("{0:#,###}", obj.TONG_TIEN_VND);
            }
        }

        #region Load cbo
        private void LoadLoaiChungTu()
        {
            _KTLCTGRepo = new KTLCTGRepo();
            var list = _KTLCTGRepo.GetAll();
            cboLoaichungtu.DataSource = list;
            cboLoaichungtu.DisplayMember = "ID_LOAI";
            cboLoaichungtu.ValueMember = "ID_LOAI";
            cboLoaichungtu.DropDownColumns = "ID_LOAI,TEN_CT,SO_CT";
            cboLoaichungtu.SelectedIndex = -1;
        }
        private void cboLoaichungtu_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "TEN_CT")
            {
                header.Width.Relative = 50; // 20% of available width
            }
            else { header.Width.Relative = 25; }
        }
        private void LoadSoChungTu()
        {
            var list = _db.KT_CTuGocs.Where(u => u.MA_CTU == Utils.CStrDef(cboSochungtu.SelectedValue, "")).Select(s => new
            {
                SO_CTU = s.SO_CTU,
            }).Distinct();
            cboSochungtu.DisplayMember = "SO_CTU";
            cboSochungtu.ValueMember = "SO_CTU";
            cboSochungtu.DataSource = list;
        }
        #endregion

        #region text changed
        private void txtUsdTienHang_TextChanged(object sender, EventArgs e)
        {
            txtUsdTienHang.Text = string.Format("{0:#,#}", Utils.CDecDef(txtUsdTienHang.Text, 0));
            txtUsdTienHang.SelectionStart = txtUsdTienHang.Text.Length;
        }
        private void txtUsdChietkhau_TextChanged(object sender, EventArgs e)
        {
            txtUsdChietkhau.Text = string.Format("{0:#,#}", Utils.CDecDef(txtUsdChietkhau.Text, 0));
            txtUsdChietkhau.SelectionStart = txtUsdChietkhau.Text.Length;
        }
        private void txtUsdTienthue_TextChanged(object sender, EventArgs e)
        {
            txtUsdTienthue.Text = string.Format("{0:#,#}", Utils.CDecDef(txtUsdTienthue.Text, 0));
            txtUsdTienthue.SelectionStart = txtUsdTienthue.Text.Length;
        }
        private void txtUsdTongtien_TextChanged(object sender, EventArgs e)
        {
            txtUsdTongtien.Text = string.Format("{0:#,#}", Utils.CDecDef(txtUsdTongtien.Text, 0));
            txtUsdTongtien.SelectionStart = txtUsdTongtien.Text.Length;
        }
        private void txtVndTienhang_TextChanged(object sender, EventArgs e)
        {
            txtVndTienhang.Text = string.Format("{0:#,#}", Utils.CDecDef(txtVndTienhang.Text, 0));
            txtVndTienhang.SelectionStart = txtVndTienhang.Text.Length;
        }
        private void txtVndChietkhau2_TextChanged(object sender, EventArgs e)
        {
            txtVndChietkhau2.Text = string.Format("{0:#,#}", Utils.CDecDef(txtVndChietkhau2.Text, 0));
            txtVndChietkhau2.SelectionStart = txtVndChietkhau2.Text.Length;
        }
        private void txtVndTienthue2_TextChanged(object sender, EventArgs e)
        {
            txtVndTienthue2.Text = string.Format("{0:#,#}", Utils.CDecDef(txtVndTienthue2.Text, 0));
            txtVndTienthue2.SelectionStart = txtVndTienthue2.Text.Length;
        }
        private void txtVndTongtien_TextChanged(object sender, EventArgs e)
        {
            txtVndTongtien.Text = string.Format("{0:#,#}", Utils.CDecDef(txtVndTongtien.Text, 0));
            txtVndTongtien.SelectionStart = txtVndTongtien.Text.Length;
        }
        #endregion

        #region button click
        private void btnXemtonghop_Click(object sender, EventArgs e)
        {
            _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
            var list = this._db.KT_CTuGocs.Where(u => u.NGAY_CTU.Value != null && u.NGAY_CTU.Value.Month == Utils.CIntDef(fTerm._month, 0) && u.NGAY_CTU.Value.Year == Utils.CIntDef(fTerm._year, 0) && (u.NGAY_CTU.Value.Day >= Utils.CIntDef(txtTungay.Text, 0) || Utils.CIntDef(txtTungay.Text, 0) == 0) && (u.NGAY_CTU.Value.Day <= Utils.CIntDef(txtDenngay.Text, 0) || Utils.CIntDef(txtDenngay.Text, 0) == 0) && (u.MA_CTU == Utils.CStrDef(cboLoaichungtu.SelectedValue, "") || Utils.CStrDef(cboLoaichungtu.SelectedValue, "") == "") && (u.SO_CTU == Utils.CStrDef(cboSochungtu.SelectedValue, "") || Utils.CStrDef(cboSochungtu.SelectedValue, "") == ""));
            gridData.DataSource = list;
        }
        private void btnXemchitiet_Click(object sender, EventArgs e)
        {
            _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
            var list = this._db.KT_CTuGocs.Where(u => u.NGAY_CTU.Value != null && u.NGAY_CTU.Value.Month == Utils.CIntDef(fTerm._month, 0) && u.NGAY_CTU.Value.Year == Utils.CIntDef(fTerm._year, 0) && (u.NGAY_CTU.Value.Day >= Utils.CIntDef(txtTungay.Text, 0) || Utils.CIntDef(txtTungay.Text, 0) == 0) && (u.NGAY_CTU.Value.Day <= Utils.CIntDef(txtDenngay.Text, 0) || Utils.CIntDef(txtDenngay.Text, 0) == 0) && (u.MA_CTU == Utils.CStrDef(cboLoaichungtu.SelectedValue, "") || Utils.CStrDef(cboLoaichungtu.SelectedValue, "") == "") && (u.SO_CTU == Utils.CStrDef(cboSochungtu.SelectedValue, "") || Utils.CStrDef(cboSochungtu.SelectedValue, "") == ""));
            gridData2.DataSource = list;
            tabControl1.SelectedTab = tabItem2;
            getInfo();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _KT_CTuGocRepo = new KT_CTuGocRepo();
                int id = Utils.CIntDef(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID"), 0);
                KT_CTuGoc obj = _KT_CTuGocRepo.GetById(id);
                if (obj != null)
                {
                    obj.MA_CTU = txtLoai.Text;
                    obj.SO_CTU = txtSo.Text;
                    obj.NGAY_CTU = null;
                    if(txtNgay.Text.Length >0)
                        obj.NGAY_CTU = DateTime.ParseExact(txtNgay.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                    obj.DIEN_GIAI = txtDiengiai.Text;
                    obj.TEN_KH = txtTenKH.Text;
                    obj.HD_SO = txtSoHD.Text;
                    obj.HD_NGAY = null;
                    if (txtNgayHD.Text.Length > 0)
                    obj.HD_NGAY = DateTime.ParseExact(txtNgayHD.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                    obj.HD_SR = txtSeriHD.Text;

                    //txtUsdTienHang.Text = string.Format("", o
                    obj.CHIET_KHAU_USD = Utils.CDblDef(txtUsdChietkhau.Text.Replace(",", "").Replace(".", ""), 0);
                    obj.TIEN_THUE_USD = Utils.CDblDef(txtUsdTienthue.Text.Replace(",", "").Replace(".", ""), 0);
                    obj.TONG_TIEN_USD = Utils.CDblDef(txtUsdTongtien.Text.Replace(",", "").Replace(".", ""), 0);

                    obj.TIEN_HANG = Utils.CDblDef(txtVndTienhang.Text.Replace(",", "").Replace(".", ""), 0);
                    //txtVndChietkhau1.Text = string.Format("{0:#,###}", obj.CHIET_KHAU_VND);
                    obj.CHIET_KHAU_VND = Utils.CDblDef(txtVndChietkhau2.Text.Replace(",", "").Replace(".", ""), 0);
                    //txtVndTienthue1.Text = string.Format("{0:#,###}", obj.TIEN_THUE_VND);
                    obj.TIEN_THUE_VND = Utils.CDblDef(txtVndTienthue2.Text.Replace(",", "").Replace(".", ""), 0);
                    obj.TONG_TIEN_VND = Utils.CDblDef(txtVndTongtien.Text.Replace(",", "").Replace(".", ""), 0);

                    _KT_CTuGocRepo.Update(obj);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    int row = gridView2.FocusedRowHandle;
                    _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
                    var list = this._db.KT_CTuGocs.Where(u => u.NGAY_CTU.Value != null && u.NGAY_CTU.Value.Month == Utils.CIntDef(fTerm._month, 0) && u.NGAY_CTU.Value.Year == Utils.CIntDef(fTerm._year, 0) && (u.NGAY_CTU.Value.Day >= Utils.CIntDef(txtTungay.Text, 0) || Utils.CIntDef(txtTungay.Text, 0) == 0) && (u.NGAY_CTU.Value.Day <= Utils.CIntDef(txtDenngay.Text, 0) || Utils.CIntDef(txtDenngay.Text, 0) == 0) && (u.MA_CTU == Utils.CStrDef(cboLoaichungtu.SelectedValue, "") || Utils.CStrDef(cboLoaichungtu.SelectedValue, "") == "") && (u.SO_CTU == Utils.CStrDef(cboSochungtu.SelectedValue, "") || Utils.CStrDef(cboSochungtu.SelectedValue, "") == ""));
                    gridData2.DataSource = list;
                    gridView2.FocusedRowHandle = row;
                    getInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabItem1;
        }
        #endregion

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            getInfo();
        }

        #region shortcutKey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);            
            if (e.KeyCode == Keys.F12)
            {
                btnXemchitiet_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion     

        
    }
}
