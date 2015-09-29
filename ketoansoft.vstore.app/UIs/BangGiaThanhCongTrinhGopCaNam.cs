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
    public partial class BangGiaThanhCongTrinhGopCaNam : DevComponents.DotNetBar.Metro.MetroForm
    {
        dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTGTCTRepo _KTGTCTRepo = new KTGTCTRepo();
        public Unit _unit = new Unit();
        private List<int> _listUpdate = new List<int>();

        public BangGiaThanhCongTrinhGopCaNam()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Data()
        {
            try
            {
                _KTGTCTRepo = new KTGTCTRepo();
                gridData.DataSource = _KTGTCTRepo.GetAll();
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
                _KTGTCTRepo = new KTGTCTRepo();
                int i = 0;
                foreach (int pos in _listUpdate)
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(pos, "ID"), 0);
                    KT_GTCT obj = _KTGTCTRepo.GetById(id);
                    if (obj != null)
                    {
                        obj.THANG = Utils.CIntDef(gridView1.GetRowCellValue(pos, "THANG"), 0);
                        obj.MA_CT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_CT"), "");
                        obj.TEN_CT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_CT"), "");
                        obj.MA_TP = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_TP"), "");
                        obj.TEN_TP = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_TP"), "");
                        obj.SL_TP = Utils.CDblDef(gridView1.GetRowCellValue(pos, "SL_TP"), 0);
                        obj.DOANH_THU = Utils.CDblDef(gridView1.GetRowCellValue(pos, "DOANH_THU"), 0);
                        obj.DG_BAN = Utils.CDblDef(gridView1.GetRowCellValue(pos, "DG_BAN"), 0);
                        DateTime? temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_HD"), DateTime.MinValue);
                        obj.NGAY_HD = temp;
                        obj.SO_HD = Utils.CStrDef(gridView1.GetRowCellValue(pos, "SO_HD"), "");
                        obj.NOI_DUNG = Utils.CStrDef(gridView1.GetRowCellValue(pos, "NOI_DUNG"), "");
                        temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_KC"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_KC"), DateTime.MinValue);
                        obj.NGAY_KC = temp;
                        obj.PSTK_621 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSTK_621"), 0);
                        obj.PSTK_622 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSTK_622"), 0);
                        obj.PSTK_623 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSTK_623"), 0);
                        obj.PSTK_627 = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSTK_627"), 0);
                        obj.PSTK_TONG = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSTK_TONG"), 0);
                        obj.TLPB = Utils.CIntDef(gridView1.GetRowCellValue(pos, "TLPB"), 0);
                        obj.Z1TP = Utils.CIntDef(gridView1.GetRowCellValue(pos, "Z1TP"), 0);
                        obj.ZTP = Utils.CIntDef(gridView1.GetRowCellValue(pos, "ZTP"), 0);
                        obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DANH_DAU"), "");

                        _KTGTCTRepo.Update(obj);
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
                _KTGTCTRepo = new KTGTCTRepo();
                int id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                KT_GTCT obj = _KTGTCTRepo.GetById(id);
                if (obj != null)
                {
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "").Trim() == "T" ? "" : "T";
                    _KTGTCTRepo.Update(obj);
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
                    _KTGTCTRepo = new KTGTCTRepo();
                    KT_GTCT obj = new KT_GTCT();

                    obj.THANG = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "THANG"), 0);
                    obj.MA_CT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_CT"), "");
                    obj.TEN_CT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_CT"), "");
                    obj.MA_TP = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_TP"), "");
                    obj.TEN_TP = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_TP"), "");
                    obj.SL_TP = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SL_TP"), 0);
                    obj.DOANH_THU = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DOANH_THU"), 0);
                    obj.DG_BAN = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DG_BAN"), 0);
                    DateTime? temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_HD"), DateTime.MinValue);
                    obj.NGAY_HD = temp;
                    obj.SO_HD = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_HD"), "");
                    obj.NOI_DUNG = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NOI_DUNG"), "");
                    temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_KC"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_KC"), DateTime.MinValue);
                    obj.NGAY_KC = temp;
                    obj.PSTK_621 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSTK_621"), 0);
                    obj.PSTK_622 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSTK_622"), 0);
                    obj.PSTK_623 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSTK_623"), 0);
                    obj.PSTK_627 = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSTK_627"), 0);
                    obj.PSTK_TONG = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSTK_TONG"), 0);
                    obj.TLPB = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TLPB"), 0);
                    obj.Z1TP = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Z1TP"), 0);
                    obj.ZTP = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ZTP"), 0);
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "");

                    _KTGTCTRepo.Create(obj);
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
                _KTGTCTRepo = new KTGTCTRepo();
                _KTGTCTRepo.Remove(id);

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
                GridColumn ma_tpCol = view.Columns["MA_TP"];
                string thang = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, thangCol), "");
                string ma_ct = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, ma_ctCol), "");
                string ma_tp = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, ma_tpCol), "");
                if (thang.Trim().Length == 0 || ma_ct.Trim().Length == 0 || ma_tp.Trim().Length == 0)
                {
                    e.Valid = false;
                    if (thang.Trim().Length == 0)
                        view.SetColumnError(thangCol, "Tháng không được rổng");
                    if (ma_ct.Trim().Length == 0)
                        view.SetColumnError(ma_ctCol, "Mã công trình không được rổng");
                    if (ma_tp.Trim().Length == 0)
                        view.SetColumnError(ma_tpCol, "Mã thành phẩm không được rổng");

                    return;
                }

                _KTGTCTRepo = new KTGTCTRepo();
                //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
                if (view.IsNewItemRow(e.RowHandle))
                {
                    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại
                    KT_GTCT obj = new KT_GTCT();

                    obj.THANG = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "THANG"), 0);
                    obj.MA_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_CT"), "");
                    obj.TEN_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_CT"), "");
                    obj.MA_TP = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_TP"), "");
                    obj.TEN_TP = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_TP"), "");
                    obj.SL_TP = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "SL_TP"), 0);
                    obj.DOANH_THU = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DOANH_THU"), 0);
                    obj.DG_BAN = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DG_BAN"), 0);
                    DateTime? temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue);
                    obj.NGAY_HD = temp;
                    obj.SO_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HD"), "");
                    obj.NOI_DUNG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NOI_DUNG"), "");
                    temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KC"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KC"), DateTime.MinValue);
                    obj.NGAY_KC = temp;
                    obj.PSTK_621 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_621"), 0);
                    obj.PSTK_622 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_622"), 0);
                    obj.PSTK_623 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_623"), 0);
                    obj.PSTK_627 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_627"), 0);
                    obj.PSTK_TONG = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_TONG"), 0);
                    obj.TLPB = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TLPB"), 0);
                    obj.Z1TP = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "Z1TP"), 0);
                    obj.ZTP = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "ZTP"), 0);
                    obj.DANH_DAU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DANH_DAU"), "");

                    _KTGTCTRepo.Create(obj);

                }
                //Cũ thì update
                else
                {
                    int id = Utils.CIntDef(view.GetRowCellValue(gridView1.FocusedRowHandle, "ID"), 0);
                    KT_GTCT obj = _KTGTCTRepo.GetById(id);
                    if (obj != null)
                    {
                        obj.THANG = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "THANG"), 0);
                        obj.MA_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_CT"), "");
                        obj.TEN_CT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_CT"), "");
                        obj.MA_TP = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_TP"), "");
                        obj.TEN_TP = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_TP"), "");
                        obj.SL_TP = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "SL_TP"), 0);
                        obj.DOANH_THU = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DOANH_THU"), 0);
                        obj.DG_BAN = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "DG_BAN"), 0);
                        DateTime? temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue);
                        obj.NGAY_HD = temp;
                        obj.SO_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HD"), "");
                        obj.NOI_DUNG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NOI_DUNG"), "");
                        temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KC"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KC"), DateTime.MinValue);
                        obj.NGAY_KC = temp;
                        obj.PSTK_621 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_621"), 0);
                        obj.PSTK_622 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_622"), 0);
                        obj.PSTK_623 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_623"), 0);
                        obj.PSTK_627 = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_627"), 0);
                        obj.PSTK_TONG = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "PSTK_TONG"), 0);
                        obj.TLPB = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TLPB"), 0);
                        obj.Z1TP = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "Z1TP"), 0);
                        obj.ZTP = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "ZTP"), 0);
                        obj.DANH_DAU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DANH_DAU"), "");

                        _KTGTCTRepo.Update(obj);
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