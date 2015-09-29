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
    public partial class XuLyKhauHao : DevComponents.DotNetBar.Metro.MetroForm
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        KTTSCDRepo _KTTSCDRepo = new KTTSCDRepo();
        KT_CTuGocRepo _KT_CTuGocRepo = new KT_CTuGocRepo();

        public XuLyKhauHao()
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
            try
            {
                _KTTSCDRepo.DeleteByThangNam(txtNam.Text, cboThang.Text);
                if (_KTTSCDRepo.InsertDuplicateTSCD(txtNam.Text, cboThang.Text))
                    return true;
                else return false;
            }
            catch { return false; }
        }
        #endregion

        #region Event
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn khấu hao TSCĐ tháng " + cboThang.Text + "?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Save_Data())
                {
                    MessageBox.Show("Đã khấu hao tài sản cố định xong.", "Thông báo");
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void XuLyKhauHao_Load(object sender, EventArgs e)
        {
            Load_Info();
        }
        #endregion

    }
}