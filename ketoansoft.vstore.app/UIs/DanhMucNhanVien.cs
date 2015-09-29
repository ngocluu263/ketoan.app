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
    public partial class DanhMucNhanVien : DevComponents.DotNetBar.Metro.MetroForm
    {
        dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTNHANVIENRepo _KTNHANVIENRepo = new KTNHANVIENRepo();
        public Unit _unit = new Unit();
        private List<int> _listUpdate = new List<int>();

        public DanhMucNhanVien()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Data()
        {
            try
            {
                _KTNHANVIENRepo = new KTNHANVIENRepo();
                gridData.DataSource = _KTNHANVIENRepo.GetAll();
            }
            catch (Exception) { }
        }
        private void Get_Data(KT_NHANVIEN obj, int position)
        {
            try
            {
                obj.STT = Utils.CIntDef(gridView1.GetRowCellValue(position, "STT"), 0);
                obj.MA_NV = Utils.CStrDef(gridView1.GetRowCellValue(position, "MA_NV"), "");
                obj.TEN_NV_VIET = Utils.CStrDef(gridView1.GetRowCellValue(position, "TEN_NV_VIET"), "");
                obj.HSO_LUONG = Utils.CDblDef(gridView1.GetRowCellValue(position, "HSO_LUONG"), 0);
                obj.TK_LUONG = Utils.CStrDef(gridView1.GetRowCellValue(position, "TK_LUONG"), "");
                obj.TK_CP_LUONG = Utils.CStrDef(gridView1.GetRowCellValue(position, "TK_CP_LUONG"), "");
                obj.TK_KPCD = Utils.CStrDef(gridView1.GetRowCellValue(position, "TK_KPCD"), "");
                obj.TK_BHXH = Utils.CStrDef(gridView1.GetRowCellValue(position, "TK_BHXH"), "");
                obj.TK_BHYT = Utils.CStrDef(gridView1.GetRowCellValue(position, "TK_BHYT"), "");
                obj.TK_BHTN = Utils.CStrDef(gridView1.GetRowCellValue(position, "TK_BHTN"), "");
                obj.TK_TNCN = Utils.CStrDef(gridView1.GetRowCellValue(position, "TK_TNCN"), "");
                obj.NGAY_CONG = Utils.CDblDef(gridView1.GetRowCellValue(position, "NGAY_CONG"), 0);
                obj.LUONG_CB = Utils.CDblDef(gridView1.GetRowCellValue(position, "LUONG_CB"), 0);
                obj.PC_CHUCVU = Utils.CDblDef(gridView1.GetRowCellValue(position, "PC_CHUCVU"), 0);
                obj.PC_TRACH_NHIEM = Utils.CDblDef(gridView1.GetRowCellValue(position, "PC_TRACH_NHIEM"), 0);
                obj.PC_AN = Utils.CDblDef(gridView1.GetRowCellValue(position, "PC_AN"), 0);
                obj.PC_THAM_NIEN = Utils.CDblDef(gridView1.GetRowCellValue(position, "PC_THAM_NIEN"), 0);
                obj.TONG_LUONG = Utils.CDblDef(gridView1.GetRowCellValue(position, "TONG_LUONG"), 0);
                obj.BHXH_NLD = Utils.CDblDef(gridView1.GetRowCellValue(position, "BHXH_NLD"), 0);
                obj.BHXH_CTY = Utils.CDblDef(gridView1.GetRowCellValue(position, "BHXH_CTY"), 0);
                obj.BHYT_NLD = Utils.CDblDef(gridView1.GetRowCellValue(position, "BHYT_NLD"), 0);
                obj.BHYT_CTY = Utils.CDblDef(gridView1.GetRowCellValue(position, "BHYT_CTY"), 0);
                obj.BHTN_NLD = Utils.CDblDef(gridView1.GetRowCellValue(position, "BHTN_NLD"), 0);
                obj.BHTN_CTY = Utils.CDblDef(gridView1.GetRowCellValue(position, "BHTN_CTY"), 0);
                obj.KP_CD = Utils.CDblDef(gridView1.GetRowCellValue(position, "KP_CD"), 0);
                obj.LUONG_TN = Utils.CDblDef(gridView1.GetRowCellValue(position, "LUONG_TN"), 0);
                obj.TEN_NV_ANH = Utils.CStrDef(gridView1.GetRowCellValue(position, "TEN_NV_ANH"), "");
                obj.TEN_NV_HOA = Utils.CStrDef(gridView1.GetRowCellValue(position, "TEN_NV_HOA"), "");
                obj.NGAY_SINH = gridView1.GetRowCellValue(position, "NGAY_SINH") != null
                    ? Utils.CDateDef(gridView1.GetRowCellValue(position, "NGAY_SINH"), DateTime.Now) : obj.NGAY_SINH = null;
                obj.GIOI_TINH = Utils.CStrDef(gridView1.GetRowCellValue(position, "GIOI_TINH"), "");
                obj.NOI_SINH = Utils.CStrDef(gridView1.GetRowCellValue(position, "NOI_SINH"), "");
                obj.QUOC_GIA = Utils.CStrDef(gridView1.GetRowCellValue(position, "QUOC_GIA"), "");
                obj.TINH_TP = Utils.CStrDef(gridView1.GetRowCellValue(position, "TINH_TP"), "");
                obj.QUAN_HUYEN = Utils.CStrDef(gridView1.GetRowCellValue(position, "QUAN_HUYEN"), "");
                obj.CMND = Utils.CStrDef(gridView1.GetRowCellValue(position, "CMND"), "");
                obj.NGAY_CAP = gridView1.GetRowCellValue(position, "NGAY_CAP") != null
                    ? Utils.CDateDef(gridView1.GetRowCellValue(position, "NGAY_CAP"), DateTime.Now) : obj.NGAY_CAP = null;
                obj.NOI_CAP = Utils.CStrDef(gridView1.GetRowCellValue(position, "NOI_CAP"), "");
                obj.QUE_QUAN = Utils.CStrDef(gridView1.GetRowCellValue(position, "QUE_QUAN"), "");
                obj.THUONG_TRU = Utils.CStrDef(gridView1.GetRowCellValue(position, "THUONG_TRU"), "");
                obj.TAM_TRU = Utils.CStrDef(gridView1.GetRowCellValue(position, "TAM_TRU"), "");
                obj.DIEN_THOAI1 = Utils.CStrDef(gridView1.GetRowCellValue(position, "DIEN_THOAI1"), "");
                obj.DIEN_THOAI2 = Utils.CStrDef(gridView1.GetRowCellValue(position, "DIEN_THOAI2"), "");
                obj.EMAIL = Utils.CStrDef(gridView1.GetRowCellValue(position, "EMAIL"), "");
                obj.DAN_TOC = Utils.CStrDef(gridView1.GetRowCellValue(position, "DAN_TOC"), "");
                obj.TON_GIAO = Utils.CStrDef(gridView1.GetRowCellValue(position, "TON_GIAO"), "");
                obj.QUOC_TICH = Utils.CStrDef(gridView1.GetRowCellValue(position, "QUOC_TICH"), "");
                obj.VAN_HOA = Utils.CStrDef(gridView1.GetRowCellValue(position, "VAN_HOA"), "");
                obj.CHUYEN_NGANH = Utils.CStrDef(gridView1.GetRowCellValue(position, "CHUYEN_NGANH"), "");
                obj.CHUC_VU = Utils.CStrDef(gridView1.GetRowCellValue(position, "CHUC_VU"), "");
                obj.CHUC_DANH = Utils.CStrDef(gridView1.GetRowCellValue(position, "CHUC_DANH"), "");
                obj.CHUC_VU_DN = Utils.CStrDef(gridView1.GetRowCellValue(position, "CHUC_VU_DN"), "");
                obj.PHONG_BAN = Utils.CStrDef(gridView1.GetRowCellValue(position, "PHONG_BAN"), "");
                obj.TEN_PHONG_BAN = Utils.CStrDef(gridView1.GetRowCellValue(position, "TEN_PHONG_BAN"), "");
                obj.THUOC_TO = Utils.CStrDef(gridView1.GetRowCellValue(position, "THUOC_TO"), "");
                obj.NGAY_LUU = gridView1.GetRowCellValue(position, "NGAY_LUU") != null
                    ? Utils.CDateDef(gridView1.GetRowCellValue(position, "NGAY_LUU"), DateTime.Now) : obj.NGAY_LUU = null;
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
                _KTNHANVIENRepo = new KTNHANVIENRepo();
                int i = 0;
                foreach (int pos in _listUpdate)
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(pos, "ID"), 0);
                    KT_NHANVIEN obj = _KTNHANVIENRepo.GetById(id);
                    if (obj != null)
                    {
                        Get_Data(obj, pos);
                        _KTNHANVIENRepo.Update(obj);
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
                _KTNHANVIENRepo = new KTNHANVIENRepo();
                int _id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                KT_NHANVIEN obj = _KTNHANVIENRepo.GetById(_id);
                if (obj != null)
                {
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "").Trim() == "T" ? "" : "T";
                    _KTNHANVIENRepo.Update(obj);
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
                    _KTNHANVIENRepo = new KTNHANVIENRepo();
                    KT_NHANVIEN obj = new KT_NHANVIEN();
                    Get_Data(obj, gridView1.FocusedRowHandle);
                    _KTNHANVIENRepo.Create(obj);
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

                _KTNHANVIENRepo = new KTNHANVIENRepo();
                int Id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                _KTNHANVIENRepo.Remove(Id);

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
                _KTNHANVIENRepo = new KTNHANVIENRepo();
                //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
                if (view.IsNewItemRow(e.RowHandle))
                {
                    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại
                    KT_NHANVIEN obj = new KT_NHANVIEN();
                    Get_Data(obj, e.RowHandle);
                    _KTNHANVIENRepo.Create(obj);

                }
                //Cũ thì update
                else
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(e.RowHandle, "ID").ToString(), 0);
                    KT_NHANVIEN obj = _KTNHANVIENRepo.GetById(id);
                    if (obj != null)
                    {
                        Get_Data(obj, e.RowHandle);
                        _KTNHANVIENRepo.Update(obj);
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
            string[] _arr = { "STT", "MA_NV", "TEN_NV_VIET"};
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