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
    public partial class XemBangPhanBoChiPhiChung : DevComponents.DotNetBar.Metro.MetroForm
    {
        dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTCTPBCPRepo _KTCTPBCPRepo = new KTCTPBCPRepo();
        public Unit _unit = new Unit();
        private List<int> _listUpdate = new List<int>();

        public XemBangPhanBoChiPhiChung()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Data()
        {
            try
            {
                _KTCTPBCPRepo = new KTCTPBCPRepo();
                gridData.DataSource = _KTCTPBCPRepo.GetAll();
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
                _KTCTPBCPRepo = new KTCTPBCPRepo();
                int i = 0;
                foreach (int pos in _listUpdate)
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(pos, "ID"), 0);
                    KT_CTPBCP obj = _KTCTPBCPRepo.GetById(id);
                    if (obj != null)
                    {
                        obj.THANG = Utils.CIntDef(gridView1.GetRowCellValue(pos, "THANG"), 0);
                        obj.MA_CT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_CT"), "");
                        obj.TEN_CT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_CT"), "");
                        obj.SO_HD = Utils.CStrDef(gridView1.GetRowCellValue(pos, "SO_HD"), "");
                        obj.NOI_DUNG = Utils.CStrDef(gridView1.GetRowCellValue(pos, "NOI_DUNG"), "");
                        obj.SR_HOADON = Utils.CStrDef(gridView1.GetRowCellValue(pos, "SR_HOADON"), "");
                        obj.SO_HOADON = Utils.CStrDef(gridView1.GetRowCellValue(pos, "SO_HOADON"), "");
                        DateTime? temp =null;
                        if(Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_HOADON"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_HOADON"), DateTime.MinValue);
                        obj.NGAY_HOADON = temp;
                        obj.SO_CT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "SO_CT"), "");
                        temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_CT"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_CT"), DateTime.MinValue);
                        obj.NGAY_CT = temp;
                        obj.DIEN_GIAI = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DIEN_GIAI"), "");
                        obj.TK_NO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_NO"), "");
                        obj.DTPN_NO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DTPN_NO"), "");
                        obj.YTCP_NO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "YTCP_NO"), "");
                        obj.MA_DM_NO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_DM_NO"), "");
                        obj.LO_NHAP = Utils.CStrDef(gridView1.GetRowCellValue(pos, "LO_NHAP"), "");
                        obj.TK_CO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_CO"), "");
                        obj.DTPN_CO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DTPN_CO"), "");
                        obj.YTCP_CO = Utils.CStrDef(gridView1.GetRowCellValue(pos, "YTCP_CO"), "");
                        obj.MA_HH_XUAT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_HH_XUAT"), "");
                        obj.LO_XUAT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "LO_XUAT"), "");
                        obj.TEN_DM = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_DM"), "");
                        obj.DON_VI = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DON_VI"), "");
                        obj.SL = Utils.CDblDef(gridView1.GetRowCellValue(pos, "SL"), 0);
                        obj.DON_GIA = Utils.CDblDef(gridView1.GetRowCellValue(pos, "DON_GIA"), 0);
                        obj.THANH_TIEN_VND = Utils.CDblDef(gridView1.GetRowCellValue(pos, "THANH_TIEN_VND"), 0);
                        obj.TY_GIA = Utils.CDblDef(gridView1.GetRowCellValue(pos, "TY_GIA"), 0);
                        obj.THANH_TIEN_USD = Utils.CDblDef(gridView1.GetRowCellValue(pos, "THANH_TIEN_USD"), 0);
                        obj.MA_KH = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_KH"), "");
                        obj.TEN_KH = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_KH"), "");
                        obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DANH_DAU"), "");
                        obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(pos, "TRANG_THAI"), 0);
                        obj.TIEN_THUE_USD = Utils.CDblDef(gridView1.GetRowCellValue(pos, "TIEN_THUE_USD"), 0);
                        obj.TIEN_THUE_VND = Utils.CDblDef(gridView1.GetRowCellValue(pos, "TIEN_THUE_VND"), 0);
                        obj.THUE_NK_USD = Utils.CDblDef(gridView1.GetRowCellValue(pos, "THUE_NK_USD"), 0);
                        obj.THUE_NK_VND = Utils.CDblDef(gridView1.GetRowCellValue(pos, "THUE_NK_VND"), 0);
                        
                        _KTCTPBCPRepo.Update(obj);
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
                _KTCTPBCPRepo = new KTCTPBCPRepo();
                int id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                KT_CTPBCP obj = _KTCTPBCPRepo.GetById(id);
                if (obj != null)
                {
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "").Trim() == "T" ? "" : "T";
                    _KTCTPBCPRepo.Update(obj);
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
                    _KTCTPBCPRepo = new KTCTPBCPRepo();
                    KT_CTPBCP obj = new KT_CTPBCP();

                    obj.THANG = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "THANG"), 0);
                    obj.MA_CT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_CT"), "");
                    obj.TEN_CT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_CT"), "");
                    obj.SO_HD = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_HD"), "");
                    obj.NOI_DUNG = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NOI_DUNG"), "");
                    obj.SR_HOADON = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SR_HOADON"), "");
                    obj.SO_HOADON = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_HOADON"), "");
                    DateTime? temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_HOADON"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_HOADON"), DateTime.MinValue);
                    obj.NGAY_HOADON = temp;
                    obj.SO_CT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_CT"), "");
                    temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_CT"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_CT"), DateTime.MinValue);
                    obj.NGAY_CT = temp;
                    obj.DIEN_GIAI = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DIEN_GIAI"), "");
                    obj.TK_NO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_NO"), "");
                    obj.DTPN_NO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DTPN_NO"), "");
                    obj.YTCP_NO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YTCP_NO"), "");
                    obj.MA_DM_NO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_DM_NO"), "");
                    obj.LO_NHAP = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LO_NHAP"), "");
                    obj.TK_CO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_CO"), "");
                    obj.DTPN_CO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DTPN_CO"), "");
                    obj.YTCP_CO = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YTCP_CO"), "");
                    obj.MA_HH_XUAT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_HH_XUAT"), "");
                    obj.LO_XUAT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LO_XUAT"), "");
                    obj.TEN_DM = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_DM"), "");
                    obj.DON_VI = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DON_VI"), "");
                    obj.SL = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SL"), 0);
                    obj.DON_GIA = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DON_GIA"), 0);
                    obj.THANH_TIEN_VND = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "THANH_TIEN_VND"), 0);
                    obj.TY_GIA = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TY_GIA"), 0);
                    obj.THANH_TIEN_USD = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "THANH_TIEN_USD"), 0);
                    obj.MA_KH = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_KH"), "");
                    obj.TEN_KH = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_KH"), "");
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "");
                    obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TRANG_THAI"), 0);
                    obj.TIEN_THUE_USD = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TIEN_THUE_USD"), 0);
                    obj.TIEN_THUE_VND = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TIEN_THUE_VND"), 0);
                    obj.THUE_NK_USD = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "THUE_NK_USD"), 0);
                    obj.THUE_NK_VND = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "THUE_NK_VND"), 0);

                    _KTCTPBCPRepo.Create(obj);
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
                _KTCTPBCPRepo = new KTCTPBCPRepo();
                _KTCTPBCPRepo.Remove(id);

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

                ////validation
                //GridColumn thangCol = view.Columns["THANG"];
                //GridColumn ma_ctCol = view.Columns["MA_CT"];
                //string thang = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, thangCol), "");
                //string ma_ct = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, ma_ctCol), "");
                //if (thang.Trim().Length == 0 || ma_ct.Trim().Length == 0)
                //{
                //    e.Valid = false;
                //    if (thang.Trim().Length == 0)
                //        view.SetColumnError(thangCol, "Tháng không được rổng");
                //    if (ma_ct.Trim().Length == 0)
                //        view.SetColumnError(ma_ctCol, "Mã chương trình không được rổng");

                //    return;
                //}

                _KTCTPBCPRepo = new KTCTPBCPRepo();
                //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
                if (view.IsNewItemRow(e.RowHandle))
                {
                    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại
                    KT_CTPBCP obj = new KT_CTPBCP();

                    obj.THANG = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "THANG"), 0);
                    obj.MA_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_CT"), "");
                    obj.TEN_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_CT"), "");
                    obj.SO_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HD"), "");
                    obj.NOI_DUNG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NOI_DUNG"), "");
                    obj.SR_HOADON = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SR_HOADON"), "");
                    obj.SO_HOADON = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HOADON"), "");
                    DateTime? temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HOADON"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HOADON"), DateTime.MinValue);
                    obj.NGAY_HOADON = temp;
                    obj.SO_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_CT"), "");
                    temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_CT"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_CT"), DateTime.MinValue);
                    obj.NGAY_CT = temp;
                    obj.DIEN_GIAI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DIEN_GIAI"), "");
                    obj.TK_NO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_NO"), "");
                    obj.DTPN_NO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DTPN_NO"), "");
                    obj.YTCP_NO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "YTCP_NO"), "");
                    obj.MA_DM_NO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_DM_NO"), "");
                    obj.LO_NHAP = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "LO_NHAP"), "");
                    obj.TK_CO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_CO"), "");
                    obj.DTPN_CO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DTPN_CO"), "");
                    obj.YTCP_CO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "YTCP_CO"), "");
                    obj.MA_HH_XUAT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_HH_XUAT"), "");
                    obj.LO_XUAT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "LO_XUAT"), "");
                    obj.TEN_DM = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_DM"), "");
                    obj.DON_VI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DON_VI"), "");
                    obj.SL = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "SL"), 0);
                    obj.DON_GIA = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DON_GIA"), 0);
                    obj.THANH_TIEN_VND = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THANH_TIEN_VND"), 0);
                    obj.TY_GIA = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TY_GIA"), 0);
                    obj.THANH_TIEN_USD = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THANH_TIEN_USD"), 0);
                    obj.MA_KH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_KH"), "");
                    obj.TEN_KH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_KH"), "");
                    obj.DANH_DAU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DANH_DAU"), "");
                    obj.TRANG_THAI = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TRANG_THAI"), 0);
                    obj.TIEN_THUE_USD = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TIEN_THUE_USD"), 0);
                    obj.TIEN_THUE_VND = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TIEN_THUE_VND"), 0);
                    obj.THUE_NK_USD = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THUE_NK_USD"), 0);
                    obj.THUE_NK_VND = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THUE_NK_VND"), 0);

                    _KTCTPBCPRepo.Create(obj);

                }
                //Cũ thì update
                else
                {
                    int id = Utils.CIntDef(view.GetRowCellValue(gridView1.FocusedRowHandle, "ID"), 0);
                    KT_CTPBCP obj = _KTCTPBCPRepo.GetById(id);
                    if (obj != null)
                    {
                        obj.THANG = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "THANG"), 0);
                        obj.MA_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_CT"), "");
                        obj.TEN_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_CT"), "");
                        obj.SO_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HD"), "");
                        obj.NOI_DUNG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NOI_DUNG"), "");
                        obj.SR_HOADON = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SR_HOADON"), "");
                        obj.SO_HOADON = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HOADON"), "");
                        DateTime? temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HOADON"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HOADON"), DateTime.MinValue);
                        obj.NGAY_HOADON = temp;
                        obj.SO_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_CT"), "");
                        temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_CT"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_CT"), DateTime.MinValue);
                        obj.NGAY_CT = temp;
                        obj.DIEN_GIAI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DIEN_GIAI"), "");
                        obj.TK_NO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_NO"), "");
                        obj.DTPN_NO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DTPN_NO"), "");
                        obj.YTCP_NO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "YTCP_NO"), "");
                        obj.MA_DM_NO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_DM_NO"), "");
                        obj.LO_NHAP = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "LO_NHAP"), "");
                        obj.TK_CO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_CO"), "");
                        obj.DTPN_CO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DTPN_CO"), "");
                        obj.YTCP_CO = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "YTCP_CO"), "");
                        obj.MA_HH_XUAT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_HH_XUAT"), "");
                        obj.LO_XUAT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "LO_XUAT"), "");
                        obj.TEN_DM = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_DM"), "");
                        obj.DON_VI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DON_VI"), "");
                        obj.SL = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "SL"), 0);
                        obj.DON_GIA = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DON_GIA"), 0);
                        obj.THANH_TIEN_VND = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THANH_TIEN_VND"), 0);
                        obj.TY_GIA = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TY_GIA"), 0);
                        obj.THANH_TIEN_USD = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THANH_TIEN_USD"), 0);
                        obj.MA_KH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_KH"), "");
                        obj.TEN_KH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_KH"), "");
                        obj.DANH_DAU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DANH_DAU"), "");
                        obj.TRANG_THAI = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TRANG_THAI"), 0);
                        obj.TIEN_THUE_USD = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TIEN_THUE_USD"), 0);
                        obj.TIEN_THUE_VND = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TIEN_THUE_VND"), 0);
                        obj.THUE_NK_USD = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THUE_NK_USD"), 0);
                        obj.THUE_NK_VND = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "THUE_NK_VND"), 0);

                        _KTCTPBCPRepo.Update(obj);
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