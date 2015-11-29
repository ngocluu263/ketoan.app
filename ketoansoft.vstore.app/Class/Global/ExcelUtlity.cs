using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using ketoansoft.app.Components.clsVproUtility;
using ketoansoft.app.Class.Data;

namespace ketoansoft.app.Class.Global
{
    public class ExcelUtlity
    {
        //mẫu
        public bool WriteDataTableToExcel(System.Data.DataTable dataTable)
        {
            string saveAsLocation = "";
            string worksheetName ="";
            string path = Application.StartupPath + @"\ExcelTemplate\SOCTCN11.xls";
            string cell1 = "";
            string cell2 = "";
            Microsoft.Office.Interop.Excel.Application excelApplication = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;

            excelApplication = new Microsoft.Office.Interop.Excel.Application();
            excelApplication.Visible = false;
            excelApplication.DisplayAlerts = false;
            try
            {
                workbook = excelApplication.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

                string cellValue = "";
                object cellObject = null;
                Microsoft.Office.Interop.Excel.Range range = null;
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[22, 1];
                cellObject = range.get_Value(null);
                cellValue = (cellObject == null ? "" : cellObject.ToString().Trim());
                cell1 = cellValue;

                cellValue = "";
                cellObject = null;
                range = null;
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[22, 2];
                cellObject = range.get_Value(null);
                cellValue = (cellObject == null ? "" : cellObject.ToString().Trim());
                cell2 = cellValue;


                excelApplication.Quit();
                excelApplication = null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;

                //gắn header
                excelSheet.Cells[1, 1] = cell1;
                excelSheet.Cells[1, 2] = cell2;

                // loop through each row and add values to our sheet
                int rowcount = 2;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        // on the first iteration we add the column headers
                        if (rowcount == 3)
                        {
                            excelSheet.Cells[2, i] = dataTable.Columns[i - 1].ColumnName;
                            excelSheet.Cells.Font.Color = System.Drawing.Color.Black;

                        }

                        excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();

                        //for alternate rows
                        if (rowcount > 3)
                        {
                            if (i == dataTable.Columns.Count)
                            {
                                if (rowcount % 2 == 0)
                                {
                                    excelCellrange = excelSheet.Range[excelSheet.Cells[rowcount, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                                    FormattingExcelCells(excelCellrange, "#CCCCFF", System.Drawing.Color.Black, false);
                                }

                            }
                        }

                    }

                }
                //gắn footer
                excelSheet.Cells[rowcount + 1, 1] = cell1;
                excelSheet.Cells[rowcount + 1, 2] = cell2;

                // now we resize the columns
                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                excelCellrange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;


                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[2, dataTable.Columns.Count]];
                FormattingExcelCells(excelCellrange, "#000099", System.Drawing.Color.White, true);


                //now save the workbook and exit Excel


                excelworkBook.SaveAs(saveAsLocation); ;
                excelworkBook.Close();
                excel.Quit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }

        }
        public void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }
        //1
        public bool WriteDataTableToExcel_SOCTCN11_Mauchuan(System.Data.DataTable dataTable, string taikhoan, string madtpn, DateTime from, DateTime to, DateTime print)
        {
            string saveAsLocation = Application.StartupPath + @"\Excel\SOCTCN11.xls";  
            string worksheetName = "SHVND";

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;
                excelSheet.PageSetup.Application.ActiveWindow.DisplayGridlines = false;

                #region General Cells
                //Kiểu chữ
                excelSheet.Range["A1", "G" + (dataTable.Rows.Count + 20)].Font.Name = "Times New Roman";
                excelSheet.Range["A4", "G11"].Font.Name = "Tahoma";
                //Font chữ
                excelSheet.Range["A1","A3"].Font.Size = 10;
                excelSheet.Range["A4", "A7"].Font.Size = 12;
                excelSheet.Range["A9", "G10"].Font.Size = 10;
                excelSheet.Range["A11", "G" + (dataTable.Rows.Count + 11)].Font.Size = 9;
                excelSheet.Range["A4", "A6"].Font.FontStyle = "Bold";
                excelSheet.Range["A9", "G11"].Font.FontStyle = "Bold";
                excelSheet.Range["D" + (dataTable.Rows.Count + 12), "G" + (dataTable.Rows.Count + 13)].Font.FontStyle = "Bold";
                //Canh giữa chữ
                excelSheet.Range["A4", "G7"].HorizontalAlignment = -4108;
                excelSheet.Range["A12", "C" + (dataTable.Rows.Count + 12)].HorizontalAlignment = -4108;
                excelSheet.Range["E12", "E" + (dataTable.Rows.Count + 12)].HorizontalAlignment = -4108;
                excelSheet.Range["A9", "G11"].HorizontalAlignment = -4108;
                excelSheet.Range["D9"].VerticalAlignment = -4108;
                excelSheet.Range["D" + (dataTable.Rows.Count + 12), "G" + (dataTable.Rows.Count + 13)].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //Merge
                excelSheet.Range["A4", "G4"].MergeCells = true;
                excelSheet.Range["A5", "G5"].MergeCells = true;
                excelSheet.Range["A6", "G6"].MergeCells = true;
                excelSheet.Range["A7", "G7"].MergeCells = true;
                excelSheet.Range["D9", "D10"].MergeCells = true;
                excelSheet.Range["A9", "C9"].MergeCells = true;
                excelSheet.Range["F9", "G9"].MergeCells = true;
                //Kích thước Cột và Dòng
                excelSheet.Range["A1", "A" + (dataTable.Rows.Count + 20)].RowHeight = "16.5";
                excelSheet.Range["A1"].ColumnWidth = 6;
                excelSheet.Range["B1"].ColumnWidth = 8;
                excelSheet.Range["C1"].ColumnWidth = 12;
                excelSheet.Range["D1"].ColumnWidth = 46;
                excelSheet.Range["E1"].ColumnWidth = 7;
                excelSheet.Range["F1","G1"].ColumnWidth = 12;
                //Border
                excelSheet.Range["A9", "G10"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A9", "G10"].Borders.Weight = 2d;
                excelSheet.Range["A11", "G" + (dataTable.Rows.Count + 11)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot;
                excelSheet.Range["A11", "G" + (dataTable.Rows.Count + 11)].Borders.Weight = 2d;
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "G" + (dataTable.Rows.Count + 13)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "G" + (dataTable.Rows.Count + 13)].Borders.Weight = 2d;
                //Công thức
                excelSheet.Range["F" + (dataTable.Rows.Count + 12), "F" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(F12:F{0})", dataTable.Rows.Count + 11);
                excelSheet.Range["G" + (dataTable.Rows.Count + 12), "G" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(G12:G{0})", dataTable.Rows.Count + 11);
                //format
                excelSheet.Range["C12", "C" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["F12", "F" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["G12", "G" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                #endregion

                //gắn header
                excelSheet.Cells[1, 1] = "CÔNG TY ABCDab";
                excelSheet.Cells[2, 1] = "M17 LÊ HOÀNG PHÁI,GÒ VẤP,TP.HCM";
                excelSheet.Cells[3, 1] = "Mã số thuế : 0300688235";
                excelSheet.Cells[4, 1] = "SỔ CHI TIẾT TÀI KHOẢN THEO ĐỐI TƯỢNG";
                excelSheet.Cells[5, 1] = "Tài khoản : " + taikhoan;
                excelSheet.Cells[6, 1] = "Mã ĐTPN : " + madtpn;
                excelSheet.Cells[7, 1] = "Từ ngày " + from.ToString("dd/MM/yyyy") + " đến ngày " + to.ToString("dd/MM/yyyy");
                excelSheet.Cells[9, 1] = "Chứng từ";
                excelSheet.Cells[9, 4] = "Diễn giải";
                excelSheet.Cells[9, 5] = "TK";
                excelSheet.Cells[9, 6] = "VND";
                excelSheet.Cells[10, 1] = "Loại";
                excelSheet.Cells[10, 2] = "Số";
                excelSheet.Cells[10, 3] = "Ngày";
                excelSheet.Cells[10, 5] = "DU";
                excelSheet.Cells[10, 6] = "Nợ";
                excelSheet.Cells[10, 7] = "Có";
                excelSheet.Cells[11, 4] = "SỐ DƯ ĐẦU KỲ";
                excelSheet.Cells[dataTable.Rows.Count + 12, 4] = "CỘNG PHÁT SINH";
                excelSheet.Cells[dataTable.Rows.Count + 13, 4] = "SỐ DƯ CUỐI KỲ";
                excelSheet.Cells[dataTable.Rows.Count + 14, 6] = "Ngày " + print.Day + " tháng " + print.Month + " năm " + print.Year;
                excelSheet.Cells[dataTable.Rows.Count + 15, 1] = "Người lập";
                excelSheet.Cells[dataTable.Rows.Count + 15, 4] = "Kế toán trưởng";
                excelSheet.Cells[dataTable.Rows.Count + 15, 6] = "Giám đốc";
                // loop through each row and add values to our sheet
                int rowcount = 11;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    excelSheet.Cells[rowcount, 1] = datarow["LOAI_CT"].ToString();
                    excelSheet.Cells[rowcount, 2] = datarow["SO_CT"].ToString();
                    excelSheet.Cells[rowcount, 3] = datarow["NGAY_CT"].ToString();
                    excelSheet.Cells[rowcount, 4] = datarow["DIENGIAI"].ToString();
                    excelSheet.Cells[rowcount, 5] = datarow["TKDU"].ToString();
                    excelSheet.Cells[rowcount, 6] = datarow["NO_VND"].ToString();
                    excelSheet.Cells[rowcount, 7] = datarow["CO_VND"].ToString();
                }
                //gắn footer
                //excelSheet.Cells[rowcount + 1, 1] = cell1;
                //excelSheet.Cells[rowcount + 1, 2] = cell2;

                //now save the workbook and exit Excel
                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                Process.Start(saveAsLocation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }
        public bool WriteDataTableToExcel_SOCTCN30_InChiTietQuyCach(System.Data.DataTable dataTable, string taikhoan, string madtpn, DateTime from, DateTime to, DateTime print)
        {
            string saveAsLocation = Application.StartupPath + @"\Excel\SOCTCN30.xls";
            string worksheetName = "SHVND";

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;
                excelSheet.PageSetup.Application.ActiveWindow.DisplayGridlines = false;

                #region General Cells
                //Kiểu chữ
                excelSheet.Range["A1", "N" + (dataTable.Rows.Count + 20)].Font.Name = "Times New Roman";
                excelSheet.Range["A4", "N10"].Font.Name = "Tahoma";
                //Font chữ
                excelSheet.Range["A1", "A3"].Font.Size = 10;
                excelSheet.Range["A4", "A7"].Font.Size = 12;
                excelSheet.Range["A9", "N10"].Font.Size = 10;
                excelSheet.Range["A11", "G" + (dataTable.Rows.Count + 20)].Font.Size = 9;
                excelSheet.Range["A4", "A6"].Font.FontStyle = "Bold";
                excelSheet.Range["A9", "N11"].Font.FontStyle = "Bold";
                excelSheet.Range["E" + (dataTable.Rows.Count + 12), "E" + (dataTable.Rows.Count + 13)].Font.FontStyle = "Bold"; 
                //Canh giữa chữ
                excelSheet.Range["A4", "N7"].HorizontalAlignment = -4108;
                excelSheet.Range["A9", "N11"].HorizontalAlignment = -4108;
                excelSheet.Range["A12", "D" + (dataTable.Rows.Count + 12)].HorizontalAlignment = -4108;
                excelSheet.Range["F12", "J" + (dataTable.Rows.Count + 12)].HorizontalAlignment = -4108;                
                excelSheet.Range["E9"].VerticalAlignment = -4108;
                excelSheet.Range["E" + (dataTable.Rows.Count + 12), "E" + (dataTable.Rows.Count + 13)].HorizontalAlignment = -4108;                              
                //Merge
                excelSheet.Range["A4", "N4"].MergeCells = true;
                excelSheet.Range["A5", "N5"].MergeCells = true;
                excelSheet.Range["A6", "N6"].MergeCells = true;
                excelSheet.Range["A7", "N7"].MergeCells = true;
                excelSheet.Range["A9", "C9"].MergeCells = true;
                excelSheet.Range["M9", "N9"].MergeCells = true;
                //Kích thước Cột và Dòng
                excelSheet.Range["A1", "A" + (dataTable.Rows.Count + 20)].RowHeight = "16.5";
                excelSheet.Range["A1"].ColumnWidth = 6;
                excelSheet.Range["B1"].ColumnWidth = 6;
                excelSheet.Range["C1"].ColumnWidth = 10;
                excelSheet.Range["D1"].ColumnWidth = 10;
                excelSheet.Range["E1"].ColumnWidth = 40;
                excelSheet.Range["F1", "L1"].ColumnWidth = 8;
                excelSheet.Range["M1", "N1"].ColumnWidth = 10;
                //Border
                excelSheet.Range["A9", "N10"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A9", "N10"].Borders.Weight = 2d;
                excelSheet.Range["A11", "N" + (dataTable.Rows.Count + 11)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot;
                excelSheet.Range["A11", "N" + (dataTable.Rows.Count + 11)].Borders.Weight = 2d;
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "N" + (dataTable.Rows.Count + 13)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "N" + (dataTable.Rows.Count + 13)].Borders.Weight = 2d;
                //Công thức
                excelSheet.Range["M" + (dataTable.Rows.Count + 12), "M" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(M12:M{0})", dataTable.Rows.Count + 11);
                excelSheet.Range["N" + (dataTable.Rows.Count + 12), "N" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(N12:N{0})", dataTable.Rows.Count + 11);
                //Format
                excelSheet.Range["C12", "C" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["K12", "K" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["M12", "M" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["N12", "N" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                #endregion

                //gắn header & footer
                excelSheet.Range["A1"].Value2 = "CÔNG TY ABCDab";
                excelSheet.Range["A2"].Value2 = "M17 LÊ HOÀNG PHÁI,GÒ VẤP,TP.HCM";
                excelSheet.Range["A3"].Value2 = "Mã số thuế : 0300688235";
                excelSheet.Range["A4"].Value2 = "SỔ CHI TIẾT TÀI KHOẢN THEO ĐỐI TƯỢNG";
                excelSheet.Range["A5"].Value2 = "Tài khoản : " + taikhoan;
                excelSheet.Range["A6"].Value2 = "Mã ĐTPN : " + madtpn;
                excelSheet.Range["A7"].Value2 = "Từ ngày " + from.ToString("dd/MM/yyyy") + " đến ngày " + to.ToString("dd/MM/yyyy");
                excelSheet.Range["A9"].Value2 = "Chứng từ";
                excelSheet.Range["D9"].Value2 = "Mã";
                excelSheet.Range["E9"].Value2 = "Diễn giải";
                excelSheet.Range["F9"].Value2 = "Đơn";
                excelSheet.Range["G9"].Value2 = "Số";
                excelSheet.Range["H9"].Value2 = "Dài";
                excelSheet.Range["I9"].Value2 = "Rộng";
                excelSheet.Range["J9"].Value2 = "Số";
                excelSheet.Range["K9"].Value2 = "Đơn";
                excelSheet.Range["L9"].Value2 = "TK";
                excelSheet.Range["M9"].Value2 = "VND";
                excelSheet.Range["A10"].Value2 = "Loại";
                excelSheet.Range["B10"].Value2 = "Số";
                excelSheet.Range["C10"].Value2 = "Ngày";
                excelSheet.Range["D10"].Value2 = "dm";
                excelSheet.Range["F10"].Value2 = "vị";
                excelSheet.Range["G10"].Value2 = "lượng";
                excelSheet.Range["J10"].Value2 = "M2";
                excelSheet.Range["K10"].Value2 = "giá";
                excelSheet.Range["L10"].Value2 = "DU";
                excelSheet.Range["M10"].Value2 = "Nợ";
                excelSheet.Range["N10"].Value2 = "Có";
                excelSheet.Range["E11"].Value2 = "SỐ DƯ ĐẦU KỲ";
                excelSheet.Range["E" + (dataTable.Rows.Count + 12)].Value2 = "CỘNG PHÁT SINH";
                excelSheet.Range["E" + (dataTable.Rows.Count + 13)].Value2 = "SỐ DƯ CUỐI KỲ";
                excelSheet.Range["A" + (dataTable.Rows.Count + 15)].Value2 = "Người lập";
                excelSheet.Range["G" + (dataTable.Rows.Count + 15)].Value2 = "Kế toán trưởng";
                excelSheet.Range["M" + (dataTable.Rows.Count + 15)].Value2 = "Giám đốc";
                excelSheet.Range["M" + (dataTable.Rows.Count + 14)].Value2 = "Ngày " + print.Day + " tháng " + print.Month + " năm " + print.Year;
                // loop through each row and add values to our sheet
                int rowcount = 11;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    excelSheet.Range["A" + rowcount].Value2 = datarow["LOAI_CT"].ToString();
                    excelSheet.Range["B" + rowcount].Value2 = datarow["SO_CT"].ToString();
                    excelSheet.Range["C" + rowcount].Value2 = datarow["NGAY_CT"].ToString();
                    excelSheet.Range["D" + rowcount].Value2 = datarow["MADM"].ToString();
                    excelSheet.Range["E" + rowcount].Value2 = datarow["DIENGIAI"].ToString();
                    excelSheet.Range["F" + rowcount].Value2 = datarow["DONVI"].ToString();
                    excelSheet.Range["G" + rowcount].Value2 = datarow["SOLUONG"].ToString();
                    excelSheet.Range["H" + rowcount].Value2 = datarow["DAI"].ToString();
                    excelSheet.Range["I" + rowcount].Value2 = datarow["RONG"].ToString();
                    excelSheet.Range["J" + rowcount].Value2 = datarow["SOM2"].ToString();
                    excelSheet.Range["K" + rowcount].Value2 = datarow["DONGIA"].ToString();
                    excelSheet.Range["L" + rowcount].Value2 = datarow["TKDU"].ToString();
                    excelSheet.Range["M" + rowcount].Value2 = datarow["NO_VND"].ToString();
                    excelSheet.Range["N" + rowcount].Value2 = datarow["CO_VND"].ToString();
                }

                //now save the workbook and exit Excel
                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                Process.Start(saveAsLocation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }
        public bool WriteDataTableToExcel_SOCTCN11_03_V_ViewtatcaDT(System.Data.DataTable dataTable, IQueryable<KT_CTuGoc> list, DateTime from, DateTime to, DateTime print)
        {
            var listDTPB = list.Select(a => a.MA_DTPN_NO).Distinct().ToList();
            string saveAsLocation = Application.StartupPath + @"\Excel\SOCTCN11_03_V.xls";
            string worksheetName = "IN";

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;
                excelSheet.PageSetup.Application.ActiveWindow.DisplayGridlines = false;

                int rowcount = 0;
                foreach (var item in listDTPB)
                {
                    string expression;
                    expression = "DTPN = '" + item + "'";
                    var dataRow = dataTable.Select(expression);
                    #region General Cells
                    //Kiểu chữ
                    excelSheet.Range["A" + (rowcount + 1), "L" + (rowcount + dataRow.Length + 20)].Font.Name = "Times New Roman";
                    excelSheet.Range["A" + (rowcount + 4), "L" + (rowcount + 10)].Font.Name = "Tahoma";
                    //Font chữ
                    excelSheet.Range["A" + (rowcount + 1), "A" + (rowcount + 3)].Font.Size = 10;
                    excelSheet.Range["A" + (rowcount + 4), "A" + (rowcount + 7)].Font.Size = 12;
                    excelSheet.Range["A" + (rowcount + 9), "L" + (rowcount + 10)].Font.Size = 10;
                    excelSheet.Range["A" + (rowcount + 11), "L" + (rowcount + dataRow.Length + 10)].Font.Size = 9;
                    excelSheet.Range["A" + (rowcount + 4), "A" + (rowcount + 6)].Font.FontStyle = "Bold";
                    excelSheet.Range["A" + (rowcount + 9), "L" + (rowcount + 10)].Font.FontStyle = "Bold";
                    //Canh giữa chữ
                    excelSheet.Range["A" + (rowcount + 4), "L" + (rowcount + 7)].HorizontalAlignment = -4108;
                    excelSheet.Range["A" + (rowcount + 9), "L" + (rowcount + 10)].HorizontalAlignment = -4108;
                    excelSheet.Range["A" + (rowcount + 11), "E" + (rowcount + dataRow.Length + 11)].HorizontalAlignment = -4108;
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 11), "F" + (rowcount + dataRow.Length + 11)].HorizontalAlignment = -4108;
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 12), "F" + (rowcount + dataRow.Length + 12)].HorizontalAlignment = -4108;
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 13), "F" + (rowcount + dataRow.Length + 13)].HorizontalAlignment = -4108;
                    //Merge
                    excelSheet.Range["A" + (rowcount + 4), "L" + (rowcount + 4)].MergeCells = true;
                    excelSheet.Range["A" + (rowcount + 5), "L" + (rowcount + 5)].MergeCells = true;
                    excelSheet.Range["A" + (rowcount + 6), "L" + (rowcount + 6)].MergeCells = true;
                    excelSheet.Range["A" + (rowcount + 7), "L" + (rowcount + 7)].MergeCells = true;
                    excelSheet.Range["A" + (rowcount + 9), "C" + (rowcount + 9)].MergeCells = true;
                    excelSheet.Range["D" + (rowcount + 9), "E" + (rowcount + 9)].MergeCells = true;
                    excelSheet.Range["I" + (rowcount + 9), "J" + (rowcount + 9)].MergeCells = true;
                    excelSheet.Range["K" + (rowcount + 9), "L" + (rowcount + 9)].MergeCells = true;
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 11), "G" + (rowcount + dataRow.Length + 11)].MergeCells = true;
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 12), "G" + (rowcount + dataRow.Length + 12)].MergeCells = true;
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 13), "G" + (rowcount + dataRow.Length + 13)].MergeCells = true;
                    //Kích thước Cột và Dòng
                    excelSheet.Range["A" + (rowcount + 1), "A" + (rowcount + dataRow.Length + 20)].RowHeight = "16.5";
                    excelSheet.Range["A1"].ColumnWidth = 6;
                    excelSheet.Range["B1"].ColumnWidth = 6;
                    excelSheet.Range["C1"].ColumnWidth = 10;
                    excelSheet.Range["D1"].ColumnWidth = 6;
                    excelSheet.Range["E1"].ColumnWidth = 10;
                    excelSheet.Range["F1"].ColumnWidth = 40;
                    excelSheet.Range["G1"].ColumnWidth = 40;
                    excelSheet.Range["H1", "L1"].ColumnWidth = 8;
                    //Border
                    excelSheet.Range["A" + (rowcount + 9), "L" + (rowcount + 10)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    excelSheet.Range["A" + (rowcount + 9), "L" + (rowcount + 10)].Borders.Weight = 2d;
                    excelSheet.Range["A" + (rowcount + 11), "L" + (rowcount+ dataRow.Length + 10)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot;
                    excelSheet.Range["A" + (rowcount + 11), "L" + (rowcount + dataRow.Length + 10)].Borders.Weight = 2d;
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 11), "L" + (rowcount + dataRow.Length + 13)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 11), "L" + (rowcount + dataRow.Length + 13)].Borders.Weight = 2d;
                    //Công thức
                    excelSheet.Range["I" + (rowcount + dataRow.Length + 11), "I" + (rowcount + dataRow.Length + 11)].Formula = String.Format("=sum(I{0}:I{1})", rowcount+11, rowcount + dataRow.Length + 10);
                    excelSheet.Range["J" + (rowcount + dataRow.Length + 11), "J" + (rowcount + dataRow.Length + 11)].Formula = String.Format("=sum(J{0}:J{1})", rowcount+11, rowcount + dataRow.Length + 10);
                    excelSheet.Range["K" + (rowcount + dataRow.Length + 11), "K" + (rowcount + dataRow.Length + 11)].Formula = String.Format("=sum(K{0}:K{1})", rowcount+11, rowcount + dataRow.Length + 10);
                    excelSheet.Range["L" + (rowcount + dataRow.Length + 11), "L" + (rowcount + dataRow.Length + 11)].Formula = String.Format("=sum(L{0}:L{1})",  rowcount+11, rowcount + dataRow.Length + 10);
                    //excelSheet.Range["I" + (rowcount + dataRow.Length + 12), "I" + (rowcount + dataRow.Length + 12)].Formula = String.Format("=sum(I{0}:I{1})", rowcount + 11, rowcount + dataRow.Length + 10);
                    //excelSheet.Range["J" + (rowcount + dataRow.Length + 12), "J" + (rowcount + dataRow.Length + 12)].Formula = String.Format("=sum(J{0}:J{1})", rowcount + 11, rowcount + dataRow.Length + 10);
                    //excelSheet.Range["K" + (rowcount + dataRow.Length + 12), "K" + (rowcount + dataRow.Length + 12)].Formula = String.Format("=sum(K{0}:K{1})", rowcount + 11, rowcount + dataRow.Length + 10);
                    //excelSheet.Range["L" + (rowcount + dataRow.Length + 12), "L" + (rowcount + dataRow.Length + 12)].Formula = String.Format("=sum(L{0}:L{1})", rowcount + 11, rowcount + dataRow.Length + 10);
                    //Format
                    excelSheet.Range["C" + (rowcount + 11), "C" + (rowcount + dataRow.Length + 10)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                    excelSheet.Range["E" + (rowcount + 11), "E" + (rowcount + dataRow.Length + 10)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                    excelSheet.Range["I11" + (rowcount + 11), "I" + (rowcount + dataRow.Length + 10)].EntireColumn.NumberFormat = "#,###";
                    excelSheet.Range["J11" + (rowcount + 11), "J" + (rowcount + dataRow.Length + 10)].EntireColumn.NumberFormat = "#,###";
                    excelSheet.Range["K11" + (rowcount + 11), "K" + (dataTable.Rows.Count + 10)].EntireColumn.NumberFormat = "#,###";
                    excelSheet.Range["L11" + (rowcount + 11), "L" + (rowcount + dataRow.Length + 10)].EntireColumn.NumberFormat = "#,###";
                    #endregion

                    //gắn header & footer
                    excelSheet.Range["A" + (rowcount + 1)].Value2 = "CÔNG TY ABCDab";
                    excelSheet.Range["A" + (rowcount + 2)].Value2 = "M17 LÊ HOÀNG PHÁI,GÒ VẤP,TP.HCM";
                    excelSheet.Range["A" + (rowcount + 3)].Value2 = "Mã số thuế : 0300688235";
                    excelSheet.Range["A" + (rowcount + 4)].Value2 = "SỔ CHI TIẾT TÀI KHOẢN THEO ĐỐI TƯỢNG";
                    excelSheet.Range["A" + (rowcount + 5)].Value2 = "Tài khoản : " + dataRow[0]["TK"];
                    excelSheet.Range["A" + (rowcount + 6)].Value2 = "Mã ĐTPN : " + dataRow[0]["DTPN"];
                    excelSheet.Range["A" + (rowcount + 7)].Value2 = "Từ ngày " + from.ToString("dd/MM/yyyy") + " đến ngày " + to.ToString("dd/MM/yyyy");
                    excelSheet.Range["A" + (rowcount + 9)].Value2 = "Chứng từ";
                    excelSheet.Range["D" + (rowcount + 9)].Value2 = "Hóa đơn";
                    excelSheet.Range["F" + (rowcount + 9)].Value2 = "Tên khách hàng";
                    excelSheet.Range["G" + (rowcount + 9)].Value2 = "Diễn giải";
                    excelSheet.Range["H" + (rowcount + 9)].Value2 = "TK";
                    excelSheet.Range["I" + (rowcount + 9)].Value2 = "USD - Phát sinh";
                    excelSheet.Range["K" + (rowcount + 9)].Value2 = "VND - Phát sinh";
                    excelSheet.Range["A" + (rowcount + 10)].Value2 = "Loại";
                    excelSheet.Range["B" + (rowcount + 10)].Value2 = "Số";
                    excelSheet.Range["C" + (rowcount + 10)].Value2 = "Ngày";
                    excelSheet.Range["D" + (rowcount + 10)].Value2 = "Số";
                    excelSheet.Range["E" + (rowcount + 10)].Value2 = "Ngày";
                    excelSheet.Range["H" + (rowcount + 10)].Value2 = "ĐƯ";
                    excelSheet.Range["I" + (rowcount + 10)].Value2 = "Nợ";
                    excelSheet.Range["J" + (rowcount + 10)].Value2 = "Có";
                    excelSheet.Range["K" + (rowcount + 10)].Value2 = "Nợ";
                    excelSheet.Range["L" + (rowcount + 10)].Value2 = "Có";
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 11)].Value2 = "CỘNG PHÁT SINH";
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 12)].Value2 = "SỐ DƯ ĐẦU KỲ";
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 13)].Value2 = "SỐ DƯ CUỐI KỲ";
                    excelSheet.Range["J" + (rowcount + dataRow.Length + 14)].Value2 = "Ngày " + print.Day + " tháng " + print.Month + " năm " + print.Year;
                    excelSheet.Range["C" + (rowcount + dataRow.Length + 15)].Value2 = "Người lập";
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 15)].Value2 = "Kế toán trưởng";
                    excelSheet.Range["K" + (rowcount + dataRow.Length + 15)].Value2 = "Giám đốc";
                    excelSheet.Range["C" + (rowcount + dataRow.Length + 20)].Value2 = "NLS";
                    excelSheet.Range["F" + (rowcount + dataRow.Length + 20)].Value2 = "KTT";
                    excelSheet.Range["K" + (rowcount + dataRow.Length + 20)].Value2 = "HTP";    
                    // loop through each row and add values to our sheet   
                    rowcount += 10;
                    foreach (var row in dataRow)
                    {
                        rowcount += 1;
                        excelSheet.Range["A" + rowcount].Value2 = row["LOAI_CT"].ToString();
                        excelSheet.Range["B" + rowcount].Value2 = row["SO_CT"].ToString();
                        excelSheet.Range["C" + rowcount].Value2 = row["NGAY_CT"].ToString();
                        excelSheet.Range["D" + rowcount].Value2 = row["SO_HOADON"].ToString();
                        excelSheet.Range["E" + rowcount].Value2 = row["NGAY_HOADON"].ToString();
                        excelSheet.Range["F" + rowcount].Value2 = row["TEN_KH"].ToString();
                        excelSheet.Range["G" + rowcount].Value2 = row["DIENGIAI"].ToString();
                        excelSheet.Range["H" + rowcount].Value2 = row["TKDU"].ToString();
                        excelSheet.Range["I" + rowcount].Value2 = row["NO_USD"].ToString();
                        excelSheet.Range["J" + rowcount].Value2 = row["CO_USD"].ToString();
                        excelSheet.Range["K" + rowcount].Value2 = row["NO_VND"].ToString();
                        excelSheet.Range["L" + rowcount].Value2 = row["CO_VND"].ToString();
                    }
                    rowcount += 10;
                }                
                //now save the workbook and exit Excel
                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                Process.Start(saveAsLocation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }
        public bool WriteDataTableToExcel_SOCTCN11_04_V_Subtotaltheochungtu(System.Data.DataTable dataTable, IQueryable<KT_CTuGoc> list, string taikhoan, string madtpn, DateTime from, DateTime to, DateTime print)
        {
            var listCT = (from a in list
                          select new { a.MA_CTU, a.SO_CTU, a.NGAY_CTU }).Distinct().ToList();
            string saveAsLocation = Application.StartupPath + @"\Excel\SOCTCN11_04_V.xls";
            string worksheetName = "IN";

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;
                excelSheet.PageSetup.Application.ActiveWindow.DisplayGridlines = false;

                #region General Cells
                //Kiểu chữ
                excelSheet.Range["A1", "J" + (listCT.Count + dataTable.Rows.Count + 20)].Font.Name = "Times New Roman";
                excelSheet.Range["A4", "J10"].Font.Name = "Tahoma";
                //Font chữ
                excelSheet.Range["A1", "A3"].Font.Size = 10;
                excelSheet.Range["A4", "A7"].Font.Size = 12;
                excelSheet.Range["A9", "J10"].Font.Size = 10;
                excelSheet.Range["A11", "J" + (listCT.Count + dataTable.Rows.Count + 20)].Font.Size = 9;
                excelSheet.Range["A4", "A6"].Font.FontStyle = "Bold";
                excelSheet.Range["A9", "J10"].Font.FontStyle = "Bold";
                excelSheet.Range["G" + (listCT.Count + dataTable.Rows.Count + 11), "J" + (listCT.Count + dataTable.Rows.Count + 13)].Font.FontStyle = "Bold";
                //Canh giữa chữ
                excelSheet.Range["A4", "J7"].HorizontalAlignment = -4108;
                excelSheet.Range["A9", "J10"].HorizontalAlignment = -4108;
                excelSheet.Range["A11", "E" + (listCT.Count + dataTable.Rows.Count + 11)].HorizontalAlignment = -4108;
                excelSheet.Range["G" + (listCT.Count + dataTable.Rows.Count + 11), "G" + (listCT.Count + dataTable.Rows.Count + 13)].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //Merge
                excelSheet.Range["A4", "J4"].MergeCells = true;
                excelSheet.Range["A5", "J5"].MergeCells = true;
                excelSheet.Range["A6", "J6"].MergeCells = true;
                excelSheet.Range["A7", "J7"].MergeCells = true;
                excelSheet.Range["A9", "C9"].MergeCells = true;
                excelSheet.Range["D9", "E9"].MergeCells = true;
                excelSheet.Range["I9", "J9"].MergeCells = true;
                //Kích thước Cột và Dòng
                excelSheet.Range["A1", "A" + (listCT.Count + dataTable.Rows.Count + 20)].RowHeight = "16.5";
                excelSheet.Range["A1"].ColumnWidth = 6;
                excelSheet.Range["B1"].ColumnWidth = 6;
                excelSheet.Range["C1"].ColumnWidth = 10;
                excelSheet.Range["D1"].ColumnWidth = 6;
                excelSheet.Range["E1"].ColumnWidth = 10;
                excelSheet.Range["F1"].ColumnWidth = 30;
                excelSheet.Range["G1"].ColumnWidth = 40;
                excelSheet.Range["H1"].ColumnWidth = 6;
                excelSheet.Range["I1"].ColumnWidth = 8;
                excelSheet.Range["J1"].ColumnWidth = 8;
                //Border                
                excelSheet.Range["A9", "J10"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A9", "J10"].Borders.Weight = 2d;
                excelSheet.Range["A11", "J" + (listCT.Count + dataTable.Rows.Count + 10)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot;
                excelSheet.Range["A11", "J" + (listCT.Count + dataTable.Rows.Count + 10)].Borders.Weight = 2d;
                excelSheet.Range["G" + (listCT.Count + dataTable.Rows.Count + 11), "J" + (listCT.Count + dataTable.Rows.Count + 13)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["G" + (listCT.Count + dataTable.Rows.Count + 11), "J" + (listCT.Count + dataTable.Rows.Count + 13)].Borders.Weight = 2d;
                //Công thức
                object SumNo = dataTable.Compute("SUM(CO_VND)", string.Empty);
                object SumCo = dataTable.Compute("SUM(CO_VND)", string.Empty);
                excelSheet.Range["I" + (listCT.Count + dataTable.Rows.Count + 11), "I" + (listCT.Count + dataTable.Rows.Count + 11)].Formula = SumNo.ToString();
                excelSheet.Range["J" + (listCT.Count + dataTable.Rows.Count + 11), "J" + (listCT.Count + dataTable.Rows.Count + 11)].Formula = SumCo.ToString();
                //Format
                excelSheet.Range["C11", "C" + (listCT.Count + dataTable.Rows.Count + 10)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["E11", "E" + (listCT.Count + dataTable.Rows.Count + 10)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["I12", "I" + (listCT.Count + dataTable.Rows.Count + 10)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["J12", "J" + (listCT.Count + dataTable.Rows.Count + 10)].EntireColumn.NumberFormat = "#,###";                
                #endregion

                //gắn header & footer
                excelSheet.Range["A1"].Value2 = "CÔNG TY ABCDab";
                excelSheet.Range["A2"].Value2 = "M17 LÊ HOÀNG PHÁI,GÒ VẤP,TP.HCM";
                excelSheet.Range["A3"].Value2 = "Mã số thuế : 0300688235";
                excelSheet.Range["A4"].Value2 = "SỔ CHI TIẾT TÀI KHOẢN THEO ĐỐI TƯỢNG";
                excelSheet.Range["A5"].Value2 = "Tài khoản : " + taikhoan;
                excelSheet.Range["A6"].Value2 = "Mã ĐTPN : " + madtpn;
                excelSheet.Range["A7"].Value2 = "Từ ngày " + from.ToString("dd/MM/yyyy") + " đến ngày " + to.ToString("dd/MM/yyyy");
                excelSheet.Range["A9"].Value2 = "Chứng từ";
                excelSheet.Range["D9"].Value2 = "Hóa đơn";
                excelSheet.Range["F9"].Value2 = "Người giao dịch";
                excelSheet.Range["G9"].Value2 = "Diễn giải";
                excelSheet.Range["H9"].Value2 = "TK";
                excelSheet.Range["I9"].Value2 = "VND - Phát sinh";
                excelSheet.Range["A10"].Value2 = "Loại";
                excelSheet.Range["B10"].Value2 = "Số";
                excelSheet.Range["C10"].Value2 = "Ngày";
                excelSheet.Range["D10"].Value2 = "Số";
                excelSheet.Range["E10"].Value2 = "Ngày";
                excelSheet.Range["H10"].Value2 = "ĐỨ";
                excelSheet.Range["I10"].Value2 = "Nợ";
                excelSheet.Range["J10"].Value2 = "Có";
                excelSheet.Range["G" + (listCT.Count + dataTable.Rows.Count + 11)].Value2 = "CỘNG PHÁT SINH";
                excelSheet.Range["G" + (listCT.Count + dataTable.Rows.Count + 12)].Value2 = "SỐ DƯ ĐẦU KỲ";
                excelSheet.Range["G" + (listCT.Count + dataTable.Rows.Count + 13)].Value2 = "SỐ DƯ CUỐI KỲ";
                excelSheet.Range["I" + (listCT.Count + dataTable.Rows.Count + 14)].Value2 = "Ngày " + print.Day + " tháng " + print.Month + " năm " + print.Year;
                excelSheet.Range["C" + (listCT.Count + dataTable.Rows.Count + 15)].Value2 = "Người lập";
                excelSheet.Range["G" + (listCT.Count + dataTable.Rows.Count + 15)].Value2 = "Kế toán trưởng";
                excelSheet.Range["I" + (listCT.Count + dataTable.Rows.Count + 15)].Value2 = "Giám đốc";
                // loop through each row and add values to our sheet
                
                int rowcount = 10;
                foreach (var item in listCT)
                {
                    string expression;
                    expression = "LOAI_CT = '" + item.MA_CTU + "'";
                    expression += "and SO_CT = '" + item.SO_CTU + "'";
                    expression += "and NGAY_CT = '" + item.NGAY_CTU + "'";
                    var dataRow = dataTable.Select(expression);
                    foreach (DataRow row in dataRow)
                    {
                        rowcount += 1;
                        excelSheet.Range["A" + rowcount].Value2 = row["LOAI_CT"].ToString();
                        excelSheet.Range["B" + rowcount].Value2 = row["SO_CT"].ToString();
                        excelSheet.Range["C" + rowcount].Value2 = row["NGAY_CT"].ToString();
                        excelSheet.Range["D" + rowcount].Value2 = row["SO_HOADON"].ToString();
                        excelSheet.Range["E" + rowcount].Value2 = row["NGAY_HOADON"].ToString();
                        excelSheet.Range["F" + rowcount].Value2 = row["NGUOI_GD"].ToString();
                        excelSheet.Range["G" + rowcount].Value2 = row["DIENGIAI"].ToString();
                        excelSheet.Range["H" + rowcount].Value2 = row["TKDU"].ToString();
                        excelSheet.Range["I" + rowcount].Value2 = row["NO_VND"].ToString();
                        excelSheet.Range["J" + rowcount].Value2 = row["CO_VND"].ToString();
                    }
                    rowcount += 1;
                    excelSheet.Range["A" + rowcount].Value2 = item.MA_CTU.ToString();
                    excelSheet.Range["B" + rowcount].Value2 = item.SO_CTU.ToString();
                    excelSheet.Range["C" + rowcount].Value2 = item.NGAY_CTU.ToString();
                    excelSheet.Range["G" + rowcount].Value2 = "Cộng chứng từ:";
                    excelSheet.Range["I" + rowcount].Value2 = String.Format("=sum(I{0}:I{1})", rowcount - dataRow.Length, rowcount -1);
                    excelSheet.Range["J" + rowcount].Value2 = String.Format("=sum(J{0}:J{1})", rowcount - dataRow.Length, rowcount - 1);
                    excelSheet.Range["A" + (rowcount), "J" + (rowcount)].Font.Italic = true;
                    excelSheet.Range["A" + (rowcount), "J" + (rowcount)].Font.Underline = true;
                    excelSheet.Range["A" + (rowcount), "J" + (rowcount)].Font.Bold = true;
                }
                
                //now save the workbook and exit Excel
                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                Process.Start(saveAsLocation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }
        public bool WriteDataTableToExcel_SOCTCN11_05_V_Subtotaltheothang(System.Data.DataTable dataTable, string taikhoan, string madtpn, DateTime from, DateTime to, DateTime print)
        {
            string saveAsLocation = Application.StartupPath + @"\Excel\SOCTCN11_05_V.xls";
            string worksheetName = "IN";

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;
                excelSheet.PageSetup.Application.ActiveWindow.DisplayGridlines = false;

                #region General Cells
                //Kiểu chữ
                excelSheet.Range["A1", "J" + (dataTable.Rows.Count + 21)].Font.Name = "Times New Roman";
                excelSheet.Range["A4", "J11"].Font.Name = "Tahoma";
                //Font chữ
                excelSheet.Range["A1", "A3"].Font.Size = 10;
                excelSheet.Range["A4", "A7"].Font.Size = 12;
                excelSheet.Range["A9", "J11"].Font.Size = 10;
                excelSheet.Range["A12", "J" + (dataTable.Rows.Count + 21)].Font.Size = 9;
                excelSheet.Range["A4", "A6"].Font.FontStyle = "Bold";
                excelSheet.Range["A9", "J11"].Font.FontStyle = "Bold";
                excelSheet.Range["G" + (dataTable.Rows.Count + 12), "J" + (dataTable.Rows.Count + 14)].Font.FontStyle = "Bold";
                //Canh giữa chữ
                excelSheet.Range["A4", "J7"].HorizontalAlignment = -4108;
                excelSheet.Range["A12", "F" + (dataTable.Rows.Count + 11)].HorizontalAlignment = -4108;
                excelSheet.Range["A9", "J10"].HorizontalAlignment = -4108;
                excelSheet.Range["G" + (dataTable.Rows.Count + 12), "J" + (dataTable.Rows.Count + 14)].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //Merge
                excelSheet.Range["A4", "J4"].MergeCells = true;
                excelSheet.Range["A5", "J5"].MergeCells = true;
                excelSheet.Range["A6", "J6"].MergeCells = true;
                excelSheet.Range["A7", "J7"].MergeCells = true;
                excelSheet.Range["B9", "D9"].MergeCells = true;
                excelSheet.Range["E9", "F9"].MergeCells = true;
                excelSheet.Range["I9", "J9"].MergeCells = true;
                //Kích thước Cột và Dòng
                excelSheet.Range["A1", "A" + (dataTable.Rows.Count + 21)].RowHeight = "16.5";
                excelSheet.Range["A1"].ColumnWidth = 5;
                excelSheet.Range["B1"].ColumnWidth = 6;
                excelSheet.Range["C1"].ColumnWidth = 6;
                excelSheet.Range["D1"].ColumnWidth = 10;
                excelSheet.Range["E1"].ColumnWidth = 6;
                excelSheet.Range["F1"].ColumnWidth = 10;
                excelSheet.Range["G1"].ColumnWidth = 40;
                excelSheet.Range["H1"].ColumnWidth = 6;
                excelSheet.Range["I1", "J1"].ColumnWidth = 12;
                //Border
                excelSheet.Range["A9", "J11"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A9", "J11"].Borders.Weight = 2d;
                excelSheet.Range["A12", "J" + (dataTable.Rows.Count + 11)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot;
                excelSheet.Range["A12", "J" + (dataTable.Rows.Count + 11)].Borders.Weight = 2d;
                excelSheet.Range["G" + (dataTable.Rows.Count + 12), "J" + (dataTable.Rows.Count + 14)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["G" + (dataTable.Rows.Count + 12), "J" + (dataTable.Rows.Count + 14)].Borders.Weight = 2d;
                //Công thức
                excelSheet.Range["I" + (dataTable.Rows.Count + 12), "I" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(I12:I{0})", dataTable.Rows.Count + 11);
                excelSheet.Range["J" + (dataTable.Rows.Count + 12), "J" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(J12:J{0})", dataTable.Rows.Count + 11);
                excelSheet.Range["I11"].Formula = String.Format("=sum(I12:I{0})", dataTable.Rows.Count + 11);
                excelSheet.Range["J11"].Formula = String.Format("=sum(J12:J{0})", dataTable.Rows.Count + 11);
                //format
                excelSheet.Range["D12", "D" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["F12", "F" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["I12", "I" + (dataTable.Rows.Count + 14)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["J12", "J" + (dataTable.Rows.Count + 14)].EntireColumn.NumberFormat = "#,###";
                #endregion

                //gắn header
                excelSheet.Range["A1"].Value2 = "CÔNG TY ABCDab";
                excelSheet.Range["A2"].Value2 = "M17 LÊ HOÀNG PHÁI,GÒ VẤP,TP.HCM";
                excelSheet.Range["A3"].Value2 = "Mã số thuế : 0300688235";
                excelSheet.Range["A4"].Value2 = "SỔ CHI TIẾT TÀI KHOẢN THEO ĐỐI TƯỢNG";
                excelSheet.Range["A5"].Value2 = "Tài khoản : " + taikhoan;
                excelSheet.Range["A6"].Value2 = "ĐT : " + madtpn;
                excelSheet.Range["A7"].Value2 = "Từ ngày " + from.ToString("dd/MM/yyyy") + " đến ngày " + to.ToString("dd/MM/yyyy");
                excelSheet.Range["A9"].Value2 = "T";
                excelSheet.Range["B9"].Value2 = "Chứng từ";
                excelSheet.Range["E9"].Value2 = "Hóa đơn";
                excelSheet.Range["G9"].Value2 = "Diễn giải";
                excelSheet.Range["H9"].Value2 = "TK";
                excelSheet.Range["I9"].Value2 = "VND - Phát sinh";
                excelSheet.Range["B10"].Value2 = "Loại";
                excelSheet.Range["C10"].Value2 = "Số";
                excelSheet.Range["D10"].Value2 = "Ngày";
                excelSheet.Range["E10"].Value2 = "Số";
                excelSheet.Range["F10"].Value2 = "Ngày";
                excelSheet.Range["H10"].Value2 = "ĐỨ";
                excelSheet.Range["I10"].Value2 = "Nợ";
                excelSheet.Range["J10"].Value2 = "Có";
                excelSheet.Range["A11"].Value2 = from.Month.ToString();
                excelSheet.Range["G11"].Value2 = "Cộng tháng: " + from.Month.ToString();
                excelSheet.Range["G" + (dataTable.Rows.Count + 12)].Value2 = "CỘNG PHÁT SINH";
                excelSheet.Range["G" + (dataTable.Rows.Count + 13)].Value2 = "SỐ DƯ ĐẦU KỲ";
                excelSheet.Range["G" + (dataTable.Rows.Count + 14)].Value2 = "SỐ DƯ CUỐI KỲ";
                excelSheet.Range["I" + (dataTable.Rows.Count + 15)].Value2 = "Ngày " + print.Day + " tháng " + print.Month + " năm " + print.Year;
                excelSheet.Range["C" + (dataTable.Rows.Count + 16)].Value2 = "Người lập";
                excelSheet.Range["G" + (dataTable.Rows.Count + 16)].Value2 = "Kế toán trưởng";
                excelSheet.Range["I" + (dataTable.Rows.Count + 16)].Value2 = "Giám đốc";
                // loop through each row and add values to our sheet
                int rowcount = 11;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    excelSheet.Range["A" + rowcount].Value2 = from.Month.ToString();
                    excelSheet.Range["B" + rowcount].Value2 = datarow["LOAI_CT"].ToString();
                    excelSheet.Range["C" + rowcount].Value2 = datarow["SO_CT"].ToString();
                    excelSheet.Range["D" + rowcount].Value2 = datarow["NGAY_CT"].ToString();
                    excelSheet.Range["E" + rowcount].Value2 = datarow["SO_HOADON"].ToString();
                    excelSheet.Range["F" + rowcount].Value2 = datarow["NGAY_HOADON"].ToString();                    
                    excelSheet.Range["G" + rowcount].Value2 = datarow["DIENGIAI"].ToString();
                    excelSheet.Range["H" + rowcount].Value2 = datarow["TKDU"].ToString();
                    excelSheet.Range["I" + rowcount].Value2 = datarow["NO_VND"].ToString();
                    excelSheet.Range["J" + rowcount].Value2 = datarow["CO_VND"].ToString();
                }

                //now save the workbook and exit Excel
                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                Process.Start(saveAsLocation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }
        public bool WriteDataTableToExcel_SOCTCN11_06_V_Subtotaltheocongtrinh(System.Data.DataTable dataTable, string taikhoan, string madtpn, DateTime from, DateTime to, DateTime print)
        {
            string saveAsLocation = Application.StartupPath + @"\Excel\SOCTCN11_06_V.xls";
            string worksheetName = "IN";

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;
                excelSheet.PageSetup.Application.ActiveWindow.DisplayGridlines = false;

                #region General Cells
                //Kiểu chữ
                excelSheet.Range["A1", "J" + (dataTable.Rows.Count + 20)].Font.Name = "Times New Roman";
                excelSheet.Range["A4", "J10"].Font.Name = "Tahoma";
                //Font chữ
                excelSheet.Range["A1", "A3"].Font.Size = 10;
                excelSheet.Range["A4", "A7"].Font.Size = 12;
                excelSheet.Range["A9", "J10"].Font.Size = 10;
                excelSheet.Range["A11", "J" + (dataTable.Rows.Count + 10)].Font.Size = 9;
                excelSheet.Range["A4", "A6"].Font.FontStyle = "Bold";
                excelSheet.Range["A9", "J10"].Font.FontStyle = "Bold";
                excelSheet.Range["G" + (dataTable.Rows.Count + 11), "J" + (dataTable.Rows.Count + 13)].Font.FontStyle = "Bold";
                //Canh giữa chữ
                excelSheet.Range["A4", "J7"].HorizontalAlignment = -4108;
                excelSheet.Range["A9", "J10"].HorizontalAlignment = -4108;
                excelSheet.Range["A11", "F" + (dataTable.Rows.Count + 10)].HorizontalAlignment = -4108;
                excelSheet.Range["G" + (dataTable.Rows.Count + 11), "G" + (dataTable.Rows.Count + 13)].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //Merge
                excelSheet.Range["A4", "J4"].MergeCells = true;
                excelSheet.Range["A5", "J5"].MergeCells = true;
                excelSheet.Range["A6", "J6"].MergeCells = true;
                excelSheet.Range["A7", "J7"].MergeCells = true;
                excelSheet.Range["B9", "D9"].MergeCells = true;
                excelSheet.Range["E9", "F9"].MergeCells = true;
                excelSheet.Range["I9", "J9"].MergeCells = true;
                //Kích thước Cột và Dòng
                excelSheet.Range["A1", "A" + (dataTable.Rows.Count + 20)].RowHeight = "16.5";
                excelSheet.Range["A1"].ColumnWidth = 6;
                excelSheet.Range["B1"].ColumnWidth = 6;
                excelSheet.Range["C1"].ColumnWidth = 6;
                excelSheet.Range["D1"].ColumnWidth = 10;
                excelSheet.Range["E1"].ColumnWidth = 6;
                excelSheet.Range["F1"].ColumnWidth = 10;
                excelSheet.Range["G1"].ColumnWidth = 40;
                excelSheet.Range["H1"].ColumnWidth = 6;
                excelSheet.Range["I1", "J1"].ColumnWidth = 12;
                //Border
                excelSheet.Range["A9", "J10"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A9", "J10"].Borders.Weight = 2d;
                excelSheet.Range["A11", "J" + (dataTable.Rows.Count + 10)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot;
                excelSheet.Range["A11", "J" + (dataTable.Rows.Count + 10)].Borders.Weight = 2d;
                excelSheet.Range["G" + (dataTable.Rows.Count + 11), "J" + (dataTable.Rows.Count + 13)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["G" + (dataTable.Rows.Count + 11), "J" + (dataTable.Rows.Count + 13)].Borders.Weight = 2d;
                //Công thức
                excelSheet.Range["I" + (dataTable.Rows.Count + 11), "I" + (dataTable.Rows.Count + 11)].Formula = String.Format("=sum(I11:I{0})", dataTable.Rows.Count + 10);
                excelSheet.Range["J" + (dataTable.Rows.Count + 11), "J" + (dataTable.Rows.Count + 11)].Formula = String.Format("=sum(J11:J{0})", dataTable.Rows.Count + 10);
                //format
                excelSheet.Range["D11", "D" + (dataTable.Rows.Count + 10)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["F11", "F" + (dataTable.Rows.Count + 10)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["I11", "I" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["J11", "J" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                #endregion

                //gắn header
                excelSheet.Range["A1"].Value2 = "CÔNG TY ABCDab";
                excelSheet.Range["A2"].Value2 = "M17 LÊ HOÀNG PHÁI,GÒ VẤP,TP.HCM";
                excelSheet.Range["A3"].Value2 = "Mã số thuế : 0300688235";
                excelSheet.Range["A4"].Value2 = "SỔ CHI TIẾT TÀI KHOẢN THEO ĐỐI TƯỢNG";
                excelSheet.Range["A5"].Value2 = "Tài khoản : " + taikhoan;
                excelSheet.Range["A6"].Value2 = "ĐT : " + madtpn;
                excelSheet.Range["A7"].Value2 = "Từ ngày " + from.ToString("dd/MM/yyyy") + " đến ngày " + to.ToString("dd/MM/yyyy");
                excelSheet.Range["A9"].Value2 = "Mã";
                excelSheet.Range["A10"].Value2 = "CT";
                excelSheet.Range["B9"].Value2 = "Chứng từ";
                excelSheet.Range["E9"].Value2 = "Hóa đơn";
                excelSheet.Range["G9"].Value2 = "Diễn giải";
                excelSheet.Range["H9"].Value2 = "TK";
                excelSheet.Range["I9"].Value2 = "VND - Phát sinh";
                excelSheet.Range["B10"].Value2 = "Loại";
                excelSheet.Range["C10"].Value2 = "Số";
                excelSheet.Range["D10"].Value2 = "Ngày";
                excelSheet.Range["E10"].Value2 = "Số";
                excelSheet.Range["F10"].Value2 = "Ngày";
                excelSheet.Range["H10"].Value2 = "ĐỨ";
                excelSheet.Range["I10"].Value2 = "Nợ";
                excelSheet.Range["J10"].Value2 = "Có";
                excelSheet.Range["G" + (dataTable.Rows.Count + 11)].Value2 = "CỘNG PHÁT SINH";
                excelSheet.Range["G" + (dataTable.Rows.Count + 12)].Value2 = "SỐ DƯ ĐẦU KỲ";
                excelSheet.Range["G" + (dataTable.Rows.Count + 13)].Value2 = "SỐ DƯ CUỐI KỲ";
                excelSheet.Range["I" + (dataTable.Rows.Count + 14)].Value2 = "Ngày " + print.Day + " tháng " + print.Month + " năm " + print.Year;
                excelSheet.Range["C" + (dataTable.Rows.Count + 15)].Value2 = "Người lập";
                excelSheet.Range["G" + (dataTable.Rows.Count + 15)].Value2 = "Kế toán trưởng";
                excelSheet.Range["I" + (dataTable.Rows.Count + 15)].Value2 = "Giám đốc";
                // loop through each row and add values to our sheet
                int rowcount = 10;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    excelSheet.Range["A" + rowcount].Value2 = datarow["MA_CTRINH"].ToString();
                    excelSheet.Range["B" + rowcount].Value2 = datarow["LOAI_CT"].ToString();
                    excelSheet.Range["C" + rowcount].Value2 = datarow["SO_CT"].ToString();
                    excelSheet.Range["D" + rowcount].Value2 = datarow["NGAY_CT"].ToString();
                    excelSheet.Range["E" + rowcount].Value2 = datarow["SO_HOADON"].ToString();
                    excelSheet.Range["F" + rowcount].Value2 = datarow["NGAY_HOADON"].ToString();
                    excelSheet.Range["G" + rowcount].Value2 = datarow["DIENGIAI"].ToString();
                    excelSheet.Range["H" + rowcount].Value2 = datarow["TKDU"].ToString();
                    excelSheet.Range["I" + rowcount].Value2 = datarow["NO_VND"].ToString();
                    excelSheet.Range["J" + rowcount].Value2 = datarow["CO_VND"].ToString();
                }

                //now save the workbook and exit Excel
                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                Process.Start(saveAsLocation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }
        //2
        public bool WriteDataTableToExcel_SOCTCN19_01_V_Mauchuan(System.Data.DataTable dataTable, string taikhoan, string madtpn, DateTime from, DateTime to, DateTime print)
        {
            string saveAsLocation = Application.StartupPath + @"\Excel\SOCTCN11_06_V.xls";
            string worksheetName = "IN";

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;
                excelSheet.PageSetup.Application.ActiveWindow.DisplayGridlines = false;

                #region General Cells
                //Kiểu chữ
                excelSheet.Range["A1", "J" + (dataTable.Rows.Count + 24)].Font.Name = "Times New Roman";
                excelSheet.Range["A4", "J10"].Font.Name = "Tahoma";
                //Font chữ
                excelSheet.Range["A1", "A3"].Font.Size = 10;
                excelSheet.Range["A4", "A7"].Font.Size = 12;
                excelSheet.Range["A9", "J10"].Font.Size = 10;
                excelSheet.Range["A11", "J" + (dataTable.Rows.Count + 11)].Font.Size = 9;
                excelSheet.Range["A4", "A6"].Font.FontStyle = "Bold";
                excelSheet.Range["A9", "J10"].Font.FontStyle = "Bold";
                excelSheet.Range["F" + (dataTable.Rows.Count + 11), "J" + (dataTable.Rows.Count + 16)].Font.FontStyle = "Bold";
                excelSheet.Range["A" + (dataTable.Rows.Count + 18), "J" + (dataTable.Rows.Count + 18)].Font.FontStyle = "Bold";
                //Canh giữa chữ
                excelSheet.Range["A4", "J7"].HorizontalAlignment = -4108;
                excelSheet.Range["A9", "J10"].HorizontalAlignment = -4108;
                excelSheet.Range["A11", "E" + (dataTable.Rows.Count + 10)].HorizontalAlignment = -4108;
                excelSheet.Range["F" + (dataTable.Rows.Count + 11), "F" + (dataTable.Rows.Count + 16)].HorizontalAlignment = -4108;
                excelSheet.Range["A" + (dataTable.Rows.Count + 17), "J" + (dataTable.Rows.Count + 24)].HorizontalAlignment = -4108;
                //Merge
                excelSheet.Range["A4", "J4"].MergeCells = true;
                excelSheet.Range["A5", "J5"].MergeCells = true;
                excelSheet.Range["A6", "J6"].MergeCells = true;
                excelSheet.Range["A7", "J7"].MergeCells = true;
                excelSheet.Range["A9", "C9"].MergeCells = true;
                excelSheet.Range["D9", "E9"].MergeCells = true;
                excelSheet.Range["G" + (dataTable.Rows.Count + 13), "H" + (dataTable.Rows.Count + 13)].MergeCells = true;
                excelSheet.Range["G" + (dataTable.Rows.Count + 14), "H" + (dataTable.Rows.Count + 14)].MergeCells = true;
                excelSheet.Range["G" + (dataTable.Rows.Count + 15), "H" + (dataTable.Rows.Count + 15)].MergeCells = true;
                excelSheet.Range["G" + (dataTable.Rows.Count + 16), "H" + (dataTable.Rows.Count + 16)].MergeCells = true;
                //Kích thước Cột và Dòng
                excelSheet.Range["A1", "A" + (dataTable.Rows.Count + 24)].RowHeight = "16.5";
                excelSheet.Range["A1"].ColumnWidth = 6;
                excelSheet.Range["B1"].ColumnWidth = 6;
                excelSheet.Range["C1"].ColumnWidth = 10;
                excelSheet.Range["D1"].ColumnWidth = 6;
                excelSheet.Range["E1"].ColumnWidth = 10;
                excelSheet.Range["F1"].ColumnWidth = 40;
                excelSheet.Range["G1"].ColumnWidth = 6;
                excelSheet.Range["H1"].ColumnWidth = 10;
                excelSheet.Range["I1", "J1"].ColumnWidth = 12;
                //Border
                excelSheet.Range["A9", "J10"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A9", "J10"].Borders.Weight = 2d;
                excelSheet.Range["A11", "J" + (dataTable.Rows.Count + 10)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot;
                excelSheet.Range["A11", "J" + (dataTable.Rows.Count + 10)].Borders.Weight = 2d;
                excelSheet.Range["A" + (dataTable.Rows.Count + 11), "J" + (dataTable.Rows.Count + 11)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A" + (dataTable.Rows.Count + 11), "J" + (dataTable.Rows.Count + 11)].Borders.Weight = 2d;
                excelSheet.Range["F" + (dataTable.Rows.Count + 13), "H" + (dataTable.Rows.Count + 16)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["F" + (dataTable.Rows.Count + 13), "H" + (dataTable.Rows.Count + 16)].Borders.Weight = 2d;
                //Công thức
                excelSheet.Range["I" + (dataTable.Rows.Count + 11), "I" + (dataTable.Rows.Count + 11)].Formula = String.Format("=sum(I11:I{0})", dataTable.Rows.Count + 10);
                excelSheet.Range["J" + (dataTable.Rows.Count + 11), "J" + (dataTable.Rows.Count + 11)].Formula = String.Format("=sum(J11:J{0})", dataTable.Rows.Count + 10);
                //format
                excelSheet.Range["C11", "C" + (dataTable.Rows.Count + 10)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["E11", "E" + (dataTable.Rows.Count + 10)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["I11", "I" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["J11", "J" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["H11", "H" + (dataTable.Rows.Count + 16)].EntireColumn.NumberFormat = "#,###";
                #endregion

                //gắn header
                excelSheet.Range["A1"].Value2 = "CÔNG TY ABCDab";
                excelSheet.Range["A2"].Value2 = "M17 LÊ HOÀNG PHÁI,GÒ VẤP,TP.HCM";
                excelSheet.Range["A3"].Value2 = "Mã số thuế : 0300688235";
                excelSheet.Range["A4"].Value2 = "SỔ CHI TIẾT TÀI KHOẢN THEO ĐỐI TƯỢNG";
                excelSheet.Range["A5"].Value2 = "Tài khoản : " + taikhoan;
                excelSheet.Range["A6"].Value2 = "Khách hàng : " + madtpn;
                excelSheet.Range["A7"].Value2 = "Từ ngày " + from.ToString("dd/MM/yyyy") + " đến ngày " + to.ToString("dd/MM/yyyy");
                excelSheet.Range["A9"].Value2 = "Chứng từ";
                excelSheet.Range["D9"].Value2 = "Hóa đơn";
                excelSheet.Range["F9"].Value2 = "Nội dung";
                excelSheet.Range["G9"].Value2 = "TK";
                excelSheet.Range["H9"].Value2 = "Mua";
                excelSheet.Range["I9"].Value2 = "Thanh toán";
                excelSheet.Range["J9"].Value2 = "Còn nợ";
                excelSheet.Range["A10"].Value2 = "Loại";
                excelSheet.Range["B10"].Value2 = "Số";
                excelSheet.Range["C10"].Value2 = "Ngày";
                excelSheet.Range["D10"].Value2 = "Số";
                excelSheet.Range["E10"].Value2 = "Ngày";
                excelSheet.Range["G10"].Value2 = "Đ.Ứ";
                excelSheet.Range["F" + (dataTable.Rows.Count + 11)].Value2 = "Tổng cộng";
                excelSheet.Range["F" + (dataTable.Rows.Count + 13)].Value2 = "SỐ DƯ ĐẦU KỲ";
                excelSheet.Range["F" + (dataTable.Rows.Count + 14)].Value2 = "MUA TRONG KỲ";
                excelSheet.Range["F" + (dataTable.Rows.Count + 15)].Value2 = "TRẢ TRONG KỲ";
                excelSheet.Range["F" + (dataTable.Rows.Count + 16)].Value2 = "SỐ DƯ CUỐI KỲ";
                excelSheet.Range["I" + (dataTable.Rows.Count + 17)].Value2 = "Ngày " + print.Day + " tháng " + print.Month + " năm " + print.Year;
                excelSheet.Range["C" + (dataTable.Rows.Count + 18)].Value2 = "Người lập";
                excelSheet.Range["F" + (dataTable.Rows.Count + 18)].Value2 = "Kế toán trưởng";
                excelSheet.Range["I" + (dataTable.Rows.Count + 18)].Value2 = "Giám đốc";
                excelSheet.Range["I" + (dataTable.Rows.Count + 19)].Value2 = "(Ký, họ tên, đóng dấu)";
                // loop through each row and add values to our sheet
                int rowcount = 10;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    excelSheet.Range["A" + rowcount].Value2 = datarow["LOAI_CT"].ToString();
                    excelSheet.Range["B" + rowcount].Value2 = datarow["SO_CT"].ToString();
                    excelSheet.Range["C" + rowcount].Value2 = datarow["NGAY_CT"].ToString();
                    excelSheet.Range["D" + rowcount].Value2 = datarow["SO_HOADON"].ToString();
                    excelSheet.Range["E" + rowcount].Value2 = datarow["NGAY_HOADON"].ToString();
                    excelSheet.Range["F" + rowcount].Value2 = datarow["DIENGIAI"].ToString();
                    excelSheet.Range["G" + rowcount].Value2 = datarow["TKDU"].ToString();
                    excelSheet.Range["H" + rowcount].Value2 = datarow["MUA"].ToString();
                    excelSheet.Range["I" + rowcount].Value2 = datarow["NO_VND"].ToString();
                    excelSheet.Range["J" + rowcount].Value2 = datarow["CO_VND"].ToString();
                }

                //now save the workbook and exit Excel
                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                Process.Start(saveAsLocation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }
        public bool WriteDataTableToExcel_SOCTCN26_Chitiettheosohoadon(System.Data.DataTable dataTable, string taikhoan, string madtpn, DateTime from, DateTime to, DateTime print)
        {
            string saveAsLocation = Application.StartupPath + @"\Excel\SOCTCN26.xls";
            string worksheetName = "IN";

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;
                excelSheet.PageSetup.Application.ActiveWindow.DisplayGridlines = false;
                #region General Cells
                //Kiểu chữ
                excelSheet.Range["A1", "K" + (dataTable.Rows.Count + 20)].Font.Name = "Times New Roman";
                excelSheet.Range["A4", "K10"].Font.Name = "Tahoma";
                //Font chữ
                excelSheet.Range["A1", "A3"].Font.Size = 10;
                excelSheet.Range["A4", "A7"].Font.Size = 12;
                excelSheet.Range["A9", "K10"].Font.Size = 10;
                excelSheet.Range["A12", "K" + (dataTable.Rows.Count + 11)].Font.Size = 9;
                excelSheet.Range["A4", "A6"].Font.FontStyle = "Bold";
                excelSheet.Range["A9", "K11"].Font.FontStyle = "Bold";
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "K" + (dataTable.Rows.Count + 13)].Font.FontStyle = "Bold";
                excelSheet.Range["A" + (dataTable.Rows.Count + 15), "K" + (dataTable.Rows.Count + 15)].Font.FontStyle = "Bold";
                //Canh giữa chữ
                excelSheet.Range["G1", "G3"].HorizontalAlignment = -4108;
                excelSheet.Range["A4", "K7"].HorizontalAlignment = -4108;
                excelSheet.Range["A9", "K11"].HorizontalAlignment = -4108;
                excelSheet.Range["A12", "E" + (dataTable.Rows.Count + 11)].HorizontalAlignment = -4108;
                excelSheet.Range["F" + (dataTable.Rows.Count + 12), "F" + (dataTable.Rows.Count + 13)].HorizontalAlignment = -4108;
                excelSheet.Range["A" + (dataTable.Rows.Count + 14), "J" + (dataTable.Rows.Count + 15)].HorizontalAlignment = -4108;
                //Merge
                excelSheet.Range["G1", "K1"].MergeCells = true;
                excelSheet.Range["G2", "K2"].MergeCells = true;
                excelSheet.Range["G3", "K3"].MergeCells = true;
                excelSheet.Range["A4", "K4"].MergeCells = true;
                excelSheet.Range["A5", "K5"].MergeCells = true;
                excelSheet.Range["A6", "K6"].MergeCells = true;
                excelSheet.Range["A7", "K7"].MergeCells = true;
                excelSheet.Range["A9", "C9"].MergeCells = true;
                excelSheet.Range["D9", "E9"].MergeCells = true;
                excelSheet.Range["H9", "I9"].MergeCells = true;
                excelSheet.Range["J9", "K9"].MergeCells = true;
                //excelSheet.Range["G" + (dataTable.Rows.Count + 13), "H" + (dataTable.Rows.Count + 13)].MergeCells = true;
                //excelSheet.Range["G" + (dataTable.Rows.Count + 14), "H" + (dataTable.Rows.Count + 14)].MergeCells = true;
                //excelSheet.Range["G" + (dataTable.Rows.Count + 15), "H" + (dataTable.Rows.Count + 15)].MergeCells = true;
                //excelSheet.Range["G" + (dataTable.Rows.Count + 16), "H" + (dataTable.Rows.Count + 16)].MergeCells = true;
                //Kích thước Cột và Dòng
                excelSheet.Range["A1", "A" + (dataTable.Rows.Count + 20)].RowHeight = "16.5";
                excelSheet.Range["A1"].ColumnWidth = 6;
                excelSheet.Range["B1"].ColumnWidth = 6;
                excelSheet.Range["C1"].ColumnWidth = 10;
                excelSheet.Range["D1"].ColumnWidth = 6;
                excelSheet.Range["E1"].ColumnWidth = 10;
                excelSheet.Range["F1"].ColumnWidth = 40;
                excelSheet.Range["G1"].ColumnWidth = 6;
                excelSheet.Range["H1", "K1"].ColumnWidth = 10;
                //Border
                excelSheet.Range["A9", "K10"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A9", "K10"].Borders.Weight = 2d;
                excelSheet.Range["A11", "K" + (dataTable.Rows.Count + 11)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot;
                excelSheet.Range["A11", "K" + (dataTable.Rows.Count + 11)].Borders.Weight = 2d;
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "K" + (dataTable.Rows.Count + 13)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "K" + (dataTable.Rows.Count + 13)].Borders.Weight = 2d;                
                //Công thức
                excelSheet.Range["H" + (dataTable.Rows.Count + 12), "H" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(I12:I{0})", dataTable.Rows.Count + 11);
                excelSheet.Range["I" + (dataTable.Rows.Count + 12), "I" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(I12:I{0})", dataTable.Rows.Count + 11);
                excelSheet.Range["J" + (dataTable.Rows.Count + 12), "J" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(J12:J{0})", dataTable.Rows.Count + 11);
                excelSheet.Range["K" + (dataTable.Rows.Count + 12), "K" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(K12:K{0})", dataTable.Rows.Count + 11);
                //format
                excelSheet.Range["C12", "C" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["E12", "E" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["H12", "H" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["I12", "I" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["J12", "J" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["K12", "K" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                #endregion

                //gắn header
                excelSheet.Range["G1"].Value2 = "Mẫu số S31-DN";
                excelSheet.Range["G2"].Value2 = "(Ban hành theo QĐ số 15/2006/QĐ-BTC";
                excelSheet.Range["G3"].Value2 = "ngày 20/3/2006 của Bộ trưởng BTC)";
                excelSheet.Range["A1"].Value2 = "CÔNG TY ABCDab";
                excelSheet.Range["A2"].Value2 = "M17 LÊ HOÀNG PHÁI,GÒ VẤP,TP.HCM";
                excelSheet.Range["A3"].Value2 = "Mã số thuế : 0300688235";
                excelSheet.Range["A4"].Value2 = "SỔ CHI TIẾT TÀI KHOẢN THEO ĐỐI TƯỢNG";
                excelSheet.Range["A5"].Value2 = "Tài khoản : " + taikhoan;
                excelSheet.Range["A6"].Value2 = "Khách hàng : " + madtpn;
                excelSheet.Range["A7"].Value2 = "Từ ngày " + from.ToString("dd/MM/yyyy") + " đến ngày " + to.ToString("dd/MM/yyyy");
                excelSheet.Range["A9"].Value2 = "Chứng từ";
                excelSheet.Range["D9"].Value2 = "Hóa đơn";
                excelSheet.Range["F9"].Value2 = "Diễn giải";
                excelSheet.Range["G9"].Value2 = "TK";
                excelSheet.Range["H9"].Value2 = "Phát sinh VND";
                excelSheet.Range["J9"].Value2 = "Cuối kỳ VND";
                excelSheet.Range["A10"].Value2 = "Loại";
                excelSheet.Range["B10"].Value2 = "Số";
                excelSheet.Range["C10"].Value2 = "Ngày";
                excelSheet.Range["D10"].Value2 = "Số";
                excelSheet.Range["E10"].Value2 = "Ngày";
                excelSheet.Range["G10"].Value2 = "Đ.Ứ";
                excelSheet.Range["H10"].Value2 = "Nợ";
                excelSheet.Range["I10"].Value2 = "Có";
                excelSheet.Range["J10"].Value2 = "Nợ";
                excelSheet.Range["K10"].Value2 = "Có";
                excelSheet.Range["F11"].Value2 = "SỐ DƯ ĐẦU KỲ";
                excelSheet.Range["F" + (dataTable.Rows.Count + 12)].Value2 = "CỘNG PHÁT SINH";
                excelSheet.Range["F" + (dataTable.Rows.Count + 13)].Value2 = "SỐ DƯ CUỐI KỲ";
                excelSheet.Range["J" + (dataTable.Rows.Count + 14)].Value2 = "Ngày " + print.Day + " tháng " + print.Month + " năm " + print.Year;
                excelSheet.Range["B" + (dataTable.Rows.Count + 15)].Value2 = "Người lập";
                excelSheet.Range["F" + (dataTable.Rows.Count + 15)].Value2 = "Kế toán trưởng";
                excelSheet.Range["J" + (dataTable.Rows.Count + 15)].Value2 = "Giám đốc";
                // loop through each row and add values to our sheet
                int rowcount = 11;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    excelSheet.Range["A" + rowcount].Value2 = datarow["LOAI_CT"].ToString();
                    excelSheet.Range["B" + rowcount].Value2 = datarow["SO_CT"].ToString();
                    excelSheet.Range["C" + rowcount].Value2 = datarow["NGAY_CT"].ToString();
                    excelSheet.Range["D" + rowcount].Value2 = datarow["SO_HOADON"].ToString();
                    excelSheet.Range["E" + rowcount].Value2 = datarow["NGAY_HOADON"].ToString();
                    excelSheet.Range["F" + rowcount].Value2 = datarow["DIENGIAI"].ToString();
                    excelSheet.Range["G" + rowcount].Value2 = datarow["TKDU"].ToString();
                    excelSheet.Range["H" + rowcount].Value2 = datarow["NO_VND"].ToString();
                    excelSheet.Range["I" + rowcount].Value2 = datarow["CO_VND"].ToString();
                    excelSheet.Range["J" + rowcount].Value2 = datarow["NO_CUOIKY_VND"].ToString();
                    excelSheet.Range["K" + rowcount].Value2 = datarow["CO_CUOIKY_VND"].ToString();
                }

                //now save the workbook and exit Excel
                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                Process.Start(saveAsLocation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }
        public bool WriteDataTableToExcel_SOCTCN27_Chitiettheosohoadonhanghoa(System.Data.DataTable dataTable, string taikhoan, string madtpn, DateTime from, DateTime to, DateTime print)
        {
            string saveAsLocation = Application.StartupPath + @"\Excel\SOCTCN27.xls";
            string worksheetName = "IN";

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;
                excelSheet.PageSetup.Application.ActiveWindow.DisplayGridlines = false;

                #region General Cells
                //Kiểu chữ
                excelSheet.Range["A1", "P" + (dataTable.Rows.Count + 20)].Font.Name = "Times New Roman";
                excelSheet.Range["A4", "P10"].Font.Name = "Tahoma";
                //Font chữ
                excelSheet.Range["A1", "A3"].Font.Size = 10;
                excelSheet.Range["A4", "A7"].Font.Size = 12;
                excelSheet.Range["A9", "P10"].Font.Size = 10;
                excelSheet.Range["A12", "P" + (dataTable.Rows.Count + 11)].Font.Size = 9;
                excelSheet.Range["A4", "A6"].Font.FontStyle = "Bold";
                excelSheet.Range["A9", "P11"].Font.FontStyle = "Bold";
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "P" + (dataTable.Rows.Count + 13)].Font.FontStyle = "Bold";
                excelSheet.Range["A" + (dataTable.Rows.Count + 15), "P" + (dataTable.Rows.Count + 15)].Font.FontStyle = "Bold";
                //Canh giữa chữ
                excelSheet.Range["G1", "G3"].HorizontalAlignment = -4108;
                excelSheet.Range["A4", "A7"].HorizontalAlignment = -4108;
                excelSheet.Range["A9", "P11"].HorizontalAlignment = -4108;
                excelSheet.Range["A12", "E" + (dataTable.Rows.Count + 11)].HorizontalAlignment = -4108;
                excelSheet.Range["F" + (dataTable.Rows.Count + 12), "F" + (dataTable.Rows.Count + 13)].HorizontalAlignment = -4108;
                excelSheet.Range["A" + (dataTable.Rows.Count + 14), "P" + (dataTable.Rows.Count + 15)].HorizontalAlignment = -4108;
                //Merge
                excelSheet.Range["G1", "P1"].MergeCells = true;
                excelSheet.Range["G2", "P2"].MergeCells = true;
                excelSheet.Range["G3", "P3"].MergeCells = true;
                excelSheet.Range["A4", "P4"].MergeCells = true;
                excelSheet.Range["A5", "P5"].MergeCells = true;
                excelSheet.Range["A6", "P6"].MergeCells = true;
                excelSheet.Range["A7", "P7"].MergeCells = true;
                excelSheet.Range["A9", "C9"].MergeCells = true;
                excelSheet.Range["D9", "E9"].MergeCells = true;
                excelSheet.Range["M9", "N9"].MergeCells = true;
                excelSheet.Range["O9", "P9"].MergeCells = true;
                //Kích thước Cột và Dòng
                excelSheet.Range["A1", "A" + (dataTable.Rows.Count + 20)].RowHeight = "16.5";
                excelSheet.Range["A1"].ColumnWidth = 6;
                excelSheet.Range["B1"].ColumnWidth = 6;
                excelSheet.Range["C1"].ColumnWidth = 10;
                excelSheet.Range["D1"].ColumnWidth = 6;
                excelSheet.Range["E1"].ColumnWidth = 10;
                excelSheet.Range["F1"].ColumnWidth = 40;
                excelSheet.Range["G1"].ColumnWidth = 6;
                excelSheet.Range["H1"].ColumnWidth = 8;
                excelSheet.Range["I1"].ColumnWidth = 30; 
                excelSheet.Range["J1"].ColumnWidth = 6;
                excelSheet.Range["K1"].ColumnWidth = 8;
                excelSheet.Range["L1"].ColumnWidth = 8;
                excelSheet.Range["M1", "P1"].ColumnWidth = 10;
                //Border
                excelSheet.Range["A9", "P10"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A9", "P10"].Borders.Weight = 2d;
                excelSheet.Range["A11", "P" + (dataTable.Rows.Count + 11)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot;
                excelSheet.Range["A11", "P" + (dataTable.Rows.Count + 11)].Borders.Weight = 2d;
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "P" + (dataTable.Rows.Count + 13)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "P" + (dataTable.Rows.Count + 13)].Borders.Weight = 2d;
                //Công thức
                excelSheet.Range["M" + (dataTable.Rows.Count + 12), "M" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(M12:M{0})", dataTable.Rows.Count + 11);
                excelSheet.Range["N" + (dataTable.Rows.Count + 12), "N" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(N12:N{0})", dataTable.Rows.Count + 11);
                excelSheet.Range["O" + (dataTable.Rows.Count + 12), "O" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(O12:O{0})", dataTable.Rows.Count + 11);
                excelSheet.Range["P" + (dataTable.Rows.Count + 12), "P" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(P12:P{0})", dataTable.Rows.Count + 11);
                //format
                excelSheet.Range["C12", "C" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["E12", "E" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["M12", "M" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["N12", "N" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["O12", "O" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["P12", "P" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                #endregion

                //gắn header
                excelSheet.Range["G1"].Value2 = "Mẫu số S31-DN";
                excelSheet.Range["G2"].Value2 = "(Ban hành theo QĐ số 15/2006/QĐ-BTC";
                excelSheet.Range["G3"].Value2 = "ngày 20/3/2006 của Bộ trưởng BTC)";
                excelSheet.Range["A1"].Value2 = "CÔNG TY ABCDab";
                excelSheet.Range["A2"].Value2 = "M17 LÊ HOÀNG PHÁI,GÒ VẤP,TP.HCM";
                excelSheet.Range["A3"].Value2 = "Mã số thuế : 0300688235";
                excelSheet.Range["A4"].Value2 = "SỔ CHI TIẾT TÀI KHOẢN THEO ĐỐI TƯỢNG";
                excelSheet.Range["A5"].Value2 = "Tài khoản : " + taikhoan;
                excelSheet.Range["A6"].Value2 = "Khách hàng : " + madtpn;
                excelSheet.Range["A7"].Value2 = "Từ ngày " + from.ToString("dd/MM/yyyy") + " đến ngày " + to.ToString("dd/MM/yyyy");
                excelSheet.Range["A9"].Value2 = "Chứng từ";
                excelSheet.Range["D9"].Value2 = "Hóa đơn";
                excelSheet.Range["F9"].Value2 = "Diễn giải";
                excelSheet.Range["G9"].Value2 = "TK";
                excelSheet.Range["H9"].Value2 = "Mã";
                excelSheet.Range["I9"].Value2 = "Tên HH";
                excelSheet.Range["J9"].Value2 = "ĐVT";
                excelSheet.Range["K9"].Value2 = "Số";
                excelSheet.Range["L9"].Value2 = "Đơn";
                excelSheet.Range["M9"].Value2 = "Phát sinh VND";
                excelSheet.Range["O9"].Value2 = "Cuối kỳ VND";
                excelSheet.Range["A10"].Value2 = "Loại";
                excelSheet.Range["B10"].Value2 = "Số";
                excelSheet.Range["C10"].Value2 = "Ngày";
                excelSheet.Range["D10"].Value2 = "Số";
                excelSheet.Range["E10"].Value2 = "Ngày";
                excelSheet.Range["G10"].Value2 = "Đ.Ứ";
                excelSheet.Range["H10"].Value2 = "HH";
                excelSheet.Range["K10"].Value2 = "lượng";
                excelSheet.Range["L10"].Value2 = "giá";
                excelSheet.Range["M10"].Value2 = "Nợ";
                excelSheet.Range["N10"].Value2 = "Có";
                excelSheet.Range["O10"].Value2 = "Nợ";
                excelSheet.Range["P10"].Value2 = "Có";
                excelSheet.Range["F11"].Value2 = "SỐ DƯ ĐẦU KỲ";
                excelSheet.Range["F" + (dataTable.Rows.Count + 12)].Value2 = "CỘNG PHÁT SINH";
                excelSheet.Range["F" + (dataTable.Rows.Count + 13)].Value2 = "SỐ DƯ CUỐI KỲ";
                excelSheet.Range["O" + (dataTable.Rows.Count + 14)].Value2 = "Ngày " + print.Day + " tháng " + print.Month + " năm " + print.Year;
                excelSheet.Range["B" + (dataTable.Rows.Count + 15)].Value2 = "Người lập";
                excelSheet.Range["I" + (dataTable.Rows.Count + 15)].Value2 = "Kế toán trưởng";
                excelSheet.Range["O" + (dataTable.Rows.Count + 15)].Value2 = "Giám đốc";
                // loop through each row and add values to our sheet
                int rowcount = 11;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    excelSheet.Range["A" + rowcount].Value2 = datarow["LOAI_CT"].ToString();
                    excelSheet.Range["B" + rowcount].Value2 = datarow["SO_CT"].ToString();
                    excelSheet.Range["C" + rowcount].Value2 = datarow["NGAY_CT"].ToString();
                    excelSheet.Range["D" + rowcount].Value2 = datarow["SO_HOADON"].ToString();
                    excelSheet.Range["E" + rowcount].Value2 = datarow["NGAY_HOADON"].ToString();
                    excelSheet.Range["F" + rowcount].Value2 = datarow["DIENGIAI"].ToString();
                    excelSheet.Range["G" + rowcount].Value2 = datarow["TKDU"].ToString();
                    excelSheet.Range["H" + rowcount].Value2 = datarow["MAHH"].ToString();
                    excelSheet.Range["I" + rowcount].Value2 = datarow["TENHH"].ToString();
                    excelSheet.Range["J" + rowcount].Value2 = datarow["DONVI"].ToString();
                    excelSheet.Range["K" + rowcount].Value2 = datarow["SOLUONG"].ToString();
                    excelSheet.Range["L" + rowcount].Value2 = datarow["TKDU"].ToString();
                    excelSheet.Range["M" + rowcount].Value2 = datarow["NO_VND"].ToString();
                    excelSheet.Range["N" + rowcount].Value2 = datarow["CO_VND"].ToString();
                    excelSheet.Range["O" + rowcount].Value2 = datarow["NO_CUOIKY_VND"].ToString();
                    excelSheet.Range["P" + rowcount].Value2 = datarow["CO_CUOIKY_VND"].ToString();
                }

                //now save the workbook and exit Excel
                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                Process.Start(saveAsLocation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }
        public bool WriteDataTableToExcel_SOCTCN19_04_Chitiettheohanghoa(System.Data.DataTable dataTable, string taikhoan, string madtpn, DateTime from, DateTime to, DateTime print)
        {
            string saveAsLocation = Application.StartupPath + @"\Excel\SOCTCN19_04.xls";
            string worksheetName = "IN";

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;
                excelSheet.PageSetup.Application.ActiveWindow.DisplayGridlines = false;

                #region General Cells
                //Kiểu chữ
                excelSheet.Range["A1", "I" + (dataTable.Rows.Count + 12)].Font.Name = "Times New Roman";
                excelSheet.Range["A4", "I10"].Font.Name = "Tahoma";
                //Font chữ
                excelSheet.Range["A1", "A3"].Font.Size = 10;
                excelSheet.Range["A4", "A7"].Font.Size = 12;
                excelSheet.Range["A9", "I10"].Font.Size = 10;
                excelSheet.Range["A12", "I" + (dataTable.Rows.Count + 11)].Font.Size = 9;
                excelSheet.Range["A4", "A6"].Font.FontStyle = "Bold";
                excelSheet.Range["A9", "I11"].Font.FontStyle = "Bold";
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "I" + (dataTable.Rows.Count + 12)].Font.FontStyle = "Bold";
                //Canh giữa chữ
                excelSheet.Range["A4", "A7"].HorizontalAlignment = -4108;
                excelSheet.Range["A9", "I11"].HorizontalAlignment = -4108;
                excelSheet.Range["A12", "B" + (dataTable.Rows.Count + 11)].HorizontalAlignment = -4108;
                excelSheet.Range["C" + (dataTable.Rows.Count + 12), "C" + (dataTable.Rows.Count + 12)].HorizontalAlignment = -4108;
                //Merge
                excelSheet.Range["A4", "I4"].MergeCells = true;
                excelSheet.Range["A5", "I5"].MergeCells = true;
                excelSheet.Range["A6", "I6"].MergeCells = true;
                excelSheet.Range["A7", "I7"].MergeCells = true;
                excelSheet.Range["A9", "B9"].MergeCells = true;
                //Kích thước Cột và Dòng
                excelSheet.Range["A1", "A" + (dataTable.Rows.Count + 12)].RowHeight = "16.5";
                excelSheet.Range["A1"].ColumnWidth = 6;
                excelSheet.Range["B1"].ColumnWidth = 10;
                excelSheet.Range["C1"].ColumnWidth = 30;
                excelSheet.Range["D1"].ColumnWidth = 6;
                excelSheet.Range["E1"].ColumnWidth = 6;
                excelSheet.Range["F1"].ColumnWidth = 10;
                excelSheet.Range["G1"].ColumnWidth = 10;
                excelSheet.Range["H1"].ColumnWidth = 8;
                excelSheet.Range["I1"].ColumnWidth = 10;
                //Border
                excelSheet.Range["A9", "I10"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A9", "I10"].Borders.Weight = 2d;
                excelSheet.Range["A11", "I" + (dataTable.Rows.Count + 11)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot;
                excelSheet.Range["A11", "I" + (dataTable.Rows.Count + 11)].Borders.Weight = 2d;
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "I" + (dataTable.Rows.Count + 12)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A" + (dataTable.Rows.Count + 12), "I" + (dataTable.Rows.Count + 12)].Borders.Weight = 2d;
                //Công thức
                excelSheet.Range["F" + (dataTable.Rows.Count + 12), "F" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(F12:F{0})", dataTable.Rows.Count + 11);
                excelSheet.Range["G" + (dataTable.Rows.Count + 12), "G" + (dataTable.Rows.Count + 12)].Formula = String.Format("=sum(G12:G{0})", dataTable.Rows.Count + 11);
                //format
                excelSheet.Range["B12", "B" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["F12", "F" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["G12", "G" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["H12", "H" + (dataTable.Rows.Count + 13)].EntireColumn.NumberFormat = "#,###";
                #endregion

                //gắn header
                excelSheet.Range["A1"].Value2 = "CÔNG TY ABCDab";
                excelSheet.Range["A2"].Value2 = "M17 LÊ HOÀNG PHÁI,GÒ VẤP,TP.HCM";
                excelSheet.Range["A3"].Value2 = "Mã số thuế : 0300688235";
                excelSheet.Range["A4"].Value2 = "SỔ CHI TIẾT TÀI KHOẢN THEO ĐỐI TƯỢNG";
                excelSheet.Range["A5"].Value2 = "Tài khoản : " + taikhoan;
                excelSheet.Range["A6"].Value2 = "Khách hàng : " + madtpn;
                excelSheet.Range["A7"].Value2 = "Từ ngày " + from.ToString("dd/MM/yyyy") + " đến ngày " + to.ToString("dd/MM/yyyy");
                excelSheet.Range["A9"].Value2 = "Chứng từ";
                excelSheet.Range["C9"].Value2 = "Diễn giải";
                excelSheet.Range["D9"].Value2 = "Đơn";
                excelSheet.Range["E9"].Value2 = "Số";
                excelSheet.Range["F9"].Value2 = "Thành";
                excelSheet.Range["G9"].Value2 = "Thanh";
                excelSheet.Range["H9"].Value2 = "Còn";
                excelSheet.Range["I9"].Value2 = "Người giao";
                excelSheet.Range["A10"].Value2 = "Số";
                excelSheet.Range["B10"].Value2 = "Ngày";
                excelSheet.Range["D10"].Value2 = "Vị";
                excelSheet.Range["E10"].Value2 = "Lượng";
                excelSheet.Range["F10"].Value2 = "Tiền";
                excelSheet.Range["G10"].Value2 = "Toán";
                excelSheet.Range["H10"].Value2 = "nợ";
                excelSheet.Range["C11"].Value2 = "SỐ DƯ ĐẦU KỲ";
                excelSheet.Range["C" + (dataTable.Rows.Count + 12)].Value2 = "CỘNG PHÁT SINH";
                // loop through each row and add values to our sheet
                int rowcount = 11;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    excelSheet.Range["A" + rowcount].Value2 = datarow["SO_CT"].ToString();
                    excelSheet.Range["B" + rowcount].Value2 = datarow["NGAY_CT"].ToString();
                    excelSheet.Range["C" + rowcount].Value2 = datarow["DIENGIAI"].ToString();
                    excelSheet.Range["D" + rowcount].Value2 = datarow["DONVI"].ToString();
                    excelSheet.Range["E" + rowcount].Value2 = datarow["SOLUONG"].ToString();
                    excelSheet.Range["F" + rowcount].Value2 = datarow["SOLUONG"].ToString();
                    excelSheet.Range["G" + rowcount].Value2 = datarow["SOLUONG"].ToString();
                    excelSheet.Range["H" + rowcount].Value2 = datarow["SOLUONG"].ToString();
                    excelSheet.Range["I" + rowcount].Value2 = datarow["SOLUONG"].ToString();
                }

                //now save the workbook and exit Excel
                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                Process.Start(saveAsLocation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }
        //4
        public bool WriteDataTableToExcel_SOCTCN21_331_01_V_Mau1(System.Data.DataTable dataTable, string taikhoan, string madtpn, DateTime from, DateTime to, DateTime print)
        {
            string saveAsLocation = Application.StartupPath + @"\Excel\SOCTCN21_331_01_V.xls";
            string worksheetName = "IN";

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;
                excelSheet.PageSetup.Application.ActiveWindow.DisplayGridlines = false;

                #region General Cells
                //Kiểu chữ
                excelSheet.Range["A1", "L" + (dataTable.Rows.Count + 55)].Font.Name = "Times New Roman";
                excelSheet.Range["A4", "L10"].Font.Name = "Tahoma";
                //Font chữ
                excelSheet.Range["A1", "A3"].Font.Size = 10;
                excelSheet.Range["A4", "A7"].Font.Size = 12;
                excelSheet.Range["A8", "L9"].Font.Size = 10;
                excelSheet.Range["A10", "L" + (dataTable.Rows.Count + 9)].Font.Size = 9;
                excelSheet.Range["A4", "A4"].Font.FontStyle = "Bold";
                excelSheet.Range["A8", "L9"].Font.FontStyle = "Bold";
                excelSheet.Range["A" + (dataTable.Rows.Count + 30), "L" + (dataTable.Rows.Count + 30)].Font.FontStyle = "Bold";
                excelSheet.Range["A" + (dataTable.Rows.Count + 11), "L" + (dataTable.Rows.Count + 16)].Font.FontStyle = "Bold";
                //Canh giữa chữ
                excelSheet.Range["A4", "L9"].HorizontalAlignment = -4108;
                excelSheet.Range["A10", "B" + (dataTable.Rows.Count + 10)].HorizontalAlignment = -4108;
                excelSheet.Range["C" + (dataTable.Rows.Count + 11), "C" + (dataTable.Rows.Count + 16)].HorizontalAlignment = -4108;
                excelSheet.Range["A" + (dataTable.Rows.Count + 29), "L" + (dataTable.Rows.Count + 31)].HorizontalAlignment = -4108;
                //Merge
                excelSheet.Range["A4", "L4"].MergeCells = true;
                excelSheet.Range["A5", "L5"].MergeCells = true;
                excelSheet.Range["A6", "L6"].MergeCells = true;
                excelSheet.Range["A8", "B8"].MergeCells = true;
                excelSheet.Range["G8", "H8"].MergeCells = true;
                excelSheet.Range["D" + (dataTable.Rows.Count + 13), "F" + (dataTable.Rows.Count + 13)].MergeCells = true;
                excelSheet.Range["D" + (dataTable.Rows.Count + 14), "F" + (dataTable.Rows.Count + 14)].MergeCells = true;
                excelSheet.Range["D" + (dataTable.Rows.Count + 15), "F" + (dataTable.Rows.Count + 15)].MergeCells = true;
                excelSheet.Range["D" + (dataTable.Rows.Count + 16), "F" + (dataTable.Rows.Count + 16)].MergeCells = true;
                excelSheet.Range["D" + (dataTable.Rows.Count + 18), "F" + (dataTable.Rows.Count + 18)].MergeCells = true;
                excelSheet.Range["A" + (dataTable.Rows.Count + 30), "C" + (dataTable.Rows.Count + 30)].MergeCells = true;
                excelSheet.Range["A" + (dataTable.Rows.Count + 31), "C" + (dataTable.Rows.Count + 31)].MergeCells = true;
                //Kích thước Cột và Dòng
                excelSheet.Range["A1", "A" + (dataTable.Rows.Count + 55)].RowHeight = "16.5";
                excelSheet.Range["A1"].ColumnWidth = 10;
                excelSheet.Range["B1"].ColumnWidth = 8;
                excelSheet.Range["C1"].ColumnWidth = 45;
                excelSheet.Range["D1", "I1"].ColumnWidth = 8;
                excelSheet.Range["J1", "L1"].ColumnWidth = 10;
                //Border
                excelSheet.Range["A8", "L9"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A8", "L9"].Borders.Weight = 2d;
                excelSheet.Range["A10", "L" + (dataTable.Rows.Count + 10)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot;
                excelSheet.Range["A10", "L" + (dataTable.Rows.Count + 10)].Borders.Weight = 2d;
                excelSheet.Range["A" + (dataTable.Rows.Count + 11), "L" + (dataTable.Rows.Count + 11)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A" + (dataTable.Rows.Count + 11), "L" + (dataTable.Rows.Count + 11)].Borders.Weight = 2d;
                excelSheet.Range["C" + (dataTable.Rows.Count + 13), "F" + (dataTable.Rows.Count + 16)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["C" + (dataTable.Rows.Count + 13), "F" + (dataTable.Rows.Count + 16)].Borders.Weight = 2d;
                //Công thức
                excelSheet.Range["G" + (dataTable.Rows.Count + 11), "G" + (dataTable.Rows.Count + 11)].Formula = String.Format("=sum(G11:G{0})", dataTable.Rows.Count + 10);
                excelSheet.Range["H" + (dataTable.Rows.Count + 11), "H" + (dataTable.Rows.Count + 11)].Formula = String.Format("=sum(H11:H{0})", dataTable.Rows.Count + 10);
                excelSheet.Range["J" + (dataTable.Rows.Count + 11), "J" + (dataTable.Rows.Count + 11)].Formula = String.Format("=sum(J11:J{0})", dataTable.Rows.Count + 10);
                excelSheet.Range["K" + (dataTable.Rows.Count + 11), "K" + (dataTable.Rows.Count + 11)].Formula = String.Format("=sum(K11:K{0})", dataTable.Rows.Count + 10);
                excelSheet.Range["L" + (dataTable.Rows.Count + 11), "L" + (dataTable.Rows.Count + 11)].Formula = String.Format("=sum(L11:L{0})", dataTable.Rows.Count + 10);
                //format
                excelSheet.Range["A11", "A" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "dd/MM/yyyy";
                excelSheet.Range["G11", "G" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["H11", "H" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["I11", "I" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["J11", "J" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["K11", "K" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["L11", "L" + (dataTable.Rows.Count + 11)].EntireColumn.NumberFormat = "#,###";
                excelSheet.Range["D" + (dataTable.Rows.Count + 13), "D" + (dataTable.Rows.Count + 16)].EntireColumn.NumberFormat = "#,###";
                #endregion

                //gắn header
                excelSheet.Range["A1"].Value2 = "CÔNG TY ABCDab";
                excelSheet.Range["A2"].Value2 = "M17 LÊ HOÀNG PHÁI,GÒ VẤP,TP.HCM";
                excelSheet.Range["A3"].Value2 = "Mã số thuế: 0300688235";
                excelSheet.Range["A4"].Value2 = "ĐỐI CHIẾU CÔNG NỢ PHẢI THU";
                excelSheet.Range["A5"].Value2 = "Khách hàng:" + taikhoan;
                excelSheet.Range["A6"].Value2 = "Từ ngày " + from.ToString("dd/MM/yyyy") + " đến ngày " + to.ToString("dd/MM/yyyy");
                excelSheet.Range["A8"].Value2 = "Chứng từ";                
                excelSheet.Range["C8"].Value2 = "Nội dung";
                excelSheet.Range["D8"].Value2 = "TK";
                excelSheet.Range["E8"].Value2 = "Mã";
                excelSheet.Range["F8"].Value2 = "ĐVT";
                excelSheet.Range["G8"].Value2 = "Số lượng";
                excelSheet.Range["I8"].Value2 = "Đơn giá";
                excelSheet.Range["J8"].Value2 = "Thành tiền";
                excelSheet.Range["K8"].Value2 = "Đã";
                excelSheet.Range["L8"].Value2 = "Số dư";
                excelSheet.Range["A9"].Value2 = "Ngày";
                excelSheet.Range["B9"].Value2 = "Số";
                excelSheet.Range["D9"].Value2 = "Đ.Ứ";
                excelSheet.Range["E9"].Value2 = "hàng";
                excelSheet.Range["G9"].Value2 = "Mua";
                excelSheet.Range["H9"].Value2 = "Trả lại";
                excelSheet.Range["K9"].Value2 = "thanh toán";
                excelSheet.Range["L9"].Value2 = "cuối kỳ";
                excelSheet.Range["C10"].Value2 = "Số dư đầu kỳ------>";
                excelSheet.Range["C" + (dataTable.Rows.Count + 11)].Value2 = "Tổng cộng";
                excelSheet.Range["C" + (dataTable.Rows.Count + 13)].Value2 = "SỐ DƯ ĐẦU KỲ";
                excelSheet.Range["C" + (dataTable.Rows.Count + 14)].Value2 = "MUA TRONG KỲ";
                excelSheet.Range["C" + (dataTable.Rows.Count + 15)].Value2 = "TRẢ TRONG KỲ";
                excelSheet.Range["C" + (dataTable.Rows.Count + 16)].Value2 = "SỐ DƯ CUỐI KỲ";
                excelSheet.Range["A" + (dataTable.Rows.Count + 18)].Value2 = "Như vậy đến cuối ngày "+to.ToString("dd/MM/yyyy")+", Quý đơn vị còn nợ công ty chúng tôi :";
                excelSheet.Range["A" + (dataTable.Rows.Count + 19)].Value2 = "Bằng chữ : "+ Common.So_chu(Utils.CDblDef(excelSheet.Range["D" + (dataTable.Rows.Count + 16)].Value2, 0));
                excelSheet.Range["A" + (dataTable.Rows.Count + 21)].Value2 = "Nếu số dư công nợ cuối kỳ đã đúng kính mong Quý Đơn Vị ký xác nhận Fax lại cho chúng tôi theo số Fax :";
                excelSheet.Range["A" + (dataTable.Rows.Count + 22)].Value2 = "Nếu số dư cuối kỳ không đúng ,mong Quý đơn vị liên hệ với chúng tôi :";
                excelSheet.Range["A" + (dataTable.Rows.Count + 23)].Value2 = "Phòng kế toán : ĐT: . . .  ( chậm nhất tới ngày 15  trong tháng)";
                excelSheet.Range["A" + (dataTable.Rows.Count + 24)].Value2 = "Nếu quá thời hạn trên Quý Đơn Vị không thắc mắc gì thì số dư cuối kỳ coi như đúng , chúng  tôi không chịu bất kỳ khoản sai lệch nào nếu có .Mong Quý Đơn Vị thông cảm";
                excelSheet.Range["B" + (dataTable.Rows.Count + 26)].Value2 = "Trân trọng kính chào!";
                excelSheet.Range["J" + (dataTable.Rows.Count + 29)].Value2 = "Ngày " + print.Day + " tháng " + print.Month + " năm " + print.Year;
                excelSheet.Range["A" + (dataTable.Rows.Count + 30)].Value2 = "XÁC NHẬN BÊN MUA";
                excelSheet.Range["E" + (dataTable.Rows.Count + 30)].Value2 = "NGƯỜI LẬP";
                excelSheet.Range["J" + (dataTable.Rows.Count + 30)].Value2 = "XÁC NHẬN BÊN BÁN";
                excelSheet.Range["A" + (dataTable.Rows.Count + 31)].Value2 = "(Ký, họ tên, đóng dấu)";
                excelSheet.Range["E" + (dataTable.Rows.Count + 31)].Value2 = "(Ký, họ tên, đóng dấu)";
                excelSheet.Range["J" + (dataTable.Rows.Count + 31)].Value2 = "(Ký, họ tên, đóng dấu)";
                // loop through each row and add values to our sheet
                int rowcount = 10;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    excelSheet.Range["A" + rowcount].Value2 = datarow["NGAY_CT"].ToString();
                    excelSheet.Range["B" + rowcount].Value2 = datarow["SO_CT"].ToString();
                    excelSheet.Range["C" + rowcount].Value2 = datarow["DIENGIAI"].ToString();
                    excelSheet.Range["D" + rowcount].Value2 = datarow["TKDU"].ToString();
                    excelSheet.Range["E" + rowcount].Value2 = "";
                    excelSheet.Range["F" + rowcount].Value2 = datarow["DONVI"].ToString();
                    excelSheet.Range["G" + rowcount].Value2 = datarow["SOLUONG"].ToString();
                    excelSheet.Range["H" + rowcount].Value2 = datarow["SOLUONG"].ToString();
                    excelSheet.Range["I" + rowcount].Value2 = datarow["DONGIA"].ToString();
                }

                //now save the workbook and exit Excel
                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                Process.Start(saveAsLocation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }
        //5
        public bool WriteDataTableToExcel_InCanDoiPhatSinhTaiKhoan_Mau1(System.Data.DataTable dataTable, DateTime from, DateTime to, DateTime print)
        {
            string saveAsLocation = Application.StartupPath + @"\Excel\InCanDoiPhatSinhTaiKhoan_Mau1.xls";
            string worksheetName = "IN";

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;
                excelSheet.PageSetup.Application.ActiveWindow.DisplayGridlines = false;

                #region General Cells
                //Kiểu chữ
                excelSheet.Range["A1", "H" + (dataTable.Rows.Count + 55)].Font.Name = "Tahoma";
                //Font chữ
                excelSheet.Range["A1", "A3"].Font.Size = 10;
                excelSheet.Range["G1", "G3"].Font.Size = 8;
                excelSheet.Range["A4", "A7"].Font.Size = 12;
                excelSheet.Range["A6", "H7"].Font.Size = 10;
                excelSheet.Range["A6", "H7"].Font.FontStyle = "Bold";
                excelSheet.Range["A8", "H" + (dataTable.Rows.Count + 8)].Font.Size = 9;
                excelSheet.Range["A4", "A4"].Font.FontStyle = "Bold";
                excelSheet.Range["A" + (dataTable.Rows.Count+ 30), "H" + (dataTable.Rows.Count + 30)].Font.FontStyle = "Bold";
                excelSheet.Range["A" + (dataTable.Rows.Count + 11), "H" + (dataTable.Rows.Count + 16)].Font.FontStyle = "Bold";
                //Canh giữa chữ
                excelSheet.Range["A4", "H7"].HorizontalAlignment = -4108;
                excelSheet.Range["A" + (dataTable.Rows.Count + 11), "H" + (dataTable.Rows.Count + 16)].HorizontalAlignment = -4108;
                excelSheet.Range["G1", "G3"].HorizontalAlignment = -4108;
                //Merge
                excelSheet.Range["A4", "H4"].MergeCells = true;
                excelSheet.Range["A5", "H5"].MergeCells = true;
                excelSheet.Range["C6", "D6"].MergeCells = true;
                excelSheet.Range["E6", "F6"].MergeCells = true;
                excelSheet.Range["G6", "H6"].MergeCells = true;
                //Kích thước Cột và Dòng
                excelSheet.Range["A1", "A" + (dataTable.Rows.Count + 55)].RowHeight = "16.5";
                excelSheet.Range["A1"].ColumnWidth = 9;
                excelSheet.Range["B1"].ColumnWidth = 40;
                excelSheet.Range["C1"].ColumnWidth = 15;
                excelSheet.Range["D1"].ColumnWidth = 15;
                excelSheet.Range["E1"].ColumnWidth = 15;
                excelSheet.Range["F1"].ColumnWidth = 15;
                excelSheet.Range["G1"].ColumnWidth = 15;
                excelSheet.Range["H1"].ColumnWidth = 15;
                //Border
                excelSheet.Range["A6", "H7"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A6", "H7"].Borders.Weight = 2d;
                excelSheet.Range["A8", "H" + (dataTable.Rows.Count + 8)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot;
                excelSheet.Range["A8", "H" + (dataTable.Rows.Count + 8)].Borders.Weight = 2d;
                excelSheet.Range["A" + (dataTable.Rows.Count + 9), "H" + (dataTable.Rows.Count + 9)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excelSheet.Range["A" + (dataTable.Rows.Count + 9), "H" + (dataTable.Rows.Count + 9)].Borders.Weight = 2d;
                //Công thức
                excelSheet.Range["H" + (dataTable.Rows.Count + 9), "H" + (dataTable.Rows.Count + 9)].Formula = String.Format("=sum(H10:H{0})", dataTable.Rows.Count + 9);
                //format
                
                #endregion

                CFGRepo _CFGRepo = new CFGRepo();
                //gắn header
                excelSheet.Range["A1"].Value2 = _CFGRepo.GetNameByIDV("ID01");
                excelSheet.Range["A2"].Value2 = _CFGRepo.GetNameByIDV("ID02");
                excelSheet.Range["A3"].Value2 = "Mã số thuế: " + _CFGRepo.GetNameByIDV("ID03");
                excelSheet.Range["A4"].Value2 = "BẢNG CÂN ĐỐI PHÁT SINH TÀI KHOẢN";
                excelSheet.Range["A5"].Value2 = "Từ ngày " + from.ToString("dd/MM/yyyy") + " đến ngày " + to.ToString("dd/MM/yyyy");
                excelSheet.Range["A6"].Value2 = "Mã";
                excelSheet.Range["A7"].Value2 = "hiệu";
                excelSheet.Range["B6"].Value2 = "Tên tài khoản";
                excelSheet.Range["C6"].Value2 = "Số dư đầu kỳ (Vnd)";
                excelSheet.Range["E6"].Value2 = "Phát sinh trong kỳ (Vnd)";
                excelSheet.Range["G1"].Value2 = "Mẫu số B01 – DN";
                excelSheet.Range["G2"].Value2 = "(Ban hành theo TT số 200/2014/TT-BTC";
                excelSheet.Range["G3"].Value2 = "Ngày 22/12/2014 của Bộ trưởng BTC)";
                excelSheet.Range["G6"].Value2 = "Số dư cuối kỳ (Vnd)";
                excelSheet.Range["C7"].Value2 = "Nợ";
                excelSheet.Range["D7"].Value2 = "Có";
                excelSheet.Range["E7"].Value2 = "Nợ";
                excelSheet.Range["F7"].Value2 = "Có";
                excelSheet.Range["G7"].Value2 = "Nợ";
                excelSheet.Range["H7"].Value2 = "Có";
                excelSheet.Range["B" + (dataTable.Rows.Count + 9)].Value2 = "Tổng cộng";
                excelSheet.Range["G" + (dataTable.Rows.Count + 11)].Value2 = "Ngày " + print.Day + " tháng " + print.Month + " năm " + print.Year;
                excelSheet.Range["B" + (dataTable.Rows.Count + 12)].Value2 = "Người lập";
                excelSheet.Range["D" + (dataTable.Rows.Count + 12)].Value2 = "Kế toán trưởng";
                excelSheet.Range["G" + (dataTable.Rows.Count + 12)].Value2 = "Giám đốc";
                excelSheet.Range["B" + (dataTable.Rows.Count + 16)].Value2 = "";
                excelSheet.Range["G" + (dataTable.Rows.Count + 16)].Value2 = _CFGRepo.GetNameByIDV("ID04");
                // loop through each row and add values to our sheet
                int rowcount = 7;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    excelSheet.Range["A" + rowcount].Value2 = datarow["MA_TK"].ToString();
                    excelSheet.Range["B" + rowcount].Value2 = datarow["TEN_TK"].ToString();
                    excelSheet.Range["C" + rowcount].Value2 = datarow["VND_DU_NO"].ToString();
                    excelSheet.Range["D" + rowcount].Value2 = datarow["VND_DU_CO"].ToString();
                    excelSheet.Range["E" + rowcount].Value2 = datarow["VND_PS_NO"].ToString();
                    excelSheet.Range["F" + rowcount].Value2 = datarow["VND_PS_CO"].ToString();
                    excelSheet.Range["G" + rowcount].Value2 = datarow["VND_CK_NO"].ToString();
                    excelSheet.Range["H" + rowcount].Value2 = datarow["VND_CK_CO"].ToString();
                }

                //now save the workbook and exit Excel
                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                Process.Start(saveAsLocation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }
        
    }
}
