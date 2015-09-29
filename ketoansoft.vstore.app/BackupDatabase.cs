using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ketoansoft.app
{
    public partial class BackupDatabase : Form
    {
        public BackupDatabase()
        {
            InitializeComponent();
        }

        private void btnChonthumuc_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lbDuongdan.Text = saveFileDialog1.FileName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lbDuongdan.Text.Length > 0)
            {


            }
        }
    }
}
