﻿using System;
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
    public partial class SoTheoDoiChiPhiTheoBoPhan : DevComponents.DotNetBar.Metro.MetroForm
    {
        dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTCPRepo _KTCPRepo = new KTCPRepo();
        public Unit _unit = new Unit();
        private List<int> _listUpdate = new List<int>();

        public SoTheoDoiChiPhiTheoBoPhan()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Data()
        {
            try
            {
                _KTCPRepo = new KTCPRepo();
                gridData.DataSource = _KTCPRepo.GetAll();
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
                _KTCPRepo = new KTCPRepo();
                int i = 0;
                foreach (int pos in _listUpdate)
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(pos, "ID"), 0);
                    KT_CP obj = _KTCPRepo.GetById(id);
                    if (obj != null)
                    {
                        obj.MA_TK = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_TK"), "");
                        obj.MA_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_DTPN"), "");
                        obj.MA_YTCP = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_YTCP"), "");
                        obj.TEN_TK = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_TK"), "");
                        obj.TEN_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_DTPN"), "");
                        obj.TEN_YTCP_V = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_YTCP_V"), "");
                        obj.DUNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "DUNO_VND"), 0);
                        obj.DUCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "DUCO_VND"), 0);
                        obj.PSNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "PSNO_VND"), 0);
                        obj.PSCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "PSCO_VND"), 0);
                        obj.CKNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "CKNO_VND"), 0);
                        obj.CKCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "CKCO_VND"), 0);
                        obj.DUNO_USD = Utils.CIntDef(gridView1.GetRowCellValue(pos, "DUNO_USD"), 0);
                        obj.DUCO_USD = Utils.CIntDef(gridView1.GetRowCellValue(pos, "DUCO_USD"), 0);
                        obj.PSNO_USD = Utils.CIntDef(gridView1.GetRowCellValue(pos, "PSNO_USD"), 0);
                        obj.PSCO_USD = Utils.CIntDef(gridView1.GetRowCellValue(pos, "PSCO_USD"), 0);
                        obj.CKNO_USD = Utils.CIntDef(gridView1.GetRowCellValue(pos, "CKNO_USD"), 0);
                        obj.CKCO_USD = Utils.CIntDef(gridView1.GetRowCellValue(pos, "CKCO_USD"), 0);
                        obj.PSNO_LK_VND = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSNO_LK_VND"), 0);
                        obj.PSCO_LK_VND = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSCO_LK_VND"), 0);
                        obj.PSNO_LK_USD = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSNO_LK_USD"), 0);
                        obj.PSCO_LK_USD = Utils.CDblDef(gridView1.GetRowCellValue(pos, "PSCO_LK_USD"), 0);
                        obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DANH_DAU"), "");
                        obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(pos, "TRANG_THAI"), 0);                        

                        _KTCPRepo.Update(obj);
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
                _KTCPRepo = new KTCPRepo();
                int id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                KT_CP obj = _KTCPRepo.GetById(id);
                if (obj != null)
                {
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "").Trim() == "T" ? "" : "T";
                    _KTCPRepo.Update(obj);
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
                    _KTCPRepo = new KTCPRepo();
                    KT_CP obj = new KT_CP();

                    obj.MA_TK = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_TK"), "");
                    obj.MA_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_DTPN"), "");
                    obj.MA_YTCP = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_YTCP"), "");
                    obj.TEN_TK = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_TK"), "");
                    obj.TEN_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_DTPN"), "");
                    obj.TEN_YTCP_V = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_YTCP_V"), "");
                    obj.DUNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DUNO_VND"), 0);
                    obj.DUCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DUCO_VND"), 0);
                    obj.PSNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSNO_VND"), 0);
                    obj.PSCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSCO_VND"), 0);
                    obj.CKNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CKNO_VND"), 0);
                    obj.CKCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CKCO_VND"), 0);
                    obj.DUNO_USD = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DUNO_USD"), 0);
                    obj.DUCO_USD = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DUCO_USD"), 0);
                    obj.PSNO_USD = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSNO_USD"), 0);
                    obj.PSCO_USD = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSCO_USD"), 0);
                    obj.CKNO_USD = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CKNO_USD"), 0);
                    obj.CKCO_USD = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CKCO_USD"), 0);
                    obj.PSNO_LK_VND = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSNO_LK_VND"), 0);
                    obj.PSCO_LK_VND = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSCO_LK_VND"), 0);
                    obj.PSNO_LK_USD = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSNO_LK_USD"), 0);
                    obj.PSCO_LK_USD = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSCO_LK_USD"), 0);
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "");
                    obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TRANG_THAI"), 0);  

                    _KTCPRepo.Create(obj);
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
                _KTCPRepo = new KTCPRepo();
                _KTCPRepo.Remove(id);

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
                GridColumn ma_tkCol = view.Columns["MA_TK"];
                GridColumn ma_dtpnCol = view.Columns["MA_DTPN"];
                GridColumn ma_ytcpCol = view.Columns["MA_YTCP"];
                string ma_tk = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, ma_tkCol), "");
                string ma_dtpn = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, ma_dtpnCol), "");
                string ma_ytcp = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, ma_ytcpCol), "");
                if (ma_tk.Trim().Length == 0 || ma_dtpn.Trim().Length == 0 || ma_ytcp.Trim().Length == 0)
                {
                    e.Valid = false;
                    if (ma_tk.Trim().Length == 0)
                        view.SetColumnError(ma_tkCol, "Mã TK không được rổng");
                    if (ma_dtpn.Trim().Length == 0)
                        view.SetColumnError(ma_dtpnCol, "Mã đối tượng pháp nhân không được rổng");
                    if (ma_ytcp.Trim().Length == 0)
                        view.SetColumnError(ma_ytcpCol, "Mã YTCP không được rổng");

                    return;
                }

                _KTCPRepo = new KTCPRepo();
                //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
                if (view.IsNewItemRow(e.RowHandle))
                {
                    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại
                    KT_CP obj = new KT_CP();

                    obj.MA_TK = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "MA_TK"), "");
                    obj.MA_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "MA_DTPN"), "");
                    obj.MA_YTCP = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "MA_YTCP"), "");
                    obj.TEN_TK = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "TEN_TK"), "");
                    obj.TEN_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "TEN_DTPN"), "");
                    obj.TEN_YTCP_V = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "TEN_YTCP_V"), "");
                    obj.DUNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "DUNO_VND"), 0);
                    obj.DUCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "DUCO_VND"), 0);
                    obj.PSNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "PSNO_VND"), 0);
                    obj.PSCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "PSCO_VND"), 0);
                    obj.CKNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "CKNO_VND"), 0);
                    obj.CKCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "CKCO_VND"), 0);
                    obj.DUNO_USD = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "DUNO_USD"), 0);
                    obj.DUCO_USD = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "DUCO_USD"), 0);
                    obj.PSNO_USD = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "PSNO_USD"), 0);
                    obj.PSCO_USD = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "PSCO_USD"), 0);
                    obj.CKNO_USD = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "CKNO_USD"), 0);
                    obj.CKCO_USD = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "CKCO_USD"), 0);
                    obj.PSNO_LK_VND = Utils.CDblDef(gridView1.GetRowCellValue(e.RowHandle, "PSNO_LK_VND"), 0);
                    obj.PSCO_LK_VND = Utils.CDblDef(gridView1.GetRowCellValue(e.RowHandle, "PSCO_LK_VND"), 0);
                    obj.PSNO_LK_USD = Utils.CDblDef(gridView1.GetRowCellValue(e.RowHandle, "PSNO_LK_USD"), 0);
                    obj.PSCO_LK_USD = Utils.CDblDef(gridView1.GetRowCellValue(e.RowHandle, "PSCO_LK_USD"), 0);
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "DANH_DAU"), "");
                    obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "TRANG_THAI"), 0);  

                    _KTCPRepo.Create(obj);

                }
                //Cũ thì update
                else
                {
                    int id = Utils.CIntDef(view.GetRowCellValue(gridView1.FocusedRowHandle, "ID"), 0);
                    KT_CP obj = _KTCPRepo.GetById(id);
                    if (obj != null)
                    {
                        obj.MA_TK = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "MA_TK"), "");
                        obj.MA_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "MA_DTPN"), "");
                        obj.MA_YTCP = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "MA_YTCP"), "");
                        obj.TEN_TK = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "TEN_TK"), "");
                        obj.TEN_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "TEN_DTPN"), "");
                        obj.TEN_YTCP_V = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "TEN_YTCP_V"), "");
                        obj.DUNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "DUNO_VND"), 0);
                        obj.DUCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "DUCO_VND"), 0);
                        obj.PSNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "PSNO_VND"), 0);
                        obj.PSCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "PSCO_VND"), 0);
                        obj.CKNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "CKNO_VND"), 0);
                        obj.CKCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "CKCO_VND"), 0);
                        obj.DUNO_USD = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "DUNO_USD"), 0);
                        obj.DUCO_USD = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "DUCO_USD"), 0);
                        obj.PSNO_USD = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "PSNO_USD"), 0);
                        obj.PSCO_USD = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "PSCO_USD"), 0);
                        obj.CKNO_USD = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "CKNO_USD"), 0);
                        obj.CKCO_USD = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "CKCO_USD"), 0);
                        obj.PSNO_LK_VND = Utils.CDblDef(gridView1.GetRowCellValue(e.RowHandle, "PSNO_LK_VND"), 0);
                        obj.PSCO_LK_VND = Utils.CDblDef(gridView1.GetRowCellValue(e.RowHandle, "PSCO_LK_VND"), 0);
                        obj.PSNO_LK_USD = Utils.CDblDef(gridView1.GetRowCellValue(e.RowHandle, "PSNO_LK_USD"), 0);
                        obj.PSCO_LK_USD = Utils.CDblDef(gridView1.GetRowCellValue(e.RowHandle, "PSCO_LK_USD"), 0);
                        obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(e.RowHandle, "DANH_DAU"), "");
                        obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "TRANG_THAI"), 0); 

                        _KTCPRepo.Update(obj);
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