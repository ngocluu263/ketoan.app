using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ketoansoft.app.Class.Global;
using ketoansoft.app.Components.clsVproUtility;

namespace ketoansoft.app
{
    public partial class fTerm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public static string _month = "1";
        public static string _year = "2015";
        public Unit _unit = new Unit();
        public fTerm()
        {
            InitializeComponent();
        }

        #region Funtion
        public fTerm(string month, string year)
        {
            month = _month;
            year = _year;
        }
        private void getTerm()
        {
            
            _month = cboThang.Text;
            _year = cboNam.Text;
        }
        #endregion

        #region Event
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cboThang.Text != "")
            {
                getTerm();
                this.Hide();
                if (fHome._IdAction != 112233)
                {
                    fHome _form = new fHome();
                    _form.ShowDialog();
                    this.Close();
                }
                else { this.Close(); }
            }
            else { MessageBox.Show("Xin chọn tháng!", "Thông báo"); }
        }
        
        private void fTerm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = Unit.Get_CompanyName();
            cboNam.Text = Utils.CStrDef(DateTime.Now.Year,"2015");
        }
        #endregion

        private void lnkChangeDB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Const.ISCHANGEDATABASE = true;
            fLogin _form = new fLogin();
            _form.ShowDialog();
            this.Close();
        }
    }
}