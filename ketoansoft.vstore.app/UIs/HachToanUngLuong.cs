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
    public partial class HachToanUngLuong : DevComponents.DotNetBar.Metro.MetroForm
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        KTUNGLUONGRepo _KTUNGLUONGRepo = new KTUNGLUONGRepo();
        KT_CTuGocRepo _KT_CTuGocRepo = new KT_CTuGocRepo();

        public HachToanUngLuong()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Info()
        {
            txtNam.Text = Utils.CStrDef(fTerm._year, "");
            cboThang.Text = Utils.CStrDef(fTerm._month, "");
        }
        private bool Save_Data()
        {
            DateTime ngayHT = DateTime.ParseExact(dtNgayHoachToan.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            string dienGiai = "Tạm ứng lương tháng "+cboThang.Text+"/"+txtNam.Text+"";
            if (rdo1.Checked)
            {
                double tongTienUng = _KTUNGLUONGRepo.TongTienUng(txtNam.Text, cboThang.Text);
                if (tongTienUng > 0)
                {
                    _KT_CTuGocRepo.DeleteByMaCT("UL", Utils.CIntDef(cboThang.Text, 0), Utils.CIntDef(txtNam.Text, 0));
                    _KT_CTuGocRepo.InsertUngLuong("UL", "1/1", txtSoPhieuChi.Text, ngayHT, dienGiai, "141", "1111", tongTienUng, "");
                    return true;
                }
                else
                {
                    MessageBox.Show("Bảng TẠM ỨNG LƯƠNG tháng này chưa có. Không thể cập nhật vào SỔ CHỨNG TỪ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                var listUngLuong = _KTUNGLUONGRepo.DanhSachUngLuong(txtNam.Text, cboThang.Text);
                if (listUngLuong != null)
                {
                    _KT_CTuGocRepo.DeleteByMaCT("UL", Utils.CIntDef(cboThang.Text, 0), Utils.CIntDef(txtNam.Text, 0));
                    for (int i = 0; i < listUngLuong.Count; i++)
                    {
                        double tongTienUng = Utils.CDblDef(listUngLuong[i].TAM_UNG, 0);
                        string maDTPNNo = listUngLuong[i].MA_NV;
                        _KT_CTuGocRepo.InsertUngLuong("UL", "1/1", txtSoPhieuChi.Text, ngayHT, dienGiai, "141", "1111", tongTienUng, maDTPNNo);
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Bảng TẠM ỨNG LƯƠNG tháng này chưa có. Không thể cập nhật vào SỔ CHỨNG TỪ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return false;
        }
        #endregion

        #region Event
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (Save_Data())
            {
                MessageBox.Show("Đã hạch toán TẠM ỨNG LƯƠNG xong. Bạn hãy kiểm tra lại trong SỔ CHỨNG TỪ GỐC!", "Thông báo");
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LapBangChamCong_Load(object sender, EventArgs e)
        {
            Load_Info();
        }
        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dt = dtNgayHoachToan.Value;
            dt = new DateTime(dt.Year, Utils.CIntDef(cboThang.Text, 0), 1);
            dtNgayHoachToan.Value = GetLastDayOfMonth(dt);
        }
        private void dtNgayHoachToan_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dtNgayHoachToan.Value;
            dt = new DateTime(dt.Year, Utils.CIntDef(cboThang.Text, 0), dt.Day);
            dtNgayHoachToan.Value = dt;
        }
        #endregion

        #region Funtion
        public static DateTime GetLastDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }
        #endregion
    }
}