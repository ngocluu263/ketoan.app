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

namespace ketoansoft.app
{
    public partial class KhaiBaoLuuChuyenTienTeTT : DevComponents.DotNetBar.Metro.MetroForm
    {
        dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KBLCTT_TTRepo _KBLCTT_TTRepo = new KBLCTT_TTRepo();
        public Unit _unit = new Unit();
        private List<int> _listUpdate = new List<int>();

        public KhaiBaoLuuChuyenTienTeTT()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Data()
        {
            try
            {
                _KBLCTT_TTRepo = new KBLCTT_TTRepo();
                gridData.DataSource = _KBLCTT_TTRepo.GetAll();
            }
            catch (Exception) { }
        }
        private void Get_Data(KB_LCTT_TT obj, int position)
        {
            try
            {
                obj.SAP_XEP = Utils.CStrDef(gridView1.GetRowCellValue(position, "SAP_XEP"), "");
                obj.CHI_TIEU = Utils.CStrDef(gridView1.GetRowCellValue(position, "CHI_TIEU"), "");
                obj.TEN_CT1 = Utils.CStrDef(gridView1.GetRowCellValue(position, "TEN_CT1"), "");
                obj.TEN_CT2 = Utils.CStrDef(gridView1.GetRowCellValue(position, "TEN_CT2"), "");
                obj.MA_SO = Utils.CStrDef(gridView1.GetRowCellValue(position, "MA_SO"), "");
                obj.SO_DU = Utils.CStrDef(gridView1.GetRowCellValue(position, "SO_DU"), "");
                obj.TK_NO = Utils.CStrDef(gridView1.GetRowCellValue(position, "TK_NO"), "");
                obj.TK_CO = Utils.CStrDef(gridView1.GetRowCellValue(position, "TK_CO"), "");
                obj.TT_KT_VND = Utils.CDblDef(gridView1.GetRowCellValue(position, "TT_KT_VND"), 0);
                obj.TT_KN_VND = Utils.CDblDef(gridView1.GetRowCellValue(position, "TT_KN_VND"), 0);
                obj.TT_KT_USD = Utils.CDblDef(gridView1.GetRowCellValue(position, "TT_KT_USD"), 0);
                obj.TT_KN_USD = Utils.CDblDef(gridView1.GetRowCellValue(position, "TT_KN_USD"), 0);
                obj.NHAN_VOI = Utils.CDblDef(gridView1.GetRowCellValue(position, "NHAN_VOI"), 0);
                obj.THUYET_MINH = Utils.CStrDef(gridView1.GetRowCellValue(position, "THUYET_MINH"), "");
                obj.CO_IN = Utils.CStrDef(gridView1.GetRowCellValue(position, "CO_IN"), "");
                obj.TT_LK_VND = Utils.CDblDef(gridView1.GetRowCellValue(position, "TT_LK_VND"), 0);
                obj.TT_LK_USD = Utils.CDblDef(gridView1.GetRowCellValue(position, "TT_LK_USD"), 0);
                obj.TT_NT_USD = Utils.CDblDef(gridView1.GetRowCellValue(position, "TT_NT_USD"), 0);
                obj.TT_NT_VND = Utils.CDblDef(gridView1.GetRowCellValue(position, "TT_NT_VND"), 0);
                obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(position, "DANH_DAU"), "");
                obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(position, "TRANG_THAI"), 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Save_Data(bool msg)
        {
            try
            {
                _KBLCTT_TTRepo = new KBLCTT_TTRepo();
                int i = 0;
                foreach (int pos in _listUpdate)
                {
                    string id = Utils.CStrDef(gridView1.GetRowCellValue(pos, "CHI_TIEU"), "");
                    KB_LCTT_TT obj = _KBLCTT_TTRepo.GetById(id.Trim());
                    if (obj != null)
                    {
                        Get_Data(obj, pos);
                        _KBLCTT_TTRepo.Update(obj);
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
                _KBLCTT_TTRepo = new KBLCTT_TTRepo();
                string _id = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CHI_TIEU").ToString(), "");
                KB_LCTT_TT obj = _KBLCTT_TTRepo.GetById(_id.Trim());
                if (obj != null)
                {
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "").Trim() == "T" ? "" : "T";
                    _KBLCTT_TTRepo.Update(obj);
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
                    _KBLCTT_TTRepo = new KBLCTT_TTRepo();
                    KB_LCTT_TT obj = new KB_LCTT_TT();
                    Get_Data(obj, gridView1.FocusedRowHandle);
                    _KBLCTT_TTRepo.Create(obj);
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

                _KBLCTT_TTRepo = new KBLCTT_TTRepo();
                string _id = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CHI_TIEU").ToString(), "");
                _KBLCTT_TTRepo.Remove(_id);

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
                _KBLCTT_TTRepo = new KBLCTT_TTRepo();
                //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
                if (view.IsNewItemRow(e.RowHandle))
                {
                    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại
                    KB_LCTT_TT obj = new KB_LCTT_TT();
                    Get_Data(obj, e.RowHandle);
                    _KBLCTT_TTRepo.Create(obj);

                }
                //Cũ thì update
                else
                {
                    string id = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "CHI_TIEU").ToString(), "");
                    KB_LCTT_TT obj = _KBLCTT_TTRepo.GetById(id);
                    if (obj != null)
                    {
                        Get_Data(obj, e.RowHandle);
                        _KBLCTT_TTRepo.Update(obj);
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
            string[] _arr = { "SAP_XEP", "CHI_TIEU", "TEN_CT1", "SO_DU", "TK_NO", "TK_CO" };
            txtInfoRows.Text = Unit.Get_InfoRows(gridView1, _arr);

            string[] _arrFormatNum = { "TT_KT_VND", "TT_KN_VND", "TT_KT_USD", "TT_KN_USD", "TT_LK_VND", "TT_LK_USD", "TT_NT_USD", "TT_NT_VND" };
            Unit.Get_FormatType(gridView1, _arrFormatNum, DevExpress.Utils.FormatType.Custom, "{0:###,##0}");
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
                Load_Data();
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