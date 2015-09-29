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

namespace ketoansoft.app
{
    public partial class ThemTSCD : Form
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTDMTSCDRepo _KTDMTSCDRepo = new KTDMTSCDRepo();
        private KTDTPNRepo _KTDTPNRepo = new KTDTPNRepo();
        private KTYTCPRepo _KTYTCPRepo = new KTYTCPRepo();
        private KTDMCongTrinhRepo _KTDMCongTrinhRepo = new KTDMCongTrinhRepo();
        private KTTKRepo _KTTKRepo = new KTTKRepo();
        private KTNHOMHHRepo _KTNHOMHH = new KTNHOMHHRepo();
        public ThemTSCD()
        {
            InitializeComponent();
        }
        private void ThemTSCD_Load(object sender, EventArgs e)
        {
            LoadDMTSCD();
            LoadMaTSCuoi();
            Load_Data();
            LoadDTPNNo();
            LoadDTPNCo();
            LoadYTCPNo();
            LoadCongTrinh();
            LoadTKTaisan();
            LoadTKChiphi();
            LoadTKhaomon();
            LoadMaNhom();
        }

        #region load data
        private void Load_Data()
        {
            try
            {
                _KTDMTSCDRepo = new KTDMTSCDRepo();
                var list = _KTDMTSCDRepo.GetAll();
                int id = Utils.CIntDef(cboMaTS.SelectedValue, 0);
                if (id > 0)
                    list = _KTDMTSCDRepo.GetAll(id);
                gridControl1.DataSource = list;
            }
            catch (Exception) { }
        }
        private void LoadMaTSCuoi()
        {
            txtMaTSCuoi.Text = _KTDMTSCDRepo.GetMaTSCuoi();
        }
        private void LoadDMTSCD()
        {
            _KTDMTSCDRepo = new KTDMTSCDRepo();
            var list = _KTDMTSCDRepo.GetAll();
            cboMaTS.DataSource = list;
            cboMaTS.DisplayMember = "MA_TS";
            cboMaTS.ValueMember = "ID";
            cboMaTS.DropDownColumns = "MA_TS,TEN_TS";
            cboMaTS.SelectedIndex = -1;

            _KTDMTSCDRepo = new KTDMTSCDRepo();
            var list2 = _KTDMTSCDRepo.GetAll();
            cboMaTSMe.DataSource = list2;
            cboMaTSMe.DisplayMember = "MA_TS";
            cboMaTSMe.ValueMember = "ID";
            cboMaTSMe.DropDownColumns = "MA_TS,TEN_TS";
            cboMaTSMe.SelectedIndex = -1; 
        }
        private void cboMaTS_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "TEN_TS")
            {
                header.Width.Relative = 50; // 20% of available width
            }
            else { header.Width.Relative = 50; }
        }
        private void LoadDTPNNo()
        {
            _KTDTPNRepo = new KTDTPNRepo();
            cboDTPNNo.DataSource = _KTDTPNRepo.GetAll();
            cboDTPNNo.DisplayMember = "MA_DTPN";
            cboDTPNNo.ValueMember = "ID";
            cboDTPNNo.DropDownColumns = "MA_DTPN,TEN_DTPN";
            cboDTPNNo.SelectedIndex = -1;
        }
        private void cboDTPNNo_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
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
        private void LoadDTPNCo()
        {
            _KTDTPNRepo = new KTDTPNRepo();
            cboDTPNCo.DataSource = _KTDTPNRepo.GetAll();
            cboDTPNCo.DisplayMember = "MA_DTPN";
            cboDTPNCo.ValueMember = "ID";
            cboDTPNCo.DropDownColumns = "MA_DTPN,TEN_DTPN";
            cboDTPNCo.SelectedIndex = -1;
        }
        private void cboDTPNCo_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
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
        private void LoadYTCPNo()
        {
            _KTYTCPRepo = new KTYTCPRepo();
            cboYTCPNo.DataSource = _KTYTCPRepo.GetAll();
            cboYTCPNo.DisplayMember = "MA_YTCP";
            cboYTCPNo.ValueMember = "ID";
            cboYTCPNo.DropDownColumns = "MA_YTCP,TEN_YTCP_V";
            cboYTCPNo.SelectedIndex = -1;
        }
        private void cboYTCPNo_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_YTCP")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        private void LoadCongTrinh()
        {
            _KTDMCongTrinhRepo = new KTDMCongTrinhRepo();
            cboCongtrinh.DataSource = _KTDMCongTrinhRepo.GetAll();
            cboCongtrinh.DisplayMember = "MA_CT";
            cboCongtrinh.ValueMember = "ID";
            cboCongtrinh.DropDownColumns = "MA_CT,TEN_CT";
            cboCongtrinh.SelectedIndex = -1;
        }
        private void cboCongtrinh_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_CT")
            {
                header.Width.Relative = 40; // 20% of available width
            }
            else
            {
                header.Width.Relative = 60;
            }
        }
        private void LoadTKTaisan()
        {
            _KTTKRepo = new KTTKRepo();
            cboTKtaisan.DataSource = _KTTKRepo.GetByMaTK_Sub("211");
            cboTKtaisan.DisplayMember = "MA_TK";
            cboTKtaisan.ValueMember = "ID";
            cboTKtaisan.DropDownColumns = "MA_TK,TEN_TK";
            cboTKtaisan.SelectedIndex = -1;
        }
        private void cboTKtaisan_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_TK")
            {
                header.Width.Relative = 40; // 20% of available width
            }
            else
            {
                header.Width.Relative = 60;
            }
        }
        private void LoadTKChiphi()
        {
            _KTTKRepo = new KTTKRepo();
            cboTKchiphi.DataSource = _KTTKRepo.GetByMaTK_Sub("811", "6");
            cboTKchiphi.DisplayMember = "MA_TK";
            cboTKchiphi.ValueMember = "ID";
            cboTKchiphi.DropDownColumns = "MA_TK,TEN_TK";
            cboTKchiphi.SelectedIndex = -1;
        }
        private void cboTKchiphi_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_TK")
            {
                header.Width.Relative = 40; // 20% of available width
            }
            else
            {
                header.Width.Relative = 60;
            }
        }
        private void LoadTKhaomon()
        {
            _KTTKRepo = new KTTKRepo();
            cboTKhaomon.DataSource = _KTTKRepo.GetByMaTK_Sub("214");
            cboTKhaomon.DisplayMember = "MA_TK";
            cboTKhaomon.ValueMember = "ID";
            cboTKhaomon.DropDownColumns = "MA_TK,TEN_TK";
            cboTKhaomon.SelectedIndex = -1;
        }
        private void cboTKhaomon_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_TK")
            {
                header.Width.Relative = 40; // 20% of available width
            }
            else
            {
                header.Width.Relative = 60;
            }
        }
        private void LoadMaNhom()
        {
            _KTNHOMHH = new KTNHOMHHRepo();
            cboManhom.DataSource = _KTNHOMHH.GetAll();
            cboManhom.DisplayMember = "MA_NHOM";
            cboManhom.ValueMember = "ID";
            cboManhom.DropDownColumns = "MA_NHOM,TEN_NHOM";
            cboManhom.SelectedIndex = -1;
        }
        private void cboManhom_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_NHOM")
            {
                header.Width.Relative = 40; // 20% of available width
            }
            else
            {
                header.Width.Relative = 60;
            }
        }
        #endregion

        #region button click
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAuto_Click(object sender, EventArgs e)
        {
            string s3last = txtMaTSCuoi.Text.Substring(txtMaTSCuoi.Text.Length - 3);
            int i3last = Utils.CIntDef(s3last, 0);
            i3last = i3last + 1;
            string s ="TS";
            if (i3last < 10)
                s += "00" + i3last;
            else if (i3last < 100)
                s += "0" + i3last;
            cboMaTS.Text = s;
        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (cboMaTS.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã TS không được rỗng!","Thông báo");
                return;
            }
            _KTDMTSCDRepo = new KTDMTSCDRepo();
            var item = _KTDMTSCDRepo.GetById(Utils.CIntDef(cboMaTS.SelectedValue, 0));
            if (item != null)
            {
                #region
                item.TEN_TS = txtTenTS.Text;
                item.SO_LUONG = Utils.CDblDef(txtSoluong.Text, 0);
                item.DVT = txtDVT.Text;
                //txtDongiaVND.Text = item.d
                //txtThanhtienVND.Text = item.
                item.TY_GIA = Utils.CDblDef(txtTygia.Text, 0);
                //txtDongiaUSD.Text = item
                //txtThanhtienUSD.Text = item
                cboCokhauhao.Text = item.CO_KH;
                DateTime? temp = null;
                if (Utils.CDateDef(dtpNgaymua.Value, DateTime.MinValue) != DateTime.MinValue)
                    temp = Utils.CDateDef(dtpNgaymua.Value, DateTime.MinValue);
                item.NGAY_MUA = temp;
                temp = null;
                if (Utils.CDateDef(dtpNgaytrichKH.Value, DateTime.MinValue) != DateTime.MinValue)
                    temp = Utils.CDateDef(dtpNgaytrichKH.Value, DateTime.MinValue);
                item.NGAY_TRICH_KH = temp;
                item.TK_TS = cboTKtaisan.Text;
                item.TK_CP = cboTKchiphi.Text;
                item.TK_HM = cboTKhaomon.Text;
                item.DT_SUDUNG = txtDoituongsudung.Text;
                item.NGUYEN_GIA = Utils.CDblDef(txtNguyengiaVND.Text, 0);
                //txtNguyengiaUSD.Text = Utils.CStrDef(item.NGUYEN_GIA, "");
                item.THOI_GIAN_KH = Utils.CDblDef(txtThoigianKH.Text, 0);
                item.KH_1_THANG = Utils.CDblDef(txtKH1thangVND.Text, 0);
                //txtKH1thangUSD.Text = Utils.CStrDef(item.KH_1_THANG, "");
                item.LK_KH_DAUNAM = Utils.CDblDef(txtLuykeKHDaunamVND.Text, 0);
                //txtLuykeKHDaunamUSD.Text = Utils.CStrDef(item.LK_KH_DAUNAM, "");
                item.GT_CL_DAUNAM = Utils.CDblDef(txtGiatriCLDaunamVND.Text, 0);
                item.MA_DTPN_NO = cboDTPNNo.Text;
                item.MA_DTPN_CO = cboDTPNCo.Text;
                item.MA_YTCP_NO = cboYTCPNo.Text;
                item.MA_CT = cboCongtrinh.Text;
                //thông tin khác
                item.KY_HIEU = txtkyhieu.Text;
                item.MODEL = txtModel.Text;
                item.NUOC_SX = txtNuocsanxuat.Text;
                item.NAM_SX = Utils.CDblDef(txtNamsanxuat.Text, 0);
                item.QUY_CACH = txtQuycach.Text;
                item.MA_NHOM = cboManhom.Text;
                item.TEN_NHOM = txtTenNhom.Text;

                _KTDMTSCDRepo.Update(item);
                #endregion
            }
            else
            {
                #region
                item = new KT_DMTSCD();
                item.MA_TS = cboMaTS.Text;
                item.TEN_TS = txtTenTS.Text;
                item.SO_LUONG = Utils.CDblDef(txtSoluong.Text, 0);
                item.DVT = txtDVT.Text;
                //txtDongiaVND.Text = item.d
                //txtThanhtienVND.Text = item.
                item.TY_GIA = Utils.CDblDef(txtTygia.Text, 0);
                //txtDongiaUSD.Text = item
                //txtThanhtienUSD.Text = item
                cboCokhauhao.Text = item.CO_KH;
                DateTime? temp = null;
                if (Utils.CDateDef(dtpNgaymua.Value, DateTime.MinValue) != DateTime.MinValue)
                    temp = Utils.CDateDef(dtpNgaymua.Value, DateTime.MinValue);
                item.NGAY_MUA = temp;
                temp = null;
                if (Utils.CDateDef(dtpNgaytrichKH.Value, DateTime.MinValue) != DateTime.MinValue)
                    temp = Utils.CDateDef(dtpNgaytrichKH.Value, DateTime.MinValue);
                item.NGAY_TRICH_KH = temp;
                item.TK_TS = cboTKtaisan.Text;
                item.TK_CP = cboTKchiphi.Text;
                item.TK_HM = cboTKhaomon.Text;
                item.DT_SUDUNG = txtDoituongsudung.Text;
                item.NGUYEN_GIA = Utils.CDblDef(txtNguyengiaVND.Text, 0);
                //txtNguyengiaUSD.Text = Utils.CStrDef(item.NGUYEN_GIA, "");
                item.THOI_GIAN_KH = Utils.CDblDef(txtThoigianKH.Text, 0);
                item.KH_1_THANG = Utils.CDblDef(txtKH1thangVND.Text, 0);
                //txtKH1thangUSD.Text = Utils.CStrDef(item.KH_1_THANG, "");
                item.LK_KH_DAUNAM = Utils.CDblDef(txtLuykeKHDaunamVND.Text, 0);
                //txtLuykeKHDaunamUSD.Text = Utils.CStrDef(item.LK_KH_DAUNAM, "");
                item.GT_CL_DAUNAM = Utils.CDblDef(txtGiatriCLDaunamVND.Text, 0);
                item.MA_DTPN_NO = cboDTPNNo.Text;
                item.MA_DTPN_CO = cboDTPNCo.Text;
                item.MA_YTCP_NO = cboYTCPNo.Text;
                item.MA_CT = cboCongtrinh.Text;
                //thông tin khác
                item.KY_HIEU = txtkyhieu.Text;
                item.MODEL = txtModel.Text;
                item.NUOC_SX = txtNuocsanxuat.Text;
                item.NAM_SX = Utils.CDblDef(txtNamsanxuat.Text, 0);
                item.QUY_CACH = txtQuycach.Text;
                item.MA_NHOM = cboManhom.Text;
                item.TEN_NHOM = txtTenNhom.Text;
                
                _KTDMTSCDRepo.Create(item);

                LoadDMTSCD();
                cboMaTS.SelectedValue = item.ID;
                cboMaTS_SelectedIndexChanged(null, null);
                LoadMaTSCuoi();
                #endregion
            }
            MessageBox.Show("Cập nhật thành công!", "Thông báo");
        }
        #endregion
               
        #region cbo changed
        private void cboMaTS_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Data();
            _KTDMTSCDRepo = new KTDMTSCDRepo();
            var item = _KTDMTSCDRepo.GetById(Utils.CIntDef(cboMaTS.SelectedValue, 0));
            if (item != null)
            {
                txtTenTS.Text = item.TEN_TS;
                txtSoluong.Text = Utils.CStrDef(item.SO_LUONG, "");
                txtDVT.Text = item.DVT;
                //txtDongiaVND.Text = item.d
                //txtThanhtienVND.Text = item.
                txtTygia.Text = Utils.CStrDef(item.TY_GIA, "");
                //txtDongiaUSD.Text = item
                //txtThanhtienUSD.Text = item
                cboCokhauhao.Text = item.CO_KH;
                dtpNgaymua.Value = new DateTime(0);
                if (Utils.CDateDef(item.NGAY_MUA, DateTime.MinValue) != DateTime.MinValue)
                    dtpNgaymua.Value = Utils.CDateDef(item.NGAY_MUA, DateTime.MinValue);
                dtpNgaytrichKH.Value = new DateTime(0);
                if (Utils.CDateDef(item.NGAY_TRICH_KH, DateTime.MinValue) != DateTime.MinValue)
                    dtpNgaytrichKH.Value = Utils.CDateDef(item.NGAY_TRICH_KH, DateTime.MinValue);
                cboTKtaisan.Text = item.TK_TS;
                cboTKchiphi.Text = item.TK_CP;
                cboTKhaomon.Text = item.TK_HM;
                txtDoituongsudung.Text = item.DT_SUDUNG;
                txtNguyengiaVND.Text = Utils.CStrDef(item.NGUYEN_GIA, "");
                //txtNguyengiaUSD.Text = Utils.CStrDef(item.NGUYEN_GIA, "");
                txtThoigianKH.Text = Utils.CStrDef(item.THOI_GIAN_KH, "");
                txtKH1thangVND.Text = Utils.CStrDef(item.KH_1_THANG, "");
                //txtKH1thangUSD.Text = Utils.CStrDef(item.KH_1_THANG, "");
                txtLuykeKHDaunamVND.Text = Utils.CStrDef(item.LK_KH_DAUNAM, "");
                //txtLuykeKHDaunamUSD.Text = Utils.CStrDef(item.LK_KH_DAUNAM, "");
                txtGiatriCLDaunamVND.Text = Utils.CStrDef(item.GT_CL_DAUNAM, "");
                cboDTPNNo.Text = item.MA_DTPN_NO;
                cboDTPNNo_SelectedIndexChanged(null, null);
                cboDTPNCo.Text = item.MA_DTPN_CO;
                cboDTPNCo_SelectedIndexChanged(null, null);
                cboYTCPNo.Text = item.MA_YTCP_NO;
                cboYTCPNo_SelectedIndexChanged(null, null);
                cboCongtrinh.Text = item.MA_CT;
                cboCongtrinh_SelectedIndexChanged(null, null);

                //thông tin khác
                txtkyhieu.Text = item.KY_HIEU;
                txtModel.Text = item.MODEL;
                txtNuocsanxuat.Text = item.NUOC_SX;
                txtNamsanxuat.Text = Utils.CStrDef(item.NAM_SX, "");
                txtQuycach.Text = item.QUY_CACH;
                cboManhom.Text = item.MA_NHOM;
                txtTenNhom.Text = item.TEN_NHOM;
            }
        }
        private void cboMaTSMe_SelectedIndexChanged(object sender, EventArgs e)
        {
            _KTDMTSCDRepo = new KTDMTSCDRepo();
            var item = _KTDMTSCDRepo.GetById(Utils.CIntDef(cboMaTSMe.SelectedValue, 0));
            if (item != null)
                txtTenTSMe.Text = item.TEN_TS;
        }
        private void cboDTPNNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _KTDTPNRepo = new KTDTPNRepo();
            var item = _KTDTPNRepo.GetById(Utils.CIntDef(cboDTPNNo.SelectedValue, 0));
            if (item != null)
                txtDTPNNo.Text = item.TEN_DTPN;
        }
        private void cboDTPNCo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _KTDTPNRepo = new KTDTPNRepo();
            var item = _KTDTPNRepo.GetById(Utils.CIntDef(cboDTPNCo.SelectedValue, 0));
            if (item != null)
                txtDTPNCo.Text = item.TEN_DTPN;
        }
        private void cboYTCPNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _KTYTCPRepo = new KTYTCPRepo();
            var item = _KTYTCPRepo.GetById(Utils.CIntDef(cboYTCPNo.SelectedValue, 0));
            if (item != null)
                txtYTCPNo.Text = item.TEN_YTCP_V;
        }
        private void cboCongtrinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            _KTDMCongTrinhRepo = new KTDMCongTrinhRepo();
            var item = _KTDMCongTrinhRepo.GetById(Utils.CIntDef(cboCongtrinh.SelectedValue, 0));
            if (item != null)
                txtTencongtrinh.Text = item.TEN_CT;
        }
        private void cboManhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            _KTNHOMHH = new KTNHOMHHRepo();
            var item = _KTNHOMHH.GetById(Utils.CIntDef(cboManhom.SelectedValue, 0));
            if (item != null)
                txtTenNhom.Text = item.TEN_NHOM;
        }
        #endregion

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colSTT) //colSTT là tên cột tạo số thứ tự
            {
                e.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }



    }
}
