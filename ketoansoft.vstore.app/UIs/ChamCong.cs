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
    public partial class ChamCong : DevComponents.DotNetBar.Metro.MetroForm
    {
        dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTCHAMCONGRepo _KTCHAMCONGRepo = new KTCHAMCONGRepo();
        public Unit _unit = new Unit();
        private List<int> _listUpdate = new List<int>();

        public ChamCong()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Data()
        {
            try
            {
                _KTCHAMCONGRepo = new KTCHAMCONGRepo();
                gridData.DataSource = _KTCHAMCONGRepo.GetAll();
            }
            catch (Exception) { }
        }
        private void Get_Data(KT_CHAM_CONG obj, int position)
        {
            try
            {
                obj.STT = Utils.CIntDef(gridView1.GetRowCellValue(position, "STT"), 0);
                obj.TEN_NV = Utils.CStrDef(gridView1.GetRowCellValue(position, "TEN_NV"), "");
                obj.NAM = Utils.CStrDef(gridView1.GetRowCellValue(position, "NAM"), "");
                obj.THANG = Utils.CStrDef(gridView1.GetRowCellValue(position, "THANG"), "");
                obj.LOAI_BL = Utils.CStrDef(gridView1.GetRowCellValue(position, "LOAI_BL"), "");
                obj.MA_NV = Utils.CStrDef(gridView1.GetRowCellValue(position, "MA_NV"), "");
                obj.PHONG_BAN = Utils.CStrDef(gridView1.GetRowCellValue(position, "PHONG_BAN"), "");
                obj.TEN_PHONG_BAN = Utils.CStrDef(gridView1.GetRowCellValue(position, "TEN_PHONG_BAN"), "");
                obj.TONG_NC = Utils.CDblDef(gridView1.GetRowCellValue(position, "TONG_NC"), 0);
                obj.TONG_NN = Utils.CDblDef(gridView1.GetRowCellValue(position, "TONG_NN"), 0);
                obj.N01 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N01"), "");
                obj.N02 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N02"), "");
                obj.N03 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N03"), "");
                obj.N04 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N04"), "");
                obj.N05 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N05"), "");
                obj.N06 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N06"), "");
                obj.N07 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N07"), "");
                obj.N08 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N08"), "");
                obj.N09 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N09"), "");
                obj.N10 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N10"), "");
                obj.N11 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N11"), "");
                obj.N12 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N12"), "");
                obj.N13 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N13"), "");
                obj.N14 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N14"), "");
                obj.N15 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N15"), "");
                obj.N16 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N16"), "");
                obj.N17 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N17"), "");
                obj.N18 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N18"), "");
                obj.N19 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N19"), "");
                obj.N20 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N20"), "");
                obj.N21 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N21"), "");
                obj.N22 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N22"), "");
                obj.N23 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N23"), "");
                obj.N24 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N24"), "");
                obj.N25 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N25"), "");
                obj.N26 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N26"), "");
                obj.N27 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N27"), "");
                obj.N28 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N28"), "");
                obj.N29 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N29"), "");
                obj.N30 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N30"), "");
                obj.N31 = Utils.CStrDef(gridView1.GetRowCellValue(position, "N31"), "");
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
                _KTCHAMCONGRepo = new KTCHAMCONGRepo();
                int i = 0;
                foreach (int pos in _listUpdate)
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(pos, "ID"), 0);
                    KT_CHAM_CONG obj = _KTCHAMCONGRepo.GetById(id);
                    if (obj != null)
                    {
                        Get_Data(obj, pos);
                        _KTCHAMCONGRepo.Update(obj);
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
                _KTCHAMCONGRepo = new KTCHAMCONGRepo();
                int _id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                KT_CHAM_CONG obj = _KTCHAMCONGRepo.GetById(_id);
                if (obj != null)
                {
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "").Trim() == "T" ? "" : "T";
                    _KTCHAMCONGRepo.Update(obj);
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
                    _KTCHAMCONGRepo = new KTCHAMCONGRepo();
                    KT_CHAM_CONG obj = new KT_CHAM_CONG();
                    Get_Data(obj, gridView1.FocusedRowHandle);
                    _KTCHAMCONGRepo.Create(obj);
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

                _KTCHAMCONGRepo = new KTCHAMCONGRepo();
                int Id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                _KTCHAMCONGRepo.Remove(Id);

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
                _KTCHAMCONGRepo = new KTCHAMCONGRepo();
                //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
                if (view.IsNewItemRow(e.RowHandle))
                {
                    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại
                    KT_CHAM_CONG obj = new KT_CHAM_CONG();
                    Get_Data(obj, e.RowHandle);
                    _KTCHAMCONGRepo.Create(obj);

                }
                //Cũ thì update
                else
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "ID").ToString(), 0);
                    KT_CHAM_CONG obj = _KTCHAMCONGRepo.GetById(id);
                    if (obj != null)
                    {
                        Get_Data(obj, e.RowHandle);
                        _KTCHAMCONGRepo.Update(obj);
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
            string[] _arr = { "STT", "NAM", "THANG", "LOAI_BL", "MA_NV", "TEN_NV", "PHONG_BAN", "TEN_PHONG_BAN" };
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