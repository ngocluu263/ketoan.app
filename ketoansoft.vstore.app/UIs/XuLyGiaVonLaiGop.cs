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
    public partial class XuLyGiaVonLaiGop : DevComponents.DotNetBar.Metro.MetroForm
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        KT_CTuGocRepo _KT_CTuGocRepo = new KT_CTuGocRepo();

        public XuLyGiaVonLaiGop()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Info()
        {
            cboThang.Text = Utils.CStrDef(fTerm._month, "");
        }
        private int Save_Data()
        {
            int _thang = Utils.CIntDef(cboThang.Text,0);
            int _nam = Utils.CIntDef(fTerm._year,0);
            if (rdo1.Checked)
            {
                int processHDBR = _KT_CTuGocRepo.GetByHDBR("HDBR",_thang,_nam);
                if (processHDBR > 0)
                {
                    return processHDBR;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dòng nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                var listBangLuong = "";
                if (listBangLuong != null)
                {
                    
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dòng nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return 0;
        }
        #endregion

        #region Event
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int temp = Save_Data();
            if ( temp > 0)
            {
                MessageBox.Show("Đã xử lý xong giá vốn và lãi gộp của những bút toán doanh thu.\nSố dòng đã xử lý: " + temp + "", "Thông báo");
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void XuLyGiaVonLaiGop_Load(object sender, EventArgs e)
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