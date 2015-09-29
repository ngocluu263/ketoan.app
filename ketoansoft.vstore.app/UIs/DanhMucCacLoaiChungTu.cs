using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ketoansoft.app.Class.Data;
using DevExpress.XtraEditors;
using ketoansoft.app.Components.clsVproUtility;
using System.Collections;
using ketoansoft.app.Class.Global;
using System.Diagnostics;
using ketoansoft.app.Diaglog;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;

namespace ketoansoft.app
{
    public partial class DanhMucCacLoaiChungTu : DevComponents.DotNetBar.Metro.MetroForm
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTLCTGRepo _KTLCTGRepo = new KTLCTGRepo();
        private Unit _unit = new Unit();
        private List<int> _listUpdate = new List<int>();

        public DanhMucCacLoaiChungTu()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Data()
        {
            try
            {
                _KTLCTGRepo = new KTLCTGRepo();
                gridData.DataSource = _KTLCTGRepo.GetAll();
                //_db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
                //gridData.DataSource = null;
                //gridData.DataSource = _db.KT_LCTGs;
                //gridData.RefreshDataSource();
                //gridView1.RefreshData();
            }
            catch (Exception) { }
        }
        private void Save_Data(bool msg)
        {
            try
            {
                _KTLCTGRepo = new KTLCTGRepo();
                int i = 0;
                foreach (int pos in _listUpdate)
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(pos, "ID"), 0);
                    KT_LCTG obj = _KTLCTGRepo.GetById(id);
                    if (obj != null)
                    {
                        obj.ID_LOAI = Utils.CStrDef(gridView1.GetRowCellValue(pos, "ID_LOAI"), "");
                        obj.TEN_CT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_CT"), "");
                        obj.TK_THUE = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_THUE"), "");
                        obj.CO_TK_DU_TK_THUE = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_TK_DU_TK_THUE"), "");
                        obj.CO_THUE_GTGT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_THUE_GTGT"), "");
                        obj.CO_HANG_HOA = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_HANG_HOA"), "");
                        obj.SERI_HD = Utils.CStrDef(gridView1.GetRowCellValue(pos, "SERI_HD"), "");
                        obj.LOAI_TIEN = Utils.CStrDef(gridView1.GetRowCellValue(pos, "LOAI_TIEN"), "");
                        obj.SO_CT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "SO_CT"), "");
                        obj.SO_HD = Utils.CStrDef(gridView1.GetRowCellValue(pos, "SO_HD"), "");
                        obj.CO_XUAT_KHO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_XUAT_KHO"), "");
                        obj.CO_NHIEU_HD = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_NHIEU_HD"), "");
                        //obj.MAN_HINH = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MAN_HINH"), "");
                        obj.TK_NO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_NO"), "");
                        obj.TK_CO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_CO"), "");
                        //obj.VONG_LAP = Utils.CStrDef(gridView1.GetRowCellValue(pos, "VONG_LAP"), "");
                        obj.TK_THUE_NK = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_THUE_NK"), "");
                        //obj.HAM_IN = Utils.CStrDef(gridView1.GetRowCellValue(pos, "HAM_IN"), "");
                        obj.CO_UN_CHI = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_UN_CHI"), "");
                        obj.CO_XK_CUM = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_XK_CUM"), "");
                        obj.NGUOI_GD = Utils.CStrDef(gridView1.GetRowCellValue(pos, "NGUOI_GD"), "");
                        obj.CO_VUNG_BAN = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_VUNG_BAN"), "");
                        obj.CO_DON_TRONG = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_DON_TRONG"), "");
                        obj.CO_LO_NHAP = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_LO_NHAP"), "");
                        obj.FILE_MAU = Utils.CStrDef(gridView1.GetRowCellValue(pos, "FILE_MAU"), "");
                        obj.NHIEU_LIEN = Utils.CStrDef(gridView1.GetRowCellValue(pos, "NHIEU_LIEN"), "");
                        obj.CLTG = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CLTG"), "");
                        obj.HOI_IN = Utils.CStrDef(gridView1.GetRowCellValue(pos, "HOI_IN"), "");
                        obj.DIEN_GIAI = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DIEN_GIAI"), "");
                        obj.SO_DONG_IN = Utils.CIntDef(gridView1.GetRowCellValue(pos, "SO_DONG_IN"), 0);
                        obj.MA_TIEP_THI = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_TIEP_THI"), "");
                        obj.NHIEU_DV = Utils.CStrDef(gridView1.GetRowCellValue(pos, "NHIEU_DV"), "");
                        obj.CO_DIEN_GIAI2 = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_DIEN_GIAI2"), "");
                        obj.CO_CK = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_CK"), "");
                        obj.TK_CLTG_LAI = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_CLTG_LAI"), "");
                        obj.TK_CLTG_LO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_CLTG_LO"), "");
                        obj.CO_CHUYEN_KHO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_CHUYEN_KHO"), "");
                        obj.CO_TIEN_HANG = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_TIEN_HANG"), "");
                        obj.CO_FORM_RIENG = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_FORM_RIENG"), "");
                        obj.CO_CK_TRUOC = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_CK_TRUOC"), "");
                        obj.CO_DV_PHU = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_DV_PHU"), "");
                        obj.CO_QUY_CACH = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_QUY_CACH"), "");
                        obj.CO_PHE_LIEU = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_PHE_LIEU"), "");
                        obj.CO_MS_KH = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_MS_KH"), "");
                        obj.LOAI_THUE = Utils.CStrDef(gridView1.GetRowCellValue(pos, "LOAI_THUE"), "");
                        //obj.CO_DG_NHAP = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_DG_NHAP"), "");
                        obj.MA_DTPN_NO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_DTPN_NO"), "");
                        obj.MA_DTPN_CO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_DTPN_CO"), "");
                        obj.CO_THUE_TTDB = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_THUE_TTDB"), "");
                        obj.NHIEU_USER = Utils.CStrDef(gridView1.GetRowCellValue(pos, "NHIEU_USER"), "");
                        obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(pos, "TRANG_THAI"), 0);
                        obj.CO_TK_XUAT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_TK_XUAT"), "");
                        obj.TK_XUAT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_XUAT"), "");
                        obj.TK_GIA_VON = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_GIA_VON"), "");
                        obj.NHOM_CT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "NHOM_CT"), "");
                        //obj.NHOM_DS_COT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "NHOM_DS_COT"), "");
                        obj.TS_GTGT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TS_GTGT"), "");
                        obj.KIEU_CONGTY = Utils.CStrDef(gridView1.GetRowCellValue(pos, "KIEU_CONGTY"), "");
                        obj.CO_CK_TM = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_CK_TM"), "");
                        obj.CO_CK_TT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_CK_TT"), "");
                        obj.CO_VANCHUYEN = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CO_VANCHUYEN"), "");
                        
                        _KTLCTGRepo.Update(obj);
                        i++;
                    }
                }
                _listUpdate = new List<int>();
                //if (i > 0 && msg)
                //{
                //    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Save_Tick()
        {
            try
            {
                //int _id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                //CFG obj = _KTLCTGRepo.GetById(_id);
                //if (obj != null)
                //{
                //    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "").Trim() == "T" ? "" : "T";
                //    _KTLCTGRepo.Update(obj);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Save_Duplicate()
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn copy dòng này thành dòng mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _KTLCTGRepo = new KTLCTGRepo();
                    KT_LCTG obj = new KT_LCTG();
                    obj.ID_LOAI = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID_LOAI"), "");
                    obj.TEN_CT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_CT"), "");
                    obj.TK_THUE = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_THUE"), "");
                    obj.CO_TK_DU_TK_THUE = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_TK_DU_TK_THUE"), "");
                    obj.CO_THUE_GTGT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_THUE_GTGT"), "");
                    obj.CO_HANG_HOA = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_HANG_HOA"), "");
                    obj.SERI_HD = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SERI_HD"), "");
                    obj.LOAI_TIEN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LOAI_TIEN"), "");
                    obj.SO_CT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_CT"), "");
                    obj.SO_HD = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_HD"), "");
                    obj.CO_XUAT_KHO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_XUAT_KHO"), "");
                    obj.CO_NHIEU_HD = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_NHIEU_HD"), "");
                    //obj.MAN_HINH = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAN_HINH"), "");
                    obj.TK_NO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_NO"), "");
                    obj.TK_CO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_CO"), "");
                    //obj.VONG_LAP = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VONG_LAP"), "");
                    obj.TK_THUE_NK = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_THUE_NK"), "");
                    //obj.HAM_IN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HAM_IN"), "");
                    obj.CO_UN_CHI = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_UN_CHI"), "");
                    obj.CO_XK_CUM = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_XK_CUM"), "");
                    obj.NGUOI_GD = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGUOI_GD"), "");
                    obj.CO_VUNG_BAN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_VUNG_BAN"), "");
                    obj.CO_DON_TRONG = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_DON_TRONG"), "");
                    obj.CO_LO_NHAP = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_LO_NHAP"), "");
                    obj.FILE_MAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FILE_MAU"), "");
                    obj.NHIEU_LIEN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NHIEU_LIEN"), "");
                    obj.CLTG = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CLTG"), "");
                    obj.HOI_IN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HOI_IN"), "");
                    obj.DIEN_GIAI = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DIEN_GIAI"), "");
                    obj.SO_DONG_IN = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_DONG_IN"), 0);
                    obj.MA_TIEP_THI = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_TIEP_THI"), "");
                    obj.NHIEU_DV = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NHIEU_DV"), "");
                    obj.CO_DIEN_GIAI2 = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_DIEN_GIAI2"), "");
                    obj.CO_CK = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_CK"), "");
                    obj.TK_CLTG_LAI = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_CLTG_LAI"), "");
                    obj.TK_CLTG_LO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_CLTG_LO"), "");
                    obj.CO_CHUYEN_KHO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_CHUYEN_KHO"), "");
                    obj.CO_TIEN_HANG = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_TIEN_HANG"), "");
                    obj.CO_FORM_RIENG = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_FORM_RIENG"), "");
                    obj.CO_CK_TRUOC = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_CK_TRUOC"), "");
                    obj.CO_DV_PHU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_DV_PHU"), "");
                    obj.CO_QUY_CACH = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_QUY_CACH"), "");
                    obj.CO_PHE_LIEU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_PHE_LIEU"), "");
                    obj.CO_MS_KH = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_MS_KH"), "");
                    obj.LOAI_THUE = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LOAI_THUE"), "");
                    //obj.CO_DG_NHAP = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_DG_NHAP"), "");
                    obj.MA_DTPN_NO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_DTPN_NO"), "");
                    obj.MA_DTPN_CO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_DTPN_CO"), "");
                    obj.CO_THUE_TTDB = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_THUE_TTDB"), "");
                    obj.NHIEU_USER = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NHIEU_USER"), "");
                    obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TRANG_THAI"), 0);
                    obj.CO_TK_XUAT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_TK_XUAT"), "");
                    obj.TK_XUAT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_XUAT"), "");
                    obj.TK_GIA_VON = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_GIA_VON"), "");
                    obj.NHOM_CT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NHOM_CT"), "");
                    //obj.NHOM_DS_COT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NHOM_DS_COT"), "");
                    obj.TS_GTGT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TS_GTGT"), "");
                    obj.KIEU_CONGTY = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KIEU_CONGTY"), "");
                    obj.CO_CK_TM = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_CK_TM"), "");
                    obj.CO_CK_TT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_CK_TT"), "");
                    obj.CO_VANCHUYEN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CO_VANCHUYEN"), "");

                    _KTLCTGRepo.Create(obj);
                    MessageBox.Show("Đã copy dòng này vào cuối bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Remove_Data()
        {
            try
            {
                //if (_listUpdate.Count > 0)
                //{
                //    MessageBox.Show("Hãy thực hiện lưu trước khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                Save_Data(false);
                _KTLCTGRepo = new KTLCTGRepo();
                int Id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"), 0);
                _KTLCTGRepo.Remove(Id);
                //MessageBox.Show("Xóa dòng ID:" + Id + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Grid Event
        private void gridData_Load(object sender, EventArgs e)
        {
            Unit.UnitGridview(gridView1);
            Load_Data();

            Load_InfoHeader();
        }
        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            // Sự kiện này để người ta không chuyển qua dòng khác được khi có lỗi xảy ra nè
            // Nó nhận giá trị e.Valid của gridView1_ValidateRow để ứng xử
            // neu e,Valid =True thì nó cho chuyển qua dòng khác hoặc làm tác vụ khác
            // và ngược lại
             e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                bool b = _listUpdate.Exists(a => a == gridView1.FocusedRowHandle);
                if (!b)
                {
                    _listUpdate.Add(gridView1.FocusedRowHandle);
                }
            }));
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            //_unit.Get_ColorTick(gridView1, sender, e);
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_InfoRows();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                _KTLCTGRepo = new KTLCTGRepo();
                //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
                if (view.IsNewItemRow(e.RowHandle))
                {
                    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại
                    KT_LCTG obj = new KT_LCTG();
                    obj.ID_LOAI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "ID_LOAI"), "");
                    obj.TEN_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_CT"), "");
                    obj.TK_THUE = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_THUE"), "");
                    obj.CO_TK_DU_TK_THUE = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_TK_DU_TK_THUE"), "");
                    obj.CO_THUE_GTGT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_THUE_GTGT"), "");
                    obj.CO_HANG_HOA = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_HANG_HOA"), "");
                    obj.SERI_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SERI_HD"), "");
                    obj.LOAI_TIEN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "LOAI_TIEN"), "");
                    obj.SO_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_CT"), "");
                    obj.SO_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HD"), "");
                    obj.CO_XUAT_KHO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_XUAT_KHO"), "");
                    obj.CO_NHIEU_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_NHIEU_HD"), "");
                    //obj.MAN_HINH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MAN_HINH"), "");
                    obj.TK_NO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_NO"), "");
                    obj.TK_CO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_CO"), "");
                    //obj.VONG_LAP = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "VONG_LAP"), "");
                    obj.TK_THUE_NK = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_THUE_NK"), "");
                    //obj.HAM_IN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "HAM_IN"), "");
                    obj.CO_UN_CHI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_UN_CHI"), "");
                    obj.CO_XK_CUM = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_XK_CUM"), "");
                    obj.NGUOI_GD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NGUOI_GD"), "");
                    obj.CO_VUNG_BAN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_VUNG_BAN"), "");
                    obj.CO_DON_TRONG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_DON_TRONG"), "");
                    obj.CO_LO_NHAP = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_LO_NHAP"), "");
                    obj.FILE_MAU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "FILE_MAU"), "");
                    obj.NHIEU_LIEN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NHIEU_LIEN"), "");
                    obj.CLTG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CLTG"), "");
                    obj.HOI_IN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "HOI_IN"), "");
                    obj.DIEN_GIAI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DIEN_GIAI"), "");
                    obj.SO_DONG_IN = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "SO_DONG_IN"), 0);
                    obj.MA_TIEP_THI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_TIEP_THI"), "");
                    obj.NHIEU_DV = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NHIEU_DV"), "");
                    obj.CO_DIEN_GIAI2 = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_DIEN_GIAI2"), "");
                    obj.CO_CK = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_CK"), "");
                    obj.TK_CLTG_LAI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_CLTG_LAI"), "");
                    obj.TK_CLTG_LO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_CLTG_LO"), "");
                    obj.CO_CHUYEN_KHO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_CHUYEN_KHO"), "");
                    obj.CO_TIEN_HANG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_TIEN_HANG"), "");
                    obj.CO_FORM_RIENG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_FORM_RIENG"), "");
                    obj.CO_CK_TRUOC = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_CK_TRUOC"), "");
                    obj.CO_DV_PHU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_DV_PHU"), "");
                    obj.CO_QUY_CACH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_QUY_CACH"), "");
                    obj.CO_PHE_LIEU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_PHE_LIEU"), "");
                    obj.CO_MS_KH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_MS_KH"), "");
                    obj.LOAI_THUE = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "LOAI_THUE"), "");
                    //obj.CO_DG_NHAP = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_DG_NHAP"), "");
                    obj.MA_DTPN_NO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_DTPN_NO"), "");
                    obj.MA_DTPN_CO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_DTPN_CO"), "");
                    obj.CO_THUE_TTDB = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_THUE_TTDB"), "");
                    obj.NHIEU_USER = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NHIEU_USER"), "");
                    obj.TRANG_THAI = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TRANG_THAI"), 0);
                    obj.CO_TK_XUAT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_TK_XUAT"), "");
                    obj.TK_XUAT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_XUAT"), "");
                    obj.TK_GIA_VON = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_GIA_VON"), "");
                    obj.NHOM_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NHOM_CT"), "");
                    //obj.NHOM_DS_COT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NHOM_DS_COT"), "");
                    obj.TS_GTGT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TS_GTGT"), "");
                    obj.KIEU_CONGTY = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "KIEU_CONGTY"), "");
                    obj.CO_CK_TM = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_CK_TM"), "");
                    obj.CO_CK_TT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_CK_TT"), "");
                    obj.CO_VANCHUYEN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_VANCHUYEN"), "");

                    _KTLCTGRepo.Create(obj);

                }
                //Cũ thì update
                else
                {
                    int id = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "ID"), 0);
                    KT_LCTG obj = _KTLCTGRepo.GetById(id);
                    if (obj != null)
                    {
                        obj.ID_LOAI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "ID_LOAI"), "");
                        obj.TEN_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_CT"), "");
                        obj.TK_THUE = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_THUE"), "");
                        obj.CO_TK_DU_TK_THUE = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_TK_DU_TK_THUE"), "");
                        obj.CO_THUE_GTGT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_THUE_GTGT"), "");
                        obj.CO_HANG_HOA = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_HANG_HOA"), "");
                        obj.SERI_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SERI_HD"), "");
                        obj.LOAI_TIEN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "LOAI_TIEN"), "");
                        obj.SO_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_CT"), "");
                        obj.SO_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HD"), "");
                        obj.CO_XUAT_KHO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_XUAT_KHO"), "");
                        obj.CO_NHIEU_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_NHIEU_HD"), "");
                        //obj.MAN_HINH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MAN_HINH"), "");
                        obj.TK_NO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_NO"), "");
                        obj.TK_CO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_CO"), "");
                        //obj.VONG_LAP = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "VONG_LAP"), "");
                        obj.TK_THUE_NK = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_THUE_NK"), "");
                        //obj.HAM_IN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "HAM_IN"), "");
                        obj.CO_UN_CHI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_UN_CHI"), "");
                        obj.CO_XK_CUM = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_XK_CUM"), "");
                        obj.NGUOI_GD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NGUOI_GD"), "");
                        obj.CO_VUNG_BAN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_VUNG_BAN"), "");
                        obj.CO_DON_TRONG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_DON_TRONG"), "");
                        obj.CO_LO_NHAP = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_LO_NHAP"), "");
                        obj.FILE_MAU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "FILE_MAU"), "");
                        obj.NHIEU_LIEN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NHIEU_LIEN"), "");
                        obj.CLTG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CLTG"), "");
                        obj.HOI_IN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "HOI_IN"), "");
                        obj.DIEN_GIAI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DIEN_GIAI"), "");
                        obj.SO_DONG_IN = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "SO_DONG_IN"), 0);
                        obj.MA_TIEP_THI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_TIEP_THI"), "");
                        obj.NHIEU_DV = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NHIEU_DV"), "");
                        obj.CO_DIEN_GIAI2 = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_DIEN_GIAI2"), "");
                        obj.CO_CK = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_CK"), "");
                        obj.TK_CLTG_LAI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_CLTG_LAI"), "");
                        obj.TK_CLTG_LO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_CLTG_LO"), "");
                        obj.CO_CHUYEN_KHO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_CHUYEN_KHO"), "");
                        obj.CO_TIEN_HANG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_TIEN_HANG"), "");
                        obj.CO_FORM_RIENG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_FORM_RIENG"), "");
                        obj.CO_CK_TRUOC = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_CK_TRUOC"), "");
                        obj.CO_DV_PHU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_DV_PHU"), "");
                        obj.CO_QUY_CACH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_QUY_CACH"), "");
                        obj.CO_PHE_LIEU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_PHE_LIEU"), "");
                        obj.CO_MS_KH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_MS_KH"), "");
                        obj.LOAI_THUE = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "LOAI_THUE"), "");
                        //obj.CO_DG_NHAP = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_DG_NHAP"), "");
                        obj.MA_DTPN_NO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_DTPN_NO"), "");
                        obj.MA_DTPN_CO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_DTPN_CO"), "");
                        obj.CO_THUE_TTDB = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_THUE_TTDB"), "");
                        obj.NHIEU_USER = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NHIEU_USER"), "");
                        obj.TRANG_THAI = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TRANG_THAI"), 0);
                        obj.CO_TK_XUAT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_TK_XUAT"), "");
                        obj.TK_XUAT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_XUAT"), "");
                        obj.TK_GIA_VON = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_GIA_VON"), "");
                        obj.NHOM_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NHOM_CT"), "");
                        //obj.NHOM_DS_COT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NHOM_DS_COT"), "");
                        obj.TS_GTGT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TS_GTGT"), "");
                        obj.KIEU_CONGTY = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "KIEU_CONGTY"), "");
                        obj.CO_CK_TM = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_CK_TM"), "");
                        obj.CO_CK_TT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_CK_TT"), "");
                        obj.CO_VANCHUYEN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "CO_VANCHUYEN"), "");

                        _KTLCTGRepo.Update(obj);
                    }
                }
                Load_Data();
            }
            catch (Exception ex)
            {
                e.Valid = false;
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Button Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save_Data(true);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn thoát không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    Save_Data(false);
            //    this.Close();
            //}
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            gridView1.ShowFindPanel();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Remove_Data();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            _unit.Get_AllowEdit(gridView1);
        }
        private void btnToCol_Click(object sender, EventArgs e)
        {
            FocusCol();
        }
        private void btnTick_Click(object sender, EventArgs e)
        {
            Save_Tick();
        }
        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            Save_Duplicate();
            Load_Data();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_Data();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridView1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridView1.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gridView1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridView1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridView1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridView1.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            _unit.ShowGridPreview(gridData);
        }
        #endregion

        #region Form function
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!e.Cancel)
            {
                if (MessageBox.Show("Bạn có muốn đóng form Danh Mục Các Loại Chứng Từ không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    Save_Data(false);
                }
            }
        }
        #endregion

        #region Funtion
        private void FocusCol()
        {
            dlogToCol dialog = new dlogToCol(gridView1);
            dialog.ShowDialog();
            string _value = dialog.Result;
            gridView1.FocusedColumn = gridView1.Columns[_value];
        }
        private void Load_InfoHeader()
        {
            txtMonth.Text = Utils.CStrDef(fTerm._month, "");
            txtYear.Text = Utils.CStrDef(fTerm._year, "");
            txtDatabase.Text = Unit.Get_DatabaseName();
            txtCompanyName.Text = Unit.Get_CompanyName();
            txtNumRows.Text = Utils.CStrDef(gridView1.RowCount, "0") + " of " + Utils.CStrDef(gridView1.RowCount, "0");
        }
        private void Load_InfoRows()
        {
            string[] _arr = { "ID", "TEN_CT" };
            txtInfoRows.Text = Unit.Get_InfoRows(gridView1, _arr);
        }
        #endregion

        #region shortcutKey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);
            if (e.KeyCode == Keys.F1)
            {
                btnSearch_Click(null, null);
            }
            else if (e.KeyCode == Keys.F2)
            {
                Save_Tick();
            }
            else if (e.KeyCode == Keys.F3)
            {
                Save_Duplicate();
                Load_Data();
            }
            else if (e.KeyCode == Keys.F5)
            {
                Load_Data();
            }
            else if (e.KeyCode == Keys.F6)
            {
                FocusCol();
            }
            else if (e.KeyCode == Keys.S && e.Control)
            {
                Save_Data(true); return true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnDelete_Click(null, null);
            }
            else if (e.KeyCode == Keys.Q && e.Control)
            {
                btnExit_Click(null, null);
            }
            else if (e.KeyCode == Keys.F10)
            {
                _unit.Get_AllowEdit(gridView1);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion        
 

    }
}