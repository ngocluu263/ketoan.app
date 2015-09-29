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
using ketoansoft.app.Diaglog;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace ketoansoft.app
{
    public partial class BangGiaThanhCongTrinh : DevComponents.DotNetBar.Metro.MetroForm
    {
        dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTGTCTTHANGRepo _KTGTCTTHANGRepo = new KTGTCTTHANGRepo();
        public Unit _unit = new Unit();
        private List<int> _listUpdate = new List<int>();

        public BangGiaThanhCongTrinh()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Data()
        {
            try
            {
                _KTGTCTTHANGRepo = new KTGTCTTHANGRepo();
                gridData.DataSource = _KTGTCTTHANGRepo.GetAll();
                //_db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
                //gridData.DataSource = null;
                //gridData.DataSource = _db.KT_DMHHs;
                //gridData.RefreshDataSource();
                //gridView1.RefreshData();
            }
            catch (Exception) { }
        }
        private void Save_Data(bool msg)
        {
            try
            {
                _KTGTCTTHANGRepo = new KTGTCTTHANGRepo();
                int i = 0;
                foreach (int pos in _listUpdate)
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(pos, "ID"), 0);
                    KT_GTCT_THANG obj = _KTGTCTTHANGRepo.GetById(id);
                    if (obj != null)
                    {
                        obj.THANG = Utils.CIntDef(gridView1.GetRowCellValue(pos, "THANG"), 0);
                        obj.MA_CT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_CT"), "");
                        obj.TEN_CT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_CT"), "");
                        obj.HOAN_THANH = Utils.CDblDef(gridView1.GetRowCellValue(pos, "HOAN_THANH"), 0);
                        DateTime? temp = null;
                        if(Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_HD"), DateTime.MinValue);
                        obj.NGAY_HD = temp;
                        obj.SO_HD = Utils.CStrDef(gridView1.GetRowCellValue(pos, "SO_HD"), "");
                        obj.NOI_DUNG = Utils.CStrDef(gridView1.GetRowCellValue(pos, "NOI_DUNG"), "");
                        obj.GIA_TRI = Utils.CDblDef(gridView1.GetRowCellValue(pos, "GIA_TRI"), 0);
                        obj.GIA_TRI_NT = Utils.CDblDef(gridView1.GetRowCellValue(pos, "GIA_TRI_NT"), 0);                        
                        obj.SO_NGAY_LAM = Utils.CDblDef(gridView1.GetRowCellValue(pos, "SO_NGAY_LAM"), 0);
                        temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_NT"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_NT"), DateTime.MinValue);
                        obj.NGAY_NT = temp;
                        temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_KC"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_KC"), DateTime.MinValue);
                        obj.NGAY_KC = temp;
                        obj.CP_DK_621 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "CP_DK_621"), 0);
                        obj.CP_DK_622 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "CP_DK_622"), 0);
                        obj.CP_DK_623 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "CP_DK_623"), 0);
                        obj.CP_DK_627 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "CP_DK_627"), 0);
                        obj.DO_DANG_DK = Utils.CDblDef(gridView1.GetRowCellValue(pos, "DO_DANG_DK"), 0);
                        obj.DOANH_THU_DK = Utils.CDblDef(gridView1.GetRowCellValue(pos, "DOANH_THU_DK"), 0);
                        obj.DOANH_THU_TK = Utils.CDblDef(gridView1.GetRowCellValue(pos, "DOANH_THU_TK"), 0);
                        obj.DOANH_THU_LK = Utils.CDblDef(gridView1.GetRowCellValue(pos, "DOANH_THU_LK"), 0);
                        obj.DOANH_THU_CK = Utils.CDblDef(gridView1.GetRowCellValue(pos, "DOANH_THU_CK"), 0);
                        obj.THUE_VAT_DK = Utils.CDblDef(gridView1.GetRowCellValue(pos, "THUE_VAT_DK"), 0);
                        obj.THUE_VAT_TK = Utils.CDblDef(gridView1.GetRowCellValue(pos, "THUE_VAT_TK"), 0);
                        obj.THUE_VAT_CK = Utils.CDblDef(gridView1.GetRowCellValue(pos, "THUE_VAT_CK"), 0);
                        obj.DS_HD_DK = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DS_HD_DK"), "");
                        obj.DS_HD_TK = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DS_HD_TK"), "");
                        obj.PSTK_621 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSTK_621"), 0);
                        obj.PSTK_622 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSTK_622"), 0);
                        obj.PSTK_623 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSTK_623"), 0);
                        obj.PSTK_627 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSTK_627"), 0);
                        obj.PSTK_TONG = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSTK_TONG"), 0);
                        obj.PSLK_621 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSLK_621"), 0);
                        obj.PSLK_622 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSLK_622"), 0);
                        obj.PSLK_623 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSLK_623"), 0);
                        obj.PSLK_627 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSLK_627"), 0);
                        obj.TONG_CP = Utils.CDblDef(gridView1.GetRowCellValue(pos, "TONG_CP"), 0);
                        obj.CP_CK_621 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "CP_CK_621"), 0);
                        obj.CP_CK_622 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "CP_CK_622"), 0);
                        obj.CP_CK_623 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "CP_CK_623"), 0);
                        obj.CP_CK_627 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "CP_CK_627"), 0);
                        obj.DO_DANG_CK = Utils.CDblDef(gridView1.GetRowCellValue(pos, "DO_DANG_CK"), 0);
                        obj.LAI_GOP = Utils.CDblDef(gridView1.GetRowCellValue(pos, "LAI_GOP"), 0);
                        obj.TY_LE_LAI = Utils.CDblDef(gridView1.GetRowCellValue(pos, "TY_LE_LAI"), 0);
                        obj.PSNO_154 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSNO_154"), 0);
                        obj.PSCO_154 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSCO_154"), 0);
                        obj.GIA_VON_DK = Utils.CIntDef(gridView1.GetRowCellValue(pos, "GIA_VON_DK"), 0);
                        obj.GIA_VON_TK = Utils.CIntDef(gridView1.GetRowCellValue(pos, "GIA_VON_TK"), 0);
                        obj.GIA_VON_CK = Utils.CIntDef(gridView1.GetRowCellValue(pos, "GIA_VON_CK"), 0);
                        obj.TK_DO_DANG = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_DO_DANG"), "");
                        obj.TK_GIA_VON = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_GIA_VON"), "");
                        obj.TY_LE_PB = Utils.CIntDef(gridView1.GetRowCellValue(pos, "TY_LE_PB"), 0);
                        obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DANH_DAU"), "");
                        obj.GIA_VON_LK = Utils.CDblDef(gridView1.GetRowCellValue(pos, "GIA_VON_LK"), 0);
                        obj.PSCO_154_MTC = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSCO_154_MTC"), 0);
                        obj.PSCO_154_NC = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSCO_154_NC"), 0);
                        obj.PSCO_154_NVL = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSCO_154_NVL"), 0);
                        obj.PSCO_154_SXC = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSCO_154_SXC"), 0);
                        obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(pos, "TRANG_THAI"), 0);

                        _KTGTCTTHANGRepo.Update(obj);
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
                _KTGTCTTHANGRepo = new KTGTCTTHANGRepo();
                int id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                KT_GTCT_THANG obj = _KTGTCTTHANGRepo.GetById(id);
                if (obj != null)
                {
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "").Trim() == "T" ? "" : "T";
                    _KTGTCTTHANGRepo.Update(obj);
                }
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
                    _KTGTCTTHANGRepo = new KTGTCTTHANGRepo();
                    KT_GTCT_THANG obj = new KT_GTCT_THANG();

                    obj.THANG = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "THANG"), 0);
                    obj.MA_CT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_CT"), "");
                    obj.TEN_CT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_CT"), "");
                    obj.HOAN_THANH = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HOAN_THANH"), 0);
                    DateTime? temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_HD"), DateTime.MinValue);
                    obj.NGAY_HD = temp;
                    obj.SO_HD = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_HD"), "");
                    obj.NOI_DUNG = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NOI_DUNG"), "");
                    obj.GIA_TRI = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GIA_TRI"), 0);
                    obj.GIA_TRI_NT = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GIA_TRI_NT"), 0);
                    obj.SO_NGAY_LAM = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_NGAY_LAM"), 0);
                    temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_NT"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_NT"), DateTime.MinValue);
                    obj.NGAY_NT = temp;
                    temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_KC"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_KC"), DateTime.MinValue);
                    obj.NGAY_KC = temp;
                    obj.CP_DK_621 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CP_DK_621"), 0);
                    obj.CP_DK_622 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CP_DK_622"), 0);
                    obj.CP_DK_623 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CP_DK_623"), 0);
                    obj.CP_DK_627 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CP_DK_627"), 0);
                    obj.DO_DANG_DK = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DO_DANG_DK"), 0);
                    obj.DOANH_THU_DK = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DOANH_THU_DK"), 0);
                    obj.DOANH_THU_TK = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DOANH_THU_TK"), 0);
                    obj.DOANH_THU_LK = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DOANH_THU_LK"), 0);
                    obj.DOANH_THU_CK = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DOANH_THU_CK"), 0);
                    obj.THUE_VAT_DK = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "THUE_VAT_DK"), 0);
                    obj.THUE_VAT_TK = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "THUE_VAT_TK"), 0);
                    obj.THUE_VAT_CK = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "THUE_VAT_CK"), 0);
                    obj.DS_HD_DK = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DS_HD_DK"), "");
                    obj.DS_HD_TK = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DS_HD_TK"), "");
                    obj.PSTK_621 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSTK_621"), 0);
                    obj.PSTK_622 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSTK_622"), 0);
                    obj.PSTK_623 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSTK_623"), 0);
                    obj.PSTK_627 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSTK_627"), 0);
                    obj.PSTK_TONG = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSTK_TONG"), 0);
                    obj.PSLK_621 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSLK_621"), 0);
                    obj.PSLK_622 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSLK_622"), 0);
                    obj.PSLK_623 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSLK_623"), 0);
                    obj.PSLK_627 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSLK_627"), 0);
                    obj.TONG_CP = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TONG_CP"), 0);
                    obj.CP_CK_621 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CP_CK_621"), 0);
                    obj.CP_CK_622 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CP_CK_622"), 0);
                    obj.CP_CK_623 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CP_CK_623"), 0);
                    obj.CP_CK_627 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CP_CK_627"), 0);
                    obj.DO_DANG_CK = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DO_DANG_CK"), 0);
                    obj.LAI_GOP = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LAI_GOP"), 0);
                    obj.TY_LE_LAI = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TY_LE_LAI"), 0);
                    obj.PSNO_154 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSNO_154"), 0);
                    obj.PSCO_154 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSCO_154"), 0);
                    obj.GIA_VON_DK = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GIA_VON_DK"), 0);
                    obj.GIA_VON_TK = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GIA_VON_TK"), 0);
                    obj.GIA_VON_CK = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GIA_VON_CK"), 0);
                    obj.TK_DO_DANG = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_DO_DANG"), "");
                    obj.TK_GIA_VON = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_GIA_VON"), "");
                    obj.TY_LE_PB = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TY_LE_PB"), 0);
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "");
                    obj.GIA_VON_LK = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GIA_VON_LK"), 0);
                    obj.PSCO_154_MTC = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSCO_154_MTC"), 0);
                    obj.PSCO_154_NC = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSCO_154_NC"), 0);
                    obj.PSCO_154_NVL = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSCO_154_NVL"), 0);
                    obj.PSCO_154_SXC = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSCO_154_SXC"), 0);
                    obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TRANG_THAI"), 0);

                    _KTGTCTTHANGRepo.Create(obj);
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

                int id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"), 0);
                _KTGTCTTHANGRepo = new KTGTCTTHANGRepo();
                _KTGTCTTHANGRepo.Remove(id);

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
            _unit.Get_ColorTick(gridView1, sender, e);
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

                //validation
                GridColumn thangCol = view.Columns["THANG"];
                GridColumn ma_ctCol = view.Columns["MA_CT"];
                string thang = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, thangCol), "");
                string ma_ct = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, ma_ctCol), "");
                if (thang.Trim().Length == 0 || ma_ct.Trim().Length == 0)
                {
                    e.Valid = false;
                    if (thang.Trim().Length == 0)
                        view.SetColumnError(thangCol, "Tháng không được rổng");
                    if (ma_ct.Trim().Length == 0)
                        view.SetColumnError(ma_ctCol, "Mã công trình không được rổng");

                    return;
                }

                _KTGTCTTHANGRepo = new KTGTCTTHANGRepo();
                //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
                if (view.IsNewItemRow(e.RowHandle))
                {
                    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại
                    KT_GTCT_THANG obj = new KT_GTCT_THANG();

                    obj.THANG = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "THANG"), 0);
                    obj.MA_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_CT"), "");
                    obj.TEN_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_CT"), "");
                    obj.HOAN_THANH = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "HOAN_THANH"), 0);
                    DateTime? temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue);
                    obj.NGAY_HD = temp;
                    obj.SO_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HD"), "");
                    obj.NOI_DUNG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NOI_DUNG"), "");
                    obj.GIA_TRI = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GIA_TRI"), 0);
                    obj.GIA_TRI_NT = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GIA_TRI_NT"), 0);
                    obj.SO_NGAY_LAM = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "SO_NGAY_LAM"), 0);
                    temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_NT"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_NT"), DateTime.MinValue);
                    obj.NGAY_NT = temp;
                    temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KC"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KC"), DateTime.MinValue);
                    obj.NGAY_KC = temp;
                    obj.CP_DK_621 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_DK_621"), 0);
                    obj.CP_DK_622 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_DK_622"), 0);
                    obj.CP_DK_623 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_DK_623"), 0);
                    obj.CP_DK_627 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_DK_627"), 0);
                    obj.DO_DANG_DK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DO_DANG_DK"), 0);
                    obj.DOANH_THU_DK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DOANH_THU_DK"), 0);
                    obj.DOANH_THU_TK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DOANH_THU_TK"), 0);
                    obj.DOANH_THU_LK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DOANH_THU_LK"), 0);
                    obj.DOANH_THU_CK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DOANH_THU_CK"), 0);
                    obj.THUE_VAT_DK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THUE_VAT_DK"), 0);
                    obj.THUE_VAT_TK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THUE_VAT_TK"), 0);
                    obj.THUE_VAT_CK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THUE_VAT_CK"), 0);
                    obj.DS_HD_DK = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DS_HD_DK"), "");
                    obj.DS_HD_TK = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DS_HD_TK"), "");
                    obj.PSTK_621 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_621"), 0);
                    obj.PSTK_622 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_622"), 0);
                    obj.PSTK_623 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_623"), 0);
                    obj.PSTK_627 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_627"), 0);
                    obj.PSTK_TONG = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_TONG"), 0);
                    obj.PSLK_621 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSLK_621"), 0);
                    obj.PSLK_622 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSLK_622"), 0);
                    obj.PSLK_623 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSLK_623"), 0);
                    obj.PSLK_627 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSLK_627"), 0);
                    obj.TONG_CP = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TONG_CP"), 0);
                    obj.CP_CK_621 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_CK_621"), 0);
                    obj.CP_CK_622 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_CK_622"), 0);
                    obj.CP_CK_623 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_CK_623"), 0);
                    obj.CP_CK_627 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_CK_627"), 0);
                    obj.DO_DANG_CK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DO_DANG_CK"), 0);
                    obj.LAI_GOP = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "LAI_GOP"), 0);
                    obj.TY_LE_LAI = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TY_LE_LAI"), 0);
                    obj.PSNO_154 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSNO_154"), 0);
                    obj.PSCO_154 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSCO_154"), 0);
                    obj.GIA_VON_DK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "GIA_VON_DK"), 0);
                    obj.GIA_VON_TK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "GIA_VON_TK"), 0);
                    obj.GIA_VON_CK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "GIA_VON_CK"), 0);
                    obj.TK_DO_DANG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_DO_DANG"), "");
                    obj.TK_GIA_VON = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_GIA_VON"), "");
                    obj.TY_LE_PB = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TY_LE_PB"), 0);
                    obj.DANH_DAU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DANH_DAU"), "");
                    obj.GIA_VON_LK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GIA_VON_LK"), 0);
                    obj.PSCO_154_MTC = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSCO_154_MTC"), 0);
                    obj.PSCO_154_NC = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSCO_154_NC"), 0);
                    obj.PSCO_154_NVL = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSCO_154_NVL"), 0);
                    obj.PSCO_154_SXC = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSCO_154_SXC"), 0);
                    obj.TRANG_THAI = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TRANG_THAI"), 0);


                    _KTGTCTTHANGRepo.Create(obj);

                }
                //Cũ thì update
                else
                {
                    int id = Utils.CIntDef(view.GetRowCellValue(gridView1.FocusedRowHandle, "ID"), 0);
                    KT_GTCT_THANG obj = _KTGTCTTHANGRepo.GetById(id);
                    if (obj != null)
                    {
                        obj.THANG = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "THANG"), 0);
                        obj.MA_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_CT"), "");
                        obj.TEN_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_CT"), "");
                        obj.HOAN_THANH = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "HOAN_THANH"), 0);
                        DateTime? temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue);
                        obj.NGAY_HD = temp;
                        obj.SO_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HD"), "");
                        obj.NOI_DUNG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NOI_DUNG"), "");
                        obj.GIA_TRI = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GIA_TRI"), 0);
                        obj.GIA_TRI_NT = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GIA_TRI_NT"), 0);
                        obj.SO_NGAY_LAM = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "SO_NGAY_LAM"), 0);
                        temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_NT"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_NT"), DateTime.MinValue);
                        obj.NGAY_NT = temp;
                        temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KC"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KC"), DateTime.MinValue);
                        obj.NGAY_KC = temp;
                        obj.CP_DK_621 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_DK_621"), 0);
                        obj.CP_DK_622 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_DK_622"), 0);
                        obj.CP_DK_623 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_DK_623"), 0);
                        obj.CP_DK_627 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_DK_627"), 0);
                        obj.DO_DANG_DK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DO_DANG_DK"), 0);
                        obj.DOANH_THU_DK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DOANH_THU_DK"), 0);
                        obj.DOANH_THU_TK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DOANH_THU_TK"), 0);
                        obj.DOANH_THU_LK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DOANH_THU_LK"), 0);
                        obj.DOANH_THU_CK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DOANH_THU_CK"), 0);
                        obj.THUE_VAT_DK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THUE_VAT_DK"), 0);
                        obj.THUE_VAT_TK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THUE_VAT_TK"), 0);
                        obj.THUE_VAT_CK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THUE_VAT_CK"), 0);
                        obj.DS_HD_DK = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DS_HD_DK"), "");
                        obj.DS_HD_TK = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DS_HD_TK"), "");
                        obj.PSTK_621 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_621"), 0);
                        obj.PSTK_622 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_622"), 0);
                        obj.PSTK_623 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_623"), 0);
                        obj.PSTK_627 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_627"), 0);
                        obj.PSTK_TONG = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_TONG"), 0);
                        obj.PSLK_621 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSLK_621"), 0);
                        obj.PSLK_622 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSLK_622"), 0);
                        obj.PSLK_623 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSLK_623"), 0);
                        obj.PSLK_627 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSLK_627"), 0);
                        obj.TONG_CP = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TONG_CP"), 0);
                        obj.CP_CK_621 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_CK_621"), 0);
                        obj.CP_CK_622 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_CK_622"), 0);
                        obj.CP_CK_623 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_CK_623"), 0);
                        obj.CP_CK_627 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CP_CK_627"), 0);
                        obj.DO_DANG_CK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DO_DANG_CK"), 0);
                        obj.LAI_GOP = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "LAI_GOP"), 0);
                        obj.TY_LE_LAI = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TY_LE_LAI"), 0);
                        obj.PSNO_154 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSNO_154"), 0);
                        obj.PSCO_154 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSCO_154"), 0);
                        obj.GIA_VON_DK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "GIA_VON_DK"), 0);
                        obj.GIA_VON_TK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "GIA_VON_TK"), 0);
                        obj.GIA_VON_CK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "GIA_VON_CK"), 0);
                        obj.TK_DO_DANG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_DO_DANG"), "");
                        obj.TK_GIA_VON = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_GIA_VON"), "");
                        obj.TY_LE_PB = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TY_LE_PB"), 0);
                        obj.DANH_DAU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DANH_DAU"), "");
                        obj.GIA_VON_LK = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GIA_VON_LK"), 0);
                        obj.PSCO_154_MTC = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSCO_154_MTC"), 0);
                        obj.PSCO_154_NC = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSCO_154_NC"), 0);
                        obj.PSCO_154_NVL = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSCO_154_NVL"), 0);
                        obj.PSCO_154_SXC = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSCO_154_SXC"), 0);
                        obj.TRANG_THAI = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TRANG_THAI"), 0);

                        _KTGTCTTHANGRepo.Update(obj);
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
            txtMonth.Text = Utils.CStrDef(fTerm._month,"");
            txtYear.Text = Utils.CStrDef(fTerm._year, "");
            txtDatabase.Text = Unit.Get_DatabaseName();
            txtCompanyName.Text = Unit.Get_CompanyName();
            txtNumRows.Text = Utils.CStrDef(gridView1.RowCount, "0") + " of " + Utils.CStrDef(gridView1.RowCount, "0");
        }
        private void Load_InfoRows()
        {
            //string[] _arr = {"SO_KU","SO_HD","MA_TK", "MA_DTPN"};
            txtInfoRows.Text = Unit.Get_InfoRows(gridView1, null);
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
                btnExit_Click(null, null); return true;
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