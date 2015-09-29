using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ketoansoft.app.Class.Data;
using ketoansoft.app.Components.clsVproUtility;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.UIs
{
    public partial class LapBangLuong : DevComponents.DotNetBar.Metro.MetroForm
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        KTNHANVIENRepo _KTNHANVIENRepo = new KTNHANVIENRepo();
        KTBANGLUONGRepo _KTBANGLUONGRepo = new KTBANGLUONGRepo();
        KTMACONGRepo _KTMACONGRepo = new KTMACONGRepo();

        public LapBangLuong()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Info()
        {
            txtNam.Text = Utils.CStrDef(fTerm._year, "");
            cboThang.Text = Utils.CStrDef(fTerm._month, "");

            cboLoaiBangLuong.DataSource = GetTableTyle();
            cboLoaiBangLuong.DisplayMember = "LOAI_BL";
            cboLoaiBangLuong.ValueMember = "LOAI_BL";
            cboLoaiBangLuong.DropDownColumns = "LOAI_BL,TEN_BL";
            cboLoaiBangLuong.SelectedIndex = 0;
        }
        private void Load_PhongBan()
        {
            grvData.DataSource = _KTNHANVIENRepo.Get_Departments();

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Lập";
            checkBoxColumn.Width = 40;
            checkBoxColumn.Name = "checkBoxColumn";
            grvData.Columns.Insert(0, checkBoxColumn);
        }
        private bool Save_Data()
        {
            int count = get_phongban().Count;
            for (int i = 0; i < count; i++)
            {
                List<KT_NHANVIEN> obj = _KTNHANVIENRepo.GetDataByPB(get_phongban()[i]);
                if (obj != null)
                {
                    var lcheck = _KTBANGLUONGRepo.Check_PhongBan(txtNam.Text, cboThang.Text, get_phongban()[i]);
                    if (lcheck != null)
                    {
                        if (MessageBox.Show("Chú ý: Bảng lương của phòng ban " + get_phongban()[i] + " đang tồn tại. Hệ thống sẽ xóa và lập lại bảng mới?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            _KTBANGLUONGRepo.DeleteByPhongBan(lcheck);
                            _KTBANGLUONGRepo.InsertDuplicate(obj, txtNam.Text, cboThang.Text, cboLoaiBangLuong.Text);
                            return true;
                        }
                    }
                    else
                    {
                        _KTBANGLUONGRepo.InsertDuplicate(obj, txtNam.Text, cboThang.Text, cboLoaiBangLuong.Text);
                        return true;
                    }
                }
            }
            return false;
        }
        static DataTable GetTableTyle()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("LOAI_BL", typeof(string));
            table.Columns.Add("TEN_BL", typeof(string));

            // Here we add five DataRows.
            table.Rows.Add("1", "Bảng lương cơ bản cố định");
            table.Rows.Add("2", "Bảng lương thời gian");
            return table;
        }
        #endregion

        #region Funtion
        private List<string> get_phongban()
        {
            List<string> name = new List<string>();
            foreach (DataGridViewRow row in grvData.Rows)
            {
                if (chkAll.Checked)
                {
                    name.Add(row.Cells["PHONG_BAN"].Value.ToString());
                }
                else
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                    if (isSelected)
                    {
                        name.Add(row.Cells["PHONG_BAN"].Value.ToString());
                    }
                }
            }
            return name;
        }
        #endregion

        #region Event
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (Save_Data())
            {
                MessageBox.Show("Đã cập nhật vào bảng Lương thành công!","Thông báo");
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LapBangChamCong_Load(object sender, EventArgs e)
        {
            Load_Info();
            Load_PhongBan();
        }
        #endregion
    }
}