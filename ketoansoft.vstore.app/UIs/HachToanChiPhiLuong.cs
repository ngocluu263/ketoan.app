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
    public partial class HachToanChiPhiLuong : DevComponents.DotNetBar.Metro.MetroForm
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        KTBANGLUONGRepo _KTBANGLUONGRepo = new KTBANGLUONGRepo();
        KT_CTuGocRepo _KT_CTuGocRepo = new KT_CTuGocRepo();

        public HachToanChiPhiLuong()
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
            if (rdo1.Checked)
            {
                double tongLuong = _KTBANGLUONGRepo.TongLuong(txtNam.Text, cboThang.Text);
                double tongLuongTN = _KTBANGLUONGRepo.TongLuongTN(txtNam.Text, cboThang.Text);
                double bhxhCty = _KTBANGLUONGRepo.TongBHXHCty(txtNam.Text, cboThang.Text);
                double bhytCty = _KTBANGLUONGRepo.TongBHYTCty(txtNam.Text, cboThang.Text);
                double bhxhNLD = _KTBANGLUONGRepo.TongBHXHNld(txtNam.Text, cboThang.Text);
                double bhytNLD = _KTBANGLUONGRepo.TongBHYTNld(txtNam.Text, cboThang.Text);
                double bhtnNLD = _KTBANGLUONGRepo.TongBHTNNld(txtNam.Text, cboThang.Text);
                if (tongLuong > 0 || tongLuongTN > 0)
                {
                    _KT_CTuGocRepo.DeleteByMaCT("CPL", Utils.CIntDef(cboThang.Text, 0), Utils.CIntDef(txtNam.Text, 0));
                    _KT_CTuGocRepo.InsertChiPhiLuong("CPL", "1/1", ngayHT, "Phải trả lương Tháng " + cboThang.Text + "", "6422", "334"
                        , chkLuongThucNhan.Checked ? tongLuongTN : tongLuong);
                    _KT_CTuGocRepo.InsertChiPhiLuong("CPL", "1/1", ngayHT, "BHXH công ty đóng Tháng " + cboThang.Text + "", "6422", "3383"
                        , bhxhCty);
                    _KT_CTuGocRepo.InsertChiPhiLuong("CPL", "1/1", ngayHT, "BHYT công ty đóng Tháng " + cboThang.Text + "", "6422", "3384"
                        , bhytCty);
                    _KT_CTuGocRepo.InsertChiPhiLuong("CPL", "1/1", ngayHT, "BHXH NLĐ đóng Tháng " + cboThang.Text + "", "334", "3383"
                        , bhxhNLD);
                    _KT_CTuGocRepo.InsertChiPhiLuong("CPL", "1/1", ngayHT, "BHYT NLĐ đóng Tháng " + cboThang.Text + "", "334", "3384"
                        , bhytNLD);
                    _KT_CTuGocRepo.InsertChiPhiLuong("CPL", "1/1", ngayHT, "BHTN NLĐ đóng Tháng " + cboThang.Text + "", "334", "3389"
                        , bhtnNLD);
                    return true;
                }
                else
                {
                    MessageBox.Show("Bảng LƯƠNG tháng này chưa có. Không thể cập nhật vào SỔ CHỨNG TỪ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                var listBangLuong = _KTBANGLUONGRepo.DanhSachBangLuong(txtNam.Text, cboThang.Text);
                if (listBangLuong != null)
                {
                    _KT_CTuGocRepo.DeleteByMaCT("CPL", Utils.CIntDef(cboThang.Text, 0), Utils.CIntDef(txtNam.Text, 0));
                    for (int i = 0; i < listBangLuong.Count; i++)
                    {
                        string name = listBangLuong[i].TEN_NV_VIET;
                        double tongLuong = Utils.CDblDef(listBangLuong[i].TONG_LUONG, 0);
                        double tongLuongTN = Utils.CDblDef(listBangLuong[i].LUONG_TN, 0);
                        double bhxhCty = Utils.CDblDef(listBangLuong[i].BHXH_CTY, 0);
                        double bhytCty = Utils.CDblDef(listBangLuong[i].BHYT_CTY, 0);
                        double bhxhNLD = Utils.CDblDef(listBangLuong[i].BHXH_NLD, 0);
                        double bhytNLD = Utils.CDblDef(listBangLuong[i].BHYT_NLD, 0);
                        double bhtnNLD = Utils.CDblDef(listBangLuong[i].BHTN_NLD, 0);
                        _KT_CTuGocRepo.InsertChiPhiLuong("CPL", "1/1", ngayHT, "Phải trả lương Tháng " + cboThang.Text + " cho : " + name + ""
                            , "6422", "334", chkLuongThucNhan.Checked ? tongLuongTN : tongLuong);
                        _KT_CTuGocRepo.InsertChiPhiLuong("CPL", "1/1", ngayHT, "BHXH công ty đóng Tháng " + cboThang.Text + " cho : " + name + ""
                            , "6422", "3383", bhxhCty);
                        _KT_CTuGocRepo.InsertChiPhiLuong("CPL", "1/1", ngayHT, "BHYT công ty đóng Tháng " + cboThang.Text + " cho : " + name + ""
                            , "6422", "3384", bhytCty);
                        _KT_CTuGocRepo.InsertChiPhiLuong("CPL", "1/1", ngayHT, "BHXH NLĐ đóng Tháng " + cboThang.Text + " cho : " + name + ""
                            , "334", "3383", bhxhNLD);
                        _KT_CTuGocRepo.InsertChiPhiLuong("CPL", "1/1", ngayHT, "BHYT NLĐ đóng Tháng " + cboThang.Text + " cho : " + name + ""
                            , "334", "3384", bhytNLD);
                        _KT_CTuGocRepo.InsertChiPhiLuong("CPL", "1/1", ngayHT, "BHTN NLĐ đóng Tháng " + cboThang.Text + " cho : " + name + ""
                            , "334", "3389", bhtnNLD);
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Bảng LƯƠNG tháng này chưa có. Không thể cập nhật vào SỔ CHỨNG TỪ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Đã hạch toán CHI PHÍ LƯƠNG và CÁC KHOẢN TRÍCH THEO LƯƠNG xong. Bạn hãy kiểm tra lại trong SỔ CHỨNG TỪ GỐC!", "Thông báo");
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