using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using ketoansoft.app.Components.clsVproUtility;

namespace ketoansoft.app.Diaglog
{
    public partial class dlogToCol : Form
    {
        GridView _grv = new GridView();
        public dlogToCol(GridView grv)
        {
            _grv = grv;
            InitializeComponent();
        }

        private void dlogToCol_Load(object sender, EventArgs e)
        {
            Load_DataCol(_grv, cboMain);
        }

        #region shortcutKey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);
            if (e.KeyCode == Keys.Enter)
            {
                Result = Utils.CStrDef(cboMain.SelectedValue, "");
                this.Dispose();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Funtion
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public string Result
        {
            get;
            protected set;
        }
        #endregion

        #region Data
        private void Load_DataCol(GridView _grv, ComboBox cb)
        {
            Dictionary<string, string> _listCol = new Dictionary<string, string>();
            int _numCol = _grv.Columns.Count;
            for (int i = 0; i < _numCol; i++)
            {
                _listCol.Add(_grv.Columns[i].FieldName, _grv.Columns[i].Caption);
            }
            cb.DataSource = new BindingSource(_listCol, null);
            cb.DisplayMember = "Value";
            cb.ValueMember = "Key";
        }
        #endregion
    }
}
