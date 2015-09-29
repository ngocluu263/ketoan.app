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

namespace ketoansoft.app
{
    public partial class SOCTCN19 : Form
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KT_CTuGocRepo _KT_CTuGocRepo = new KT_CTuGocRepo();
        private KTTKRepo _KTTKRepo = new KTTKRepo();
        private KTDTPNRepo _KTDTPNRepo = new KTDTPNRepo();
        public SOCTCN19()
        {
            InitializeComponent();
        }

        private void SOCTCN19_Load(object sender, EventArgs e)
        {
            loaddtpNgay();
            LoadTK();
            LoadDT();
            cboThang.Text = fTerm._month;
            cboLoaitien.Text = "1";
            cboNgonngu.Text = "1";
            cboExportsangExcel.Text = "F";
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
        private void LoadDT()
        {
            _KTDTPNRepo = new KTDTPNRepo();
            cboMaDT.DisplayMember = "MA_DTPN";
            cboMaDT.ValueMember = "ID";
            cboMaDT.DropDownColumns = "MA_DTPN,TEN_DTPN";
            cboMaDT.DataSource = _KTDTPNRepo.GetAll();
            cboMaDT.SelectedIndex = -1;
        }
        private void cboMaDT_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_DTPN")
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
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("DTPN"), new DataColumn("TK"), new DataColumn("LOAI_CT"), new DataColumn("SO_CT"), new DataColumn("NGAY_CT"), 
                new DataColumn("SO_HOADON"), new DataColumn("NGAY_HOADON"),new DataColumn("TEN_KH"),new DataColumn("NGUOI_GD"), new DataColumn("MA_CTRINH"), new DataColumn("MUA"),    
                new DataColumn("MADM"), new DataColumn("DIENGIAI"), new DataColumn("DONVI"), new DataColumn("SOLUONG", System.Type.GetType("System.Double")), new DataColumn("DAI"),
                new DataColumn("RONG"), new DataColumn("SOM2"), new DataColumn("DONGIA", System.Type.GetType("System.Double")), new DataColumn("TKDU"), new DataColumn("NO_VND",System.Type.GetType("System.Double")),
                new DataColumn("NO_CUOIKY_VND", System.Type.GetType("System.Double")), new DataColumn("CO_CUOIKY_VND", System.Type.GetType("System.Double")), 
                new DataColumn("MAHH"), new DataColumn("TENHH"),
                new DataColumn("CO_VND", System.Type.GetType("System.Double")), new DataColumn("NO_USD", System.Type.GetType("System.Double")), new DataColumn("CO_USD", System.Type.GetType("System.Double")) });

            _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
            var list = this._db.KT_CTuGocs.Where(u => u.NGAY_CTU.Value != null && u.NGAY_CTU.Value.Date >= dtpTuNgay.Value.Date && u.NGAY_CTU.Value.Date <= dtpDenngay.Value.Date
                && (u.TK_NO == cboTaikhoan.Text || cboTaikhoan.Text == "") && (u.MA_DTPN_NO == cboMaDT.Text || cboMaDT.Text == ""));
            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                dr["DTPN"] = item.MA_DTPN_NO;
                dr["MA_CTRINH"] = item.MA_CTRINH;
                dr["TK"] = item.TK_NO;
                dr["LOAI_CT"] = item.MA_CTU;
                dr["SO_CT"] = item.SO_CTU;
                dr["NGAY_CT"] = item.NGAY_CTU;
                dr["SO_HOADON"] = item.HD_SO;
                dr["NGAY_HOADON"] = item.HD_NGAY;
                dr["TEN_KH"] = item.TEN_KH;
                dr["NGUOI_GD"] = item.TEN_KH_GD;
                dr["MADM"] = item.MA_DM_XUAT;
                dr["MAHH"] = "";
                dr["TENHH"] = "";
                dr["DIENGIAI"] = item.DIEN_GIAI;
                dr["DONVI"] = item.DON_VI1;
                dr["SOLUONG"] = Utils.CDblDef(item.SO_LUONG, 0);
                dr["DAI"] = "";
                dr["RONG"] = "";
                dr["SOM2"] = "";
                dr["DONGIA"] = Utils.CDblDef(item.DON_GIA_VND, 0);
                dr["TKDU"] = item.TK_CO;
                dr["MUA"] = Utils.CDblDef(150000, 0);
                dr["NO_CUOIKY_VND"] = Utils.CDblDef(150000, 0);
                dr["CO_CUOIKY_VND"] = Utils.CDblDef(150000, 0);
                dr["NO_VND"] = Utils.CDblDef(150000, 0);
                dr["CO_VND"] = Utils.CDblDef(150000, 0);
                dr["NO_USD"] = Utils.CDblDef(150000, 0);
                dr["CO_USD"] = Utils.CDblDef(150000, 0);
                dt.Rows.Add(dr);
            }

            ExcelUtlity Utlity = new ExcelUtlity();
            if (rdMauchuan.Checked)
                Utlity.WriteDataTableToExcel_SOCTCN19_01_V_Mauchuan(dt, cboTaikhoan.Text, cboMaDT.Text, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
            else if (rdChitiettheosohoadon.Checked)
                Utlity.WriteDataTableToExcel_SOCTCN26_Chitiettheosohoadon(dt, cboTaikhoan.Text, cboMaDT.Text, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
            else if (rdChitiettheosohoadonhanghoa.Checked)
                Utlity.WriteDataTableToExcel_SOCTCN27_Chitiettheosohoadonhanghoa(dt, cboTaikhoan.Text, cboMaDT.Text, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
            else if (rdChitiettheohanghoa.Checked)
                Utlity.WriteDataTableToExcel_SOCTCN19_04_Chitiettheohanghoa(dt, cboTaikhoan.Text, cboMaDT.Text, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
            else if (rdChitiettheosohoadon2.Checked)
                Utlity.WriteDataTableToExcel_SOCTCN26_Chitiettheosohoadon(dt, cboTaikhoan.Text, cboMaDT.Text, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
            else
                Utlity.WriteDataTableToExcel_SOCTCN19_01_V_Mauchuan(dt, cboTaikhoan.Text, cboMaDT.Text, dtpTuNgay.Value, dtpDenngay.Value, dtNgayin.Value);
        }
        #endregion

    }
}
