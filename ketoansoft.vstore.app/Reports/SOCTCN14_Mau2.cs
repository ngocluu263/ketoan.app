using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
namespace ketoansoft.app.Reports
{
    public partial class SOCTCN14_Mau2 : DevExpress.XtraReports.UI.XtraReport
    {
        public SOCTCN14_Mau2()
        {
            InitializeComponent();            
        }
        int counter = 0;
        private void xrSTT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter++;
            ((XRLabel)sender).Text = string.Format("{0}", counter);
        }

    }
}
