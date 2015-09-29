using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using ketoansoft.app.Class.Data;
using System.Drawing;
using DevExpress.XtraGrid;
using System.Collections;
using System.IO;
using System.Xml;

namespace ketoansoft.app.Class.Global
{
    public class Unit
    {
        /// <summary>
        /// Set allow is edit on/off
        /// </summary>
        /// <param name="grv">Set allow is edit on/off</param>
        public virtual void Get_AllowEdit(GridView grv)
        {
            string msg = "";
            if (grv.OptionsBehavior.Editable)
            {
                grv.OptionsBehavior.Editable = false;
                msg = "Đã tắt chế độ chỉnh sửa!";
            }
            else
            {
                grv.OptionsBehavior.Editable = true;
                msg = "Đã bật chế độ chỉnh sửa!";
            }
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Check row is tick, set color style
        /// </summary>
        /// <param name="grv">Check row is tick, set color style</param>
        public virtual void Get_ColorTick(GridView grv, object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DANH_DAU"]);
                if (category == "T")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
            }
        }
        /// <summary>
        /// Unit GridView style Font, color, width 
        /// </summary>
        /// <param name="grv">Unit GridView style Font, color, width</param>
        public static void UnitGridview(GridView grv)
        {
            grv.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            for (int i = 0; i < grv.Columns.Count; i++)
            {
                grv.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F);
            }
            //grv.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 12);
            grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25F);
            grv.ColumnPanelRowHeight = 45;
            grv.RowHeight = 30;

