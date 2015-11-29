using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ketoansoft.app.Class.Global;
using ketoansoft.app.Components.clsVproUtility;
using ketoansoft.app.Class.Data;

namespace ketoansoft.app.ReportsForm
{
    public partial class InConDoiPhatSinhTK : Form
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        KTXuLySoDuRepo _KTXuLySoDuRepo = new KTXuLySoDuRepo();
        public InConDoiPhatSinhTK()
        {
            InitializeComponent();
        }
        private void InConDoiPhatSinhTK_Load(object sender, EventArgs e)
        {
            loaddtpNgay();
        }
        #region process datetime
        private DateTime GetFirstDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }
        private DateTime GetFirstDayOfMonth(int iMonth)
        {
            DateTime dtResult = new DateTime(Utils.CIntDef(fTerm._year, 0), iMonth, 1);
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }
        private DateTime GetLastDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }
        private DateTime GetLastDayOfMonth(int iMonth)
        {
            DateTime dtResult = new DateTime(Utils.CIntDef(fTerm._year, 0), iMonth, 1);
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }
        private void loaddtpNgay()
        {
            dtpTuNgay.Value = GetFirstDayOfMonth(Utils.CIntDef(fTerm._month, 0));
            dtpDenngay.Value = GetLastDayOfMonth(Utils.CIntDef(fTerm._month, 0));
            dtNgayin.Value = DateTime.Now;
        }
        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpTuNgay.Value = GetFirstDayOfMonth(Utils.CIntDef(cboThang.Text, 1));
            dtpDenngay.Value = GetLastDayOfMonth(Utils.CIntDef(cboThang.Text, 1));
        }
        #endregion

        #region btn Click
        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DateTime ngayBD = DateTime.ParseExact(dtpTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime ngayKT = DateTime.ParseExact(dtpDenngay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //Xử lý dữ liệu vào KT_SoDu_TK
            _KTXuLySoDuRepo.DeleteSoDuTk(ngayBD, ngayKT);
            _KTXuLySoDuRepo.InsertSoDuTk(ngayBD, ngayKT);

            dt.Columns.AddRange(new DataColumn[] { new DataColumn("MA_TK"), new DataColumn("TEN_TK")
                , new DataColumn("VND_DU_NO", System.Type.GetType("System.Double")), new DataColumn("VND_DU_CO", System.Type.GetType("System.Double"))
                , new DataColumn("VND_PS_NO", System.Type.GetType("System.Double")), new DataColumn("VND_PS_CO", System.Type.GetType("System.Double"))
                , new DataColumn("VND_CK_NO", System.Type.GetType("System.Double")), new DataColumn("VND_CK_CO", System.Type.GetType("System.Double"))});
            _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
            var list = _KTXuLySoDuRepo.GetSoDuTk(ngayBD, ngayKT);
            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                dr["MA_TK"] = item.MA_TK;
                dr["TEN_TK"] = item.TEN_TK;
                dr["VND_DU_NO"] = Utils.CDblDef(item.VND_DU_NO, 0);
                dr["VND_DU_CO"] = Utils.CDblDef(item.VND_DU_CO, 0);
                dr["VND_PS_NO"] = Utils.CDblDef(item.VND_PS_NO, 0);
                dr["VND_PS_CO"] = Utils.CDblDef(item.USD_PS_CO, 0);
                dr["VND_CK_NO"] = Utils.CDblDef(item.VND_CK_NO, 0);
                dr["VND_CK_CO"] = Utils.CDblDef(item.VND_CK_CO, 0);
                dt.Rows.Add(dr);
            }

            ExcelUtlity Utlity = new ExcelUtlity();
            if (rdMau1.Checked)
                Utlity.WriteDataTableToExcel_InCanDoiPhatSinhTaiKhoan_Mau1(dt, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
            else
                Utlity.WriteDataTableToExcel_InCanDoiPhatSinhTaiKhoan_Mau1(dt, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
