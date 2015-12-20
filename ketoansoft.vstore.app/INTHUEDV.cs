using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ketoansoft.app.Components.clsVproUtility;
using ketoansoft.app.Class.Global;
using ketoansoft.app.Class.Data;
using ketoansoft.app.Reports;

namespace ketoansoft.app
{
    public partial class INTHUEDV : Form
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KT_CTuGocRepo _KT_CTuGocRepo = new KT_CTuGocRepo();
        private KTTKRepo _KTTKRepo = new KTTKRepo();
        private KTDTPNRepo _KTDTPNRepo = new KTDTPNRepo();
        public INTHUEDV()
        {
            InitializeComponent();
        }

        private void SOCTCN20_Load(object sender, EventArgs e)
        {
            loaddtpNgay();
            LoadTK();
            cboThang.Text = fTerm._month;
        }

        #region load data
        private void LoadTK()
        {
            _KTTKRepo = new KTTKRepo();

            cboTaikhoan.DisplayMember = "MA_TK";
            cboTaikhoan.ValueMember = "ID";
            cboTaikhoan.DropDownColumns = "MA_TK,TEN_TK";
            cboTaikhoan.DataSource = _KTTKRepo.GetAll();
            cboTaikhoan.SelectedIndex = -1;
        }
        private void cboTaikhoan_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_TK")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        #endregion

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
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("DTPN"), new DataColumn("TK"), new DataColumn("MA_HD"), new DataColumn("SO_CT"), new DataColumn("NGAY_CT"), new DataColumn("HD_SR"), 
                new DataColumn("SO_HOADON"), new DataColumn("NGAY_HOADON"),new DataColumn("TEN_KH"),new DataColumn("TEN_NV_BAN"), new DataColumn("MA_CTRINH"), new DataColumn("MASO_THUE"),  
                new DataColumn("MAT_HANG"), new DataColumn("TS_GTGT"), new DataColumn("DIA_CHI"), new DataColumn("SOLUONG", System.Type.GetType("System.Double")), new DataColumn("DAI"), new DataColumn("RONG"), 
                new DataColumn("GHI_CHU"), new DataColumn("DONGIA", System.Type.GetType("System.Double")), new DataColumn("THANH_TIEN_VND")
                , new DataColumn("TIEN_THUE_VND",System.Type.GetType("System.Double")), new DataColumn("CO_VND", System.Type.GetType("System.Double")), new DataColumn("NO_USD", System.Type.GetType("System.Double")), new DataColumn("CO_USD", System.Type.GetType("System.Double")) });

            _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
            var list = this._db.KT_CTuGocs.Where(u => u.NGAY_CTU.Value != null && u.NGAY_CTU.Value.Date >= dtpTuNgay.Value.Date && u.NGAY_CTU.Value.Date <= dtpDenngay.Value.Date
                && (u.TK_NO == cboTaikhoan.Text || cboTaikhoan.Text == "")
                && (u.LOAI_THUE.Substring(0, 1) == "V" || u.LOAI_THUE == "NK")
                && ((rdMau3.Checked)?u.TS_GTGT == "0": true)
                && ((rdMau4.Checked) ? u.TS_GTGT == "5" : true)
                && ((rdMau5.Checked) ? u.TS_GTGT == "10" : true));
            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                dr["DTPN"] = item.MA_DTPN_NO;
                dr["MA_CTRINH"] = item.MA_CTRINH;
                dr["TK"] = item.TK_NO;
                dr["MA_HD"] = item.MA_HD;
                dr["SO_CT"] = item.SO_CTU;
                dr["NGAY_CT"] = item.NGAY_CTU;
                dr["HD_SR"] = item.HD_SR;
                dr["SO_HOADON"] = item.HD_SO;
                dr["NGAY_HOADON"] = item.HD_NGAY;
                dr["TEN_KH"] = item.TEN_KH;
                dr["TEN_NV_BAN"] = item.TEN_NV_BAN;
                dr["MASO_THUE"] = item.MASO_THUE;
                dr["MAT_HANG"] = item.MA_DM_XUAT;
                dr["TS_GTGT"] = item.TS_GTGT;
                dr["DIA_CHI"] = item.DIA_CHI;
                dr["SOLUONG"] = Utils.CDblDef(item.SO_LUONG, 0);
                dr["DONGIA"] = Utils.CDblDef(item.DON_GIA_VND, 0);
                dr["THANH_TIEN_VND"] = item.THANH_TIEN_VND;
                dr["TIEN_THUE_VND"] = item.TIEN_THUE_VND;
                dr["GHI_CHU"] = item.GHI_CHU;
                dt.Rows.Add(dr);
            }

            ExcelUtlity Utlity = new ExcelUtlity();
            if (rdMau1.Checked)
                Utlity.WriteDataTableToExcel_THUEDV_Mau1(dt, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
            if (rdMau2.Checked)
                Utlity.WriteDataTableToExcel_THUEDV_Mau2(dt, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
            if (rdMau3.Checked)
                Utlity.WriteDataTableToExcel_THUEDV_Mau1(dt, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
            if (rdMau4.Checked)
                Utlity.WriteDataTableToExcel_THUEDV_Mau1(dt, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
            if (rdMau5.Checked)
                Utlity.WriteDataTableToExcel_THUEDV_Mau1(dt, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
            else
                Utlity.WriteDataTableToExcel_THUEDV_Mau1(dt, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
        }
        #endregion

    }
}