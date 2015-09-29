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
using DevExpress.XtraGrid.Views.Base;
using ketoansoft.app.UIs;
namespace ketoansoft.app
{
    public partial class DoiTuongPhapNhan : DevComponents.DotNetBar.Metro.MetroForm
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTDTPNRepo _KTDTPNRepo = new KTDTPNRepo();
        private Unit _unit = new Unit();
        private List<int> _listUpdate = new List<int>();

        public DoiTuongPhapNhan()
        {
            InitializeComponent();
        }
        
        #region Data
        private void Load_Data()
        {
            try
            {
                _KTDTPNRepo = new KTDTPNRepo();
                gridData.DataSource = _KTDTPNRepo.GetAll();
                //_db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
                //gridData.DataSource = null;
                //gridData.DataSource = _db.KT_DTPNs;
                //gridData.RefreshDataSource();
                //gridView1.RefreshData();
            }
            catch (Exception) { }
        }
        private void Save_Data(bool msg)
        {
            try
            {
                _KTDTPNRepo = new KTDTPNRepo();
                int i = 0;
                foreach (int pos in _listUpdate)
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(pos, "ID"), 0);
                    KT_DTPN obj = _KTDTPNRepo.GetById(id);
                    if (obj != null)
                    {
                        obj.MA_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_DTPN"), "");
                        obj.TEN_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_DTPN"), "");
                        obj.DIA_CHI = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DIA_CHI"), "");
                        obj.DIA_CHI_GH = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DIA_CHI_GH"), "");
                        obj.MA_SO_THUE = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_SO_THUE"), "");
                        obj.LIEN_HE = Utils.CStrDef(gridView1.GetRowCellValue(pos, "LIEN_HE"), "");
                        obj.DIEN_THOAI = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DIEN_THOAI"), "");
                        obj.TK_NH = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TK_NH"), "");
                        obj.TEN_TKNH = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_TKNH"), "");
                        obj.MA_TT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_TT"), "");
                        obj.TEN_TT = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_TT"), "");
                        obj.MA_NHOM = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_NHOM"), "");
                        obj.TEN_NHOM = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_NHOM"), "");
                        obj.CK_PT = Utils.CDblDef(gridView1.GetRowCellValue(pos, "CK_PT"), 0);
                        obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DANH_DAU"), "");
                        obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(pos, "TRANG_THAI"), 0);

                        _KTDTPNRepo.Update(obj);
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
                _KTDTPNRepo = new KTDTPNRepo();
                int _id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                KT_DTPN obj = _KTDTPNRepo.GetById(_id);
                if (obj != null)
                {
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "").Trim() == "T" ? "" : "T";
                    _KTDTPNRepo.Update(obj);
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
                    _KTDTPNRepo = new KTDTPNRepo();
                    KT_DTPN obj = new KT_DTPN();
                    obj.MA_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_DTPN"), "");
                    obj.TEN_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_DTPN"), "");
                    obj.DIA_CHI = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DIA_CHI"), "");
                    obj.DIA_CHI_GH = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DIA_CHI_GH"), "");
                    obj.MA_SO_THUE = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_SO_THUE"), "");
                    obj.LIEN_HE = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LIEN_HE"), "");
                    obj.DIEN_THOAI = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DIEN_THOAI"), "");
                    obj.TK_NH = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TK_NH"), "");
                    obj.TEN_TKNH = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_TKNH"), "");
                    obj.MA_TT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_TT"), "");
                    obj.TEN_TT = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_TT"), "");
                    obj.MA_NHOM = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_NHOM"), "");
                    obj.TEN_NHOM = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_NHOM"), "");
                    obj.CK_PT = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CK_PT"), 0);
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "");
                    obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TRANG_THAI"), 0);

                    _KTDTPNRepo.Create(obj);
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

                _KTDTPNRepo = new KTDTPNRepo();
                int Id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"), 0);
                _KTDTPNRepo.Remove(Id);
                //string Id2 = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_DTPN"), "");
                //MessageBox.Show("Xóa dòng ID:" + Id2 + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            Load_InfoRows();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                _KTDTPNRepo = new KTDTPNRepo();
                //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
                if (view.IsNewItemRow(e.RowHandle))
                {
                    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại
                    KT_DTPN obj = new KT_DTPN();
                    obj.MA_DTPN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_DTPN"), "");
                    obj.TEN_DTPN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_DTPN"), "");
                    obj.DIA_CHI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DIA_CHI"), "");
                    obj.DIA_CHI_GH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DIA_CHI_GH"), "");
                    obj.MA_SO_THUE = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_SO_THUE"), "");
                    obj.LIEN_HE = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "LIEN_HE"), "");
                    obj.DIEN_THOAI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DIEN_THOAI"), "");
                    obj.TK_NH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_NH"), "");
                    obj.TEN_TKNH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_TKNH"), "");
                    obj.MA_TT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_TT"), "");
                    obj.TEN_TT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_TT"), "");
                    obj.MA_NHOM = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_NHOM"), "");
                    obj.TEN_NHOM = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_NHOM"), "");
                    obj.CK_PT = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CK_PT"), 0);
                    obj.DANH_DAU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DANH_DAU"), "");
                    obj.TRANG_THAI = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TRANG_THAI"), 0);

                    _KTDTPNRepo.Create(obj);
                }
                //Cũ thì update
                else
                {
                    int id = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "ID"), 0);
                    KT_DTPN obj = _KTDTPNRepo.GetById(id);
                    if (obj != null)
                    {
                        obj.MA_DTPN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_DTPN"), "");
                        obj.TEN_DTPN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_DTPN"), "");
                        obj.DIA_CHI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DIA_CHI"), "");
                        obj.DIA_CHI_GH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DIA_CHI_GH"), "");
                        obj.MA_SO_THUE = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_SO_THUE"), "");
                        obj.LIEN_HE = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "LIEN_HE"), "");
                        obj.DIEN_THOAI = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DIEN_THOAI"), "");
                        obj.TK_NH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TK_NH"), "");
                        obj.TEN_TKNH = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_TKNH"), "");
                        obj.MA_TT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_TT"), "");
                        obj.TEN_TT = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_TT"), "");
                        obj.MA_NHOM = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_NHOM"), "");
                        obj.TEN_NHOM = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_NHOM"), "");
                        obj.CK_PT = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "CK_PT"), 0);
                        obj.DANH_DAU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DANH_DAU"), "");
                        obj.TRANG_THAI = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TRANG_THAI"), 0);

                        _KTDTPNRepo.Update(obj);
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
        private void btnNew_Click(object sender, EventArgs e)
        {
            ThemDoiTuongPhapNhan t = new ThemDoiTuongPhapNhan();
            t.ShowDialog();
            Load_Data();
            t.Dispose();
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
        
        #region Form function
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!e.Cancel)
            {
                if (MessageBox.Show("Bạn có muốn đóng form Đối Tượng Pháp Nhân không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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
            string[] _arr = { "MA_DTPN", "TEN_DTPN" };
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
            else if (e.KeyCode == Keys.N && e.Control)
            {
                btnNew_Click(null, null); return true;
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