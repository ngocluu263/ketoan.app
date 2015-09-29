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
    public partial class TinhSoNgayCong : DevComponents.DotNetBar.Metro.MetroForm
    {
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        KTCHAMCONGRepo _KTCHAMCONGRepo = new KTCHAMCONGRepo();
        KTMACONGRepo _KTMACONGRepo = new KTMACONGRepo();

        public TinhSoNgayCong()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Info()
        {
            txtNam.Text = Utils.CStrDef(fTerm._year, "");
            cboThang.Text = Utils.CStrDef(fTerm._month, "");
        }
        private void Save_Data()
        {
            if (_KTCHAMCONGRepo.CapNhatNgayCong(txtNam.Text, cboThang.Text))
                MessageBox.Show("Đã tính ngày công tháng " + cboThang.Text + " năm " + txtNam.Text + "", "");
        }
        #endregion

        #region Event
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            Save_Data();
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
    }
}