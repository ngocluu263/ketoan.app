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
    public partial class LapBangChamCong : DevComponents.DotNetBar.Metro.MetroForm
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        KTNHANVIENRepo _KTNHANVIENRepo = new KTNHANVIENRepo();
        KTCHAMCONGRepo _KTCHAMCONGRepo = new KTCHAMCONGRepo();
        KTMACONGRepo _KTMACONGRepo = new KTMACONGRepo();
        KTNGAYLERepo _KTNGAYLERepo = new KTNGAYLERepo();

        public LapBangChamCong()
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
                var lcheck = _KTCHAMCONGRepo.Check_PhongBan(txtNam.Text, cboThang.Text, get_phongban()[i]);
                if (lcheck != null)
                {
                    if (MessageBox.Show("Chú ý: Bảng chấm công của phòng ban " + get_phongban()[i] + " đang tồn tại. Hệ thống sẽ xóa và lập lại bảng mới?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        _KTCHAMCONGRepo.DeleteByPhongBan(lcheck);
                        _KTCHAMCONGRepo.InsertDuplicate(obj, txtNam.Text, cboThang.Text, cboLoaiBangLuong.Text, get_ngaycong(cboThang.Text, txtNam.Text));
                        return true;
                    }
                }
                else
                {
                    _KTCHAMCONGRepo.InsertDuplicate(obj, txtNam.Text, cboThang.Text, cboLoaiBangLuong.Text, get_ngaycong(cboThang.Text, txtNam.Text));
                    return true;
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
            table.Rows.Add("3", "Bảng lương tạm ứng");
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
        private List<string> get_ngaycong(string thang, string nam)
        {
            List<string> temp = new List<string>();
            try
            {
                string[] _day = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10"
                                , "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
                                ,"21","22","23","24","25","26","27","28","29","30","31" };
                DateTime _date = new DateTime();
                for (int i = 0; i < _day.Length; i++)
                {
                    _date = DateTime.ParseExact(_day[i] + "/" + thang + "/" + nam, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    if (_date.DayOfWeek.ToString() == "Sunday")
                    {
                        temp.Add("CN");
                    }
                    else if(_KTNGAYLERepo.CheckExist(Utils.CIntDef(_day[i],0),Utils.CIntDef(thang,0)))
                    {
                        temp.Add("LE");
                    }
                    else { temp.Add("."); }
                }
            }
            catch { }
            return temp;
        }
        #endregion

        #region Event
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (Save_Data())
            {
                MessageBox.Show("Đã cập nhật vào bảng Chấm Công thành công!", "Thông báo");
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