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
    public partial class SOCTCN14 : Form
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KT_CTuGocRepo _KT_CTuGocRepo = new KT_CTuGocRepo();
        private KTTKRepo _KTTKRepo = new KTTKRepo();
        private KTDTPNRepo _KTDTPNRepo = new KTDTPNRepo();
        public SOCTCN14()
        {
            InitializeComponent();
        }

        private void SOCTCN14_Load(object sender, EventArgs e)
        {
            loaddtpNgay();
            LoadTK();
            LoadDT();
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
            string tencongty = "CÔNG TY ABCDab";
            string diachi = "M17 LÊ HOÀNG PHÁI,GÒ VẤP,TP.HCM";
            string masothue = "Mã số thuế : 0300688235";
            string tungaydenngay = "Từ ngày 01/01/08 đến ngày 31/01/08";
            string ngayin = "Ngày 01 tháng 01 năm 2015";
            string taikhoan = "Tài khoản : 1112 - - Ngoại tệ";
            string dtpn = "Mã ĐTPN :  - ";

            _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
            var list = this._db.KT_CTuGocs.Where(u => u.NGAY_CTU.Value != null && u.NGAY_CTU.Value.Date >= dtpTuNgay.Value.Date && u.NGAY_CTU.Value.Date <= dtpDenngay.Value.Date 
                && (u.TK_NO == cboTaikhoan.Text || cboTaikhoan.Text == "") && (u.MA_DTPN_NO == cboMaDT.Text || cboMaDT.Text == ""));
                                    
            ExcelUtlity Utlity = new ExcelUtlity();
            if (rdMau1.Checked)
            {
                SOCTCN14_Mau1 report = new SOCTCN14_Mau1();
                report.lbTencongty.Text = tencongty;
                report.lbDiachi.Text = diachi;
                report.lbMasothue.Text = masothue;
                report.lbTungaydenngay.Text = tungaydenngay;
                report.lbNgayin.Text = ngayin;
                report.lbTaikhoan.Text = taikhoan;
                report.lbDtpn.Text = dtpn;

                report.DataSource = list;
                report.xrLoaiCT.DataBindings.Add("Text", list, "MA_CTU");
                report.xrSoCT.DataBindings.Add("Text", list, "SO_CTU");
                report.xrNgayCT.DataBindings.Add("Text", list, "NGAY_CTU", "{0:dd/MM/yyyy}");
                report.xrSoHD.DataBindings.Add("Text", list, "HD_SO");
                report.xrNgayHD.DataBindings.Add("Text", list, "HD_NGAY", "{0:dd/MM/yyyy}");
                report.xrDiengiai.DataBindings.Add("Text", list, "DIEN_GIAI");
                report.xrTenhanghoa.DataBindings.Add("Text", list, "TEN_HH_IN");
                report.xrTKDU.DataBindings.Add("Text", list, "TK_CO");
                //report.xrPhatsinhtrongkyNo.DataBindings.Add("Text", list, "HD_NGAY", "{0:###,###}");
                //report.xrPhatsinhtrongkyCo.DataBindings.Add("Text", list, "HD_NGAY", "{0:###,###}");
                //report.xrSoducuoikyNo.DataBindings.Add("Text", list, "HD_NGAY", "{0:###,###}");
                //report.xrSoducuoikyCo.DataBindings.Add("Text", list, "HD_NGAY", "{0:###,###}");
                report.ShowPreview();
            }
            else if (rdMau2.Checked)
            {
                SOCTCN14_Mau2 report = new SOCTCN14_Mau2();
                report.lbTencongty.Text = tencongty;
                report.lbDiachi.Text = diachi;
                report.lbMasothue.Text = masothue;
                report.lbTungaydenngay.Text = tungaydenngay;
                report.lbNgayin.Text = ngayin;
                report.lbTaikhoan.Text = taikhoan;
                report.lbDtpn.Text = dtpn;

                report.DataSource = list;
                report.xrNgay.DataBindings.Add("Text", list, "NGAY_CTU");
                report.xrTensanpham.DataBindings.Add("Text", list, "TEN_THANH_PHAM");
                //report.xrNgayCT.DataBindings.Add("Text", list, "NGAY_CTU", "{0:dd/MM/yyyy}");
                //report.xrSoHD.DataBindings.Add("Text", list, "HD_SO");
                //report.xrNgayHD.DataBindings.Add("Text", list, "HD_NGAY", "{0:dd/MM/yyyy}");
                //report.xrDiengiai.DataBindings.Add("Text", list, "DIEN_GIAI");
                //report.xrTenhanghoa.DataBindings.Add("Text", list, "TEN_HH_IN");
                //report.xrTKDU.DataBindings.Add("Text", list, "TK_CO");
                //report.xrPhatsinhtrongkyNo.DataBindings.Add("Text", list, "HD_NGAY", "{0:###,###}");
                //report.xrPhatsinhtrongkyCo.DataBindings.Add("Text", list, "HD_NGAY", "{0:###,###}");
                //report.xrSoducuoikyNo.DataBindings.Add("Text", list, "HD_NGAY", "{0:###,###}");
                //report.xrSoducuoikyCo.DataBindings.Add("Text", list, "HD_NGAY", "{0:###,###}");
                report.ShowPreview();
            } 
        }
        #endregion

    }
}