            grv.OptionsPrint.UsePrintStyles = true;
            grv.AppearancePrint.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            grv.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            grv.OptionsView.AllowHtmlDrawHeaders = true;
            grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
        }
        /// <summary>
        /// Check form is actived, opened
        /// </summary>
        /// <param name="FormeName">Check form is actived, opened</param>
        public static bool IsFormActived(string FormName)
        {
            try
            {
                FormName = EmptyNull(FormName).ToLower();
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i].Name.ToString().ToLower() == FormName)                 
                    {
                        Application.OpenForms[FormName].Activate();
                        return true;
                    }
                }
            }
            catch { return false; }
            return false;
        }
        /// <summary>
        /// Read XML Activate info
        /// </summary>
        /// <param name="ReadDatabaseXML">Read XML Activate info</param>
        public static ArrayList ReadActivateXML()
        {
            String path = Application.StartupPath + Const.ACTIVATEXML_FILEPATH;
            if (!File.Exists(path)) return null;
            int count = 0;
            ArrayList Arr = new ArrayList();
            XmlTextReader xml = new XmlTextReader(path);
            while (xml.Read())
            {
                switch (xml.NodeType)
                {
                    case XmlNodeType.Text:
                        path = EmptyNull(xml.Value);
                        if (path != "")
                        {
                            Arr.Insert(count, path);
                            count++;
                        }
                        break;
                }
            }
            xml.Close();
            return Arr;
        }
        /// <summary>
        /// Read XML Database info
        /// </summary>
        /// <param name="ReadDatabaseXML">Read XML Database info</param>
        public static ArrayList ReadDatabaseXML()
        {
            String path = Application.StartupPath + Const.DATABASEXML_FILEPATH;
            if (!File.Exists(path)) return null;
            int count = 0;
            ArrayList Arr = new ArrayList();
            XmlTextReader xml = new XmlTextReader(path);
            while (xml.Read())
            {
                switch (xml.NodeType)
                {
                    case XmlNodeType.Text:
                        path = EmptyNull(xml.Value);
                        if (path != "")
                        {
                            Arr.Insert(count, path);
                            count++;
                        }
                        break;
                }
            }
            xml.Close();
            return Arr;
        }
        /// <summary>
        /// Write XML Database info
        /// </summary>
        /// <param name="ReadDatabaseXML">Write XML Database info</param>
        public static void WriteDatabaseXML(string ServerName, string DatabaseName, string UserName, string Password)
        {
            try
            {
                String path = Application.StartupPath + Const.DATABASEXML_FILEPATH;
                if (!File.Exists(path)) return;
                XmlTextWriter xml = new XmlTextWriter(path, Encoding.UTF8);
                xml.Formatting = Formatting.Indented;
                xml.WriteStartDocument();
                xml.WriteStartElement("HTKK");
                xml.WriteStartElement("ConnectDB");
                xml.WriteElementString("ServerName", ServerName);
                xml.WriteElementString("DatabaseName", DatabaseName);
                xml.WriteElementString("UserName", UserName);
                xml.WriteElementString("Password", Password);
                xml.WriteEndElement();//ConnectDB
                xml.WriteEndElement();//HTKK
                xml.WriteEndDocument();
                xml.Close();
            }
            catch { }
        }
        /// <summary>
        /// Convert object to string
        /// </summary>
        /// <param name="sInfo">Convert object to string </param>
        public static string EmptyNull(object sInfo)
        {
            if (sInfo == null) return "";
            return sInfo.ToString().Trim();
        }
        /// <summary>
        /// Get database name
        /// </summary>
        /// <param>Get database name</param>
        public static string Get_DatabaseName()
        {
            string temp = "";
            if (ReadDatabaseXML().Count > 0)
                temp = ReadDatabaseXML()[1].ToString();
            return temp;
        }
        /// <summary>
        /// Get company name
        /// </summary>
        /// <param>Get company name, default idv = ID01 </param>
        public static string Get_CompanyName()
        {
            CFGRepo _CFGRepo = new CFGRepo();
            return _CFGRepo.GetNameByIDV("ID01");
        }
        /// <summary>
        /// Set info rows[]
        /// </summary>
        /// <param name="grv">Set info focus rowcell, default display three cell the first</param>
        public static string Get_InfoRows(GridView grv, string[] arr)
        {
            string str = "";
            if (arr != null && arr.Length > 0)
            {
                for (int i = 0; i < arr.Count(); i++)
                {
                    str += "[" + grv.GetFocusedRowCellValue(arr[i]) + "]  ";
                }                
            }
            else
            {
                int count = 3;
                if (grv.Columns.Count < 3)
                    count = grv.Columns.Count;
                for (int i = 0; i < count; i++)
                {
                    str += "[" + grv.GetFocusedRowCellValue(grv.Columns[i]) + "]  ";
                }
            }
            return str;
        }
        public static void Get_FormatType(GridView grv, string[] arr, DevExpress.Utils.FormatType type, string sformat)
        {
            if (arr != null && arr.Length > 0)
            {
                for (int i = 0; i < grv.Columns.Count; i++)
                {
                    for (int j = 0; j < arr.Count(); j++)
                    {
                        if (grv.Columns[i].Name == arr[j])
                        {
                            grv.Columns[i].DisplayFormat.FormatType = type;
                            grv.Columns[i].DisplayFormat.FormatString = sformat;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Print Preview GridView
        /// </summary>
        /// <param name="grid">PrintPreview GridView</param>
        public void ShowGridPreview(GridView grid)
        {
            // Open the Preview window.
            grid.ShowPrintPreview();
        }
        /// <summary>
        /// Print GridView
        /// </summary>
        /// <param name="grid">Print GridView</param>
        public void PrintGrid(GridView grid)
        {
            // Print.
            grid.Print();
        }
        /// <summary>
        /// Print Preview gridcontrol
        /// </summary>
        /// <param name="grid">PrintPreview GridControl</param>
        public void ShowGridPreview(GridControl grid)
        {
            // Check whether the GridControl can be previewed.
            if (!grid.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                return;
            }

            // Open the Preview window.
            grid.ShowPrintPreview();
        }
        /// <summary>
        /// Print gridcontrol
        /// </summary>
        /// <param name="grid">Print GridControl</param>
        public void PrintGrid(GridControl grid)
        {
            // Check whether the GridControl can be printed.
            if (!grid.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                return;
            }

            // Print.
            grid.Print();
        }

        public double Round(double value, int digits)
        {
            if (digits >= 0) return System.Math.Round(value, digits);

            double n = System.Math.Pow(10, -digits);
            return System.Math.Round(value / n, 0) * n;
        }
    }
}
