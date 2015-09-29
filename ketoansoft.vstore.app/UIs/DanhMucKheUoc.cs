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
    public partial class DanhMucKheUoc : DevComponents.DotNetBar.Metro.MetroForm
    {
        dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTDMKURepo _KTDMKURepo = new KTDMKURepo();
        public Unit _unit = new Unit();
        private List<int> _listUpdate = new List<int>();

        public DanhMucKheUoc()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Data()
        {
            try
            {
                _KTDMKURepo = new KTDMKURepo();
                gridData.DataSource = _KTDMKURepo.GetAll();
                //_db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
                //gridData.DataSource = null;
                //gridData.DataSource = _db.KT_DMKUs;
                //gridData.RefreshDataSource();
                //gridView1.RefreshData();
            }
            catch (Exception) { }
        }
        private void Save_Data(bool msg)
        {
            try
            {
                _KTDMKURepo = new KTDMKURepo();
                int i = 0;
                foreach (int pos in _listUpdate)
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(pos, "ID"), 0);
                    KT_DMKU obj = _KTDMKURepo.GetById(id);
                    if (obj != null)
                    {
                        obj.SO_KU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_KU"), "");
                        obj.SO_HD = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_HD"), "");
                        obj.MA_TK = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_TK"), "");
                        obj.MA_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_DTPN"), "");
                        obj.TEN_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_DTPN"), "");
                        obj.NOI_DUNG = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NOI_DUNG"), "");
                        obj.GT_KU_VND = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GT_KU_VND"), 0);
                        obj.GT_KU_USD = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GT_KU_USD"), 0);
                        DateTime? temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_KU"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_KU"), DateTime.MinValue);
                        obj.NGAY_KU = temp;
                        temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_HD"), DateTime.MinValue);
                        obj.NGAY_HD = temp;
                        temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_DH"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_DH"), DateTime.MinValue);
                        obj.NGAY_DH = temp;
                        obj.HANMUC_VND = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HANMUC_VND"), 0);
                        obj.HANMUC_USD = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HANMUC_USD"), 0);
                        obj.LAI_SUAT_VAY = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LAI_SUAT_VAY"), 0);
                        obj.GT_HD_VND = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GT_HD_VND"), 0);
                        obj.GT_HD_USD = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GT_HD_USD"), 0);
                        obj.GHI_CHU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GHI_CHU"), "");
                        _KTDMKURepo.Update(obj);
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
                //string so_ku = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_KU").ToString(), "");
                //string so_hd = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_HD").ToString(), "");
                //string ma_tk = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_TK").ToString(), "");
                //string ma_dtpn = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_DTPN").ToString(), "");
                //KT_DMKU obj = _KTDMKURepo.GetById(so_ku, so_hd, ma_tk, ma_dtpn);
                //if (obj != null)
                //{
                //    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "").Trim() == "T" ? "" : "T";
                //    _KTDMKURepo.Update(obj);
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
                    _KTDMKURepo = new KTDMKURepo();
                    KT_DMKU obj = new KT_DMKU();
                    obj.SO_KU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_KU"), "");
                    obj.SO_HD = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_HD"), "");
                    obj.MA_TK = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_TK"), "");
                    obj.MA_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_DTPN"), "");
                    obj.TEN_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_DTPN"), "");
                    obj.NOI_DUNG = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NOI_DUNG"), "");
                    obj.GT_KU_VND = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GT_KU_VND"), 0);
                    obj.GT_KU_USD = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GT_KU_USD"), 0);
                    DateTime? temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_KU"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_KU"), DateTime.MinValue);
                    obj.NGAY_KU = temp;
                    temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_HD"), DateTime.MinValue);
                    obj.NGAY_HD = temp;
                    temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_DH"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_DH"), DateTime.MinValue);
                    obj.NGAY_DH = temp;
                    obj.HANMUC_VND = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HANMUC_VND"), 0);
                    obj.HANMUC_USD = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HANMUC_USD"), 0);
                    obj.LAI_SUAT_VAY = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LAI_SUAT_VAY"), 0);
                    obj.GT_HD_VND = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GT_HD_VND"), 0);
                    obj.GT_HD_USD = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GT_HD_USD"), 0);
                    obj.GHI_CHU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GHI_CHU"), ""); 

                    _KTDMKURepo.Create(obj);
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

                _KTDMKURepo = new KTDMKURepo();
                int id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"), 0);

                _KTDMKURepo.Remove(id);

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

                //validation
                GridColumn so_kuCol = view.Columns["SO_KU"];
                GridColumn so_hdCol = view.Columns["SO_HD"];
                GridColumn ma_tkCol = view.Columns["MA_TK"];
                GridColumn ma_dtpnCol = view.Columns["MA_DTPN"];
                string so_ku = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, so_kuCol), "");
                string so_hd = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, so_hdCol), "");
                string ma_tk = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, ma_tkCol), "");
                string ma_dtpn = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, ma_dtpnCol), "");
                if (so_ku.Trim().Length == 0 || so_hd.Trim().Length == 0 || ma_tk.Trim().Length == 0 || ma_dtpn.Trim().Length == 0)
                {
                    e.Valid = false;
                    if (so_ku.Trim().Length == 0)
                        view.SetColumnError(so_kuCol, "Số khế ước không được rổng");
                    if (so_hd.Trim().Length == 0)
                        view.SetColumnError(so_hdCol, "Số hợp đồng không được rổng");
                    if (ma_tk.Trim().Length == 0)
                        view.SetColumnError(ma_tkCol, "Mã tài khoản không được rổng");
                    if (ma_dtpn.Trim().Length == 0)
                        view.SetColumnError(ma_dtpnCol, "Mã đối tượng pháp nhân không được rổng");

                    return;
                }
                _KTDMKURepo = new KTDMKURepo();

                //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
                if (view.IsNewItemRow(e.RowHandle))
                {
                    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại
                    KT_DMKU obj = new KT_DMKU();
                    obj.SO_KU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_KU"), "");
                    obj.SO_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HD"), "");
                    obj.MA_TK = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_TK"), "");
                    obj.MA_DTPN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_DTPN"), "");
                    obj.TEN_DTPN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_DTPN"), "");
                    obj.NOI_DUNG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NOI_DUNG"), "");
                    obj.GT_KU_VND = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GT_KU_VND"), 0);
                    obj.GT_KU_USD = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GT_KU_USD"), 0);
                    DateTime? temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KU"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KU"), DateTime.MinValue);
                    obj.NGAY_KU = temp;
                    temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue);
                    obj.NGAY_HD = temp;
                    temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_DH"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_DH"), DateTime.MinValue);
                    obj.NGAY_DH = temp;
                    obj.HANMUC_VND = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "HANMUC_VND"), 0);
                    obj.HANMUC_USD = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "HANMUC_USD"), 0);
                    obj.LAI_SUAT_VAY = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "LAI_SUAT_VAY"), 0);
                    obj.GT_HD_VND = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GT_HD_VND"), 0);
                    obj.GT_HD_USD = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GT_HD_USD"), 0);
                    obj.GHI_CHU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "GHI_CHU"), "");

                    _KTDMKURepo.Create(obj);

                }
                //Cũ thì update
                else
                {
                    int id = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "ID"), 0);
                    KT_DMKU obj = _KTDMKURepo.GetById(id);
                    if (obj != null)
                    {
                        obj.SO_KU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_KU"), "");
                        obj.SO_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HD"), "");
                        obj.MA_TK = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_TK"), "");
                        obj.MA_DTPN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_DTPN"), "");
                        obj.TEN_DTPN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_DTPN"), "");
                        obj.NOI_DUNG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NOI_DUNG"), "");
                        obj.GT_KU_VND = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GT_KU_VND"), 0);
                        obj.GT_KU_USD = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GT_KU_USD"), 0);
                        DateTime? temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KU"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KU"), DateTime.MinValue);
                        obj.NGAY_KU = temp;
                        temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue);
                        obj.NGAY_HD = temp;
                        temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_DH"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_DH"), DateTime.MinValue);
                        obj.NGAY_DH = temp;
                        obj.HANMUC_VND = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "HANMUC_VND"), 0);
                        obj.HANMUC_USD = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "HANMUC_USD"), 0);
                        obj.LAI_SUAT_VAY = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "LAI_SUAT_VAY"), 0);
                        obj.GT_HD_VND = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GT_HD_VND"), 0);
                        obj.GT_HD_USD = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "GT_HD_USD"), 0);
                        obj.GHI_CHU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "GHI_CHU"), "");

                        _KTDMKURepo.Update(obj);
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
            string[] _arr = {"SO_KU","SO_HD","MA_TK", "MA_DTPN"};
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