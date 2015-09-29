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
using DevExpress.XtraGrid.Columns;
using System.Threading;

namespace ketoansoft.app.UIs
{
    public partial class QuanTriDataNguoc : Form
    {
        dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTXuLySoDuRepo _KTXuLySoDuRepo = new KTXuLySoDuRepo();
        public QuanTriDataNguoc()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Data()
        {
            cboThang.Text = Utils.CStrDef(fTerm._month, "");

            DateTime dt = dtpTuNgay.Value;
            dt = new DateTime(dt.Year, Utils.CIntDef(cboThang.Text, 0), 1);
            dtpTuNgay.Value = dt;
            dtpDenNgay.Value = GetLastDayOfMonth(dt);

            Load_InfoRows();
        }

        private void Load_Grid()
        {
            DateTime ngayBD = DateTime.ParseExact(dtpTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime ngayKT = DateTime.ParseExact(dtpDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (rdo01.Checked)
            {
                gridData1.DataSource = null;
                lblTitle.Text = String.Format("Xem số dư tài khoản từ ngày {0} đến {1}", dtpTuNgay.Text, dtpDenNgay.Text);

                //Xử lý dữ liệu vào KT_SoDu_TK
                _KTXuLySoDuRepo.DeleteSoDuTk(ngayBD, ngayKT);
                _KTXuLySoDuRepo.InsertSoDuTk(ngayBD, ngayKT);
                var obj = _KTXuLySoDuRepo.GetSoDuTk(ngayBD, ngayKT);
                if (obj != null)
                {
                    gridData1.DataSource = obj;
                }
            }
        }
        #endregion

        #region Funtion
        private static DateTime GetLastDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }
        private void Set_Field(string[] _fieldName, string[] _caption)
        {
            if (gridView1.Columns.Count <= 0)
            {
                for (int i = 0; i < _fieldName.Count(); i++)
                {
                    GridColumn column = gridView1.Columns.Add();
                    column.Caption = _caption[i];
                    column.FieldName = _fieldName[i];
                    column.Visible = true;
                }
            }
        }
        
        #endregion

        #region Event
        private void QuanTriDataNguoc_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dt = dtpTuNgay.Value;
            dt = new DateTime(dt.Year, Utils.CIntDef(cboThang.Text, 0), 1);
            dtpTuNgay.Value = dt;
            dtpDenNgay.Value = GetLastDayOfMonth(dt);
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            Load_Grid();
            tabControl1.SelectedTabIndex = 1;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Load_InfoRows()
        {
            string[] _arrFormatNum = { "VND_DU_NO", "VND_DU_CO", "VND_PS_NO", "VND_PS_CO", "VND_CK_NO", "VND_CK_CO"};
            Unit.Get_FormatType(gridView1, _arrFormatNum, DevExpress.Utils.FormatType.Custom, "{0:###,##0}");
        }
        #endregion
    }
}
