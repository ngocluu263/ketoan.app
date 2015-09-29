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
    public partial class ChiTietDonMuaHang : DevComponents.DotNetBar.Metro.MetroForm
    {
        dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTDonMuaHangRepo _KTDonMuaHangRepo = new KTDonMuaHangRepo();
        public Unit _unit = new Unit();
        private List<int> _listUpdate = new List<int>();

        public ChiTietDonMuaHang()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Data()
        {
            try
            {
                _KTDonMuaHangRepo = new KTDonMuaHangRepo();
                gridData.DataSource = _KTDonMuaHangRepo.GetAll();
            }
            catch (Exception) { }
        }
        private void Get_Data(KT_DonMuaHang obj, int position)
        {
            try
            {
                obj.STT = Utils.CIntDef(gridView1.GetRowCellValue(position, "STT"), 0);
                obj.LOAI_DH = Utils.CStrDef(gridView1.GetRowCellValue(position, "LOAI_DH"), "");
                obj.SO_HD = Utils.CDblDef(gridView1.GetRowCellValue(position, "SO_HD"), 0);
                obj.MA_KH = Utils.CStrDef(gridView1.GetRowCellValue(position, "MA_KH"), "");
                obj.NGAY_HD = gridView1.GetRowCellValue(position, "NGAY_HD") != null 
                    ? Utils.CDateDef(gridView1.GetRowCellValue(position, "NGAY_HD"), DateTime.Now) : obj.NGAY_HD = null;
                obj.NOI_DUNG_HOPDONG = Utils.CStrDef(gridView1.GetRowCellValue(position, "NOI_DUNG_HOPDONG"), "");
                obj.TEN_KH = Utils.CStrDef(gridView1.GetRowCellValue(position, "TEN_KH"), "");
                obj.DIA_CHI_KH = Utils.CStrDef(gridView1.GetRowCellValue(position, "DIA_CHI_KH"), "");
                obj.MST = Utils.CStrDef(gridView1.GetRowCellValue(position, "MST"), "");
                obj.MA_NLH_MUA = Utils.CStrDef(gridView1.GetRowCellValue(position, "MA_NLH_MUA"), "");
                obj.TEN_NLH_MUA = Utils.CStrDef(gridView1.GetRowCellValue(position, "TEN_NLH_MUA"), "");
                obj.DT_NLH_MUA = Utils.CStrDef(gridView1.GetRowCellValue(position, "DT_NLH_MUA"), "");
                obj.MA_NLH_BAN = Utils.CStrDef(gridView1.GetRowCellValue(position, "MA_NLH_BAN"), "");
                obj.TEN_NLH_BAN = Utils.CStrDef(gridView1.GetRowCellValue(position, "TEN_NLH_BAN"), "");
                obj.DT_NLH_BAN = Utils.CStrDef(gridView1.GetRowCellValue(position, "DT_NLH_BAN"), "");
                obj.NGAY_GH = gridView1.GetRowCellValue(position, "NGAY_GH") != null 
                    ? Utils.CDateDef(gridView1.GetRowCellValue(position, "NGAY_GH"), DateTime.Now) : obj.NGAY_GH = null;
                obj.MA_DM = Utils.CStrDef(gridView1.GetRowCellValue(position, "MA_DM"), "");
                obj.TEN_DM = Utils.CStrDef(gridView1.GetRowCellValue(position, "TEN_DM"), "");
                obj.DVT = Utils.CStrDef(gridView1.GetRowCellValue(position, "DVT"), "");
                obj.SO_LUONG = Utils.CDblDef(gridView1.GetRowCellValue(position, "DON_GIA"), 0);
                obj.DON_GIA = Utils.CDblDef(gridView1.GetRowCellValue(position, "DON_GIA_VND"), 0);
                obj.THANH_TIEN = Utils.CDblDef(gridView1.GetRowCellValue(position, "THANH_TIEN"), 0);
                obj.TS_GTGT = Utils.CDblDef(gridView1.GetRowCellValue(position, "TS_GTGT"), 0);
                obj.TIEN_THUE = Utils.CDblDef(gridView1.GetRowCellValue(position, "TIEN_THUE"), 0);
                obj.TONG_TIEN = Utils.CDblDef(gridView1.GetRowCellValue(position, "TONG_TIEN_VND"), 0);
                obj.TON_CK_SL = Utils.CDblDef(gridView1.GetRowCellValue(position, "TON_CK_SL"), 0);
                obj.TON_CK_GT = Utils.CDblDef(gridView1.GetRowCellValue(position, "TON_CK_GT"), 0);
                obj.DON_GIA_TON = Utils.CDblDef(gridView1.GetRowCellValue(position, "DON_GIA_TON"), 0);
                obj.GHI_CHU = Utils.CStrDef(gridView1.GetRowCellValue(position, "GHI_CHU"), "");
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
                _KTDonMuaHangRepo = new KTDonMuaHangRepo();
                int i = 0;
                foreach (int pos in _listUpdate)
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(pos, "ID"), 0);
                    KT_DonMuaHang obj = _KTDonMuaHangRepo.GetById(id);
                    if (obj != null)
                    {
                        Get_Data(obj, pos);
                        _KTDonMuaHangRepo.Update(obj);
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
                _KTDonMuaHangRepo = new KTDonMuaHangRepo();
                int _id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                KT_DonMuaHang obj = _KTDonMuaHangRepo.GetById(_id);
                if (obj != null)
                {
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "").Trim() == "T" ? "" : "T";
                    _KTDonMuaHangRepo.Update(obj);
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
                    _KTDonMuaHangRepo = new KTDonMuaHangRepo();
                    KT_DonMuaHang obj = new KT_DonMuaHang();
                    Get_Data(obj, gridView1.FocusedRowHandle);
                    _KTDonMuaHangRepo.Create(obj);
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

                _KTDonMuaHangRepo = new KTDonMuaHangRepo();
                int Id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                _KTDonMuaHangRepo.Remove(Id);

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
                _KTDonMuaHangRepo = new KTDonMuaHangRepo();
                //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
                if (view.IsNewItemRow(e.RowHandle))
                {
                    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại
                    KT_DonMuaHang obj = new KT_DonMuaHang();
                    Get_Data(obj, e.RowHandle);
                    _KTDonMuaHangRepo.Create(obj);

                }
                //Cũ thì update
                else
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "ID").ToString(), 0);
                    KT_DonMuaHang obj = _KTDonMuaHangRepo.GetById(id);
                    if (obj != null)
                    {
                        Get_Data(obj, e.RowHandle);
                        _KTDonMuaHangRepo.Update(obj);
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
            string[] _arr = { "MA_CTU", "SO_CTU", "NGAY_CTU", "DIEN_GIAI", "TK_NO", "TK_CO", "THANH_TIEN_VND" };
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