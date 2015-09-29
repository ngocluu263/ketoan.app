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
    public partial class HachToanTraTienLuong : DevComponents.DotNetBar.Metro.MetroForm
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        KTBANGLUONGRepo _KTBANGLUONGRepo = new KTBANGLUONGRepo();
        KT_CTuGocRepo _KT_CTuGocRepo = new KT_CTuGocRepo();

        public HachToanTraTienLuong()
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
            DateTime ngayHT = GetLastDayOfMonth(DateTime.ParseExact("01/" + cboThang.Text + "/" + txtNam.Text + "", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            if (rdo1.Checked)
            {
                double tongLuongTN = _KTBANGLUONGRepo.TongLuongTN(txtNam.Text, cboThang.Text);
                if (tongLuongTN > 0)
                {
                    _KT_CTuGocRepo.DeleteByMaCT("PC", Utils.CIntDef(cboThang.Text, 0), Utils.CIntDef(txtNam.Text, 0));
                    _KT_CTuGocRepo.InsertChiPhiLuong("PC", "1/1", ngayHT, "TT tiền lương tháng " + cboThang.Text + " năm " + txtNam.Text + ""
                        , "334", "1111", tongLuongTN);
                    return true;
                }
                else
                {
                    MessageBox.Show("Bảng LƯƠNG tháng này chưa có. Không thể cập nhật vào SỔ CHỨNG TỪ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (rdo2.Checked)
            {
                var listBangLuong = _KTBANGLUONGRepo.LuongTheoPhongBan(txtNam.Text, cboThang.Text);
                if (listBangLuong != null)
                {
                    _KT_CTuGocRepo.DeleteByMaCT("PC", Utils.CIntDef(cboThang.Text, 0), Utils.CIntDef(txtNam.Text, 0));
                    for (int i = 0; i < listBangLuong.Rows.Count; i++)
                    {
                        string maPhongBan = Utils.CStrDef(listBangLuong.Rows[i]["PHONG_BAN"], "");
                        string tenPhongBan = Utils.CStrDef(listBangLuong.Rows[i]["TEN_PHONG_BAN"],"");
                        double tongLuongTN = Utils.CDblDef(listBangLuong.Rows[i]["TLuong"], 0);
                        _KT_CTuGocRepo.InsertLuongTheoPhongBan("PC", "1/1", ngayHT, "TT tiền lương tháng " + cboThang.Text + " năm " + txtNam.Text + " cho : " + tenPhongBan + ""
                        , "334", "1111", tongLuongTN, maPhongBan);
                    }
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
                    _KT_CTuGocRepo.DeleteByMaCT("PC", Utils.CIntDef(cboThang.Text, 0), Utils.CIntDef(txtNam.Text, 0));
                    for (int i = 0; i < listBangLuong.Count; i++)
                    {
                        string tenNV = listBangLuong[i].TEN_NV_VIET;
                        string maNV = listBangLuong[i].MA_NV;
                        double tongLuongTN = Utils.CDblDef(listBangLuong[i].LUONG_TN, 0);
                        _KT_CTuGocRepo.InsertChiPhiLuong("PC", "1/1", ngayHT, "TT tiền lương tháng " + cboThang.Text + " năm " + txtNam.Text + " cho : " + maNV + " - " + tenNV + ""
                        , "334", "1111", tongLuongTN);
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
                MessageBox.Show("Đã hạch toán CHI LƯƠNG xong. Bạn hãy kiểm tra lại trong SỔ CHỨNG TỪ GỐC!", "Thông báo");
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