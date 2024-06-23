namespace HappytoHelp.FileHelpers
{
    using Microsoft.VisualBasic;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static System.Net.WebRequestMethods;
    using File = System.IO.File;
    public class ExcelHelper
    {
        public static string ExportCSV(DataTable dt, string filename)
        {
            var lines = new List<string>(); string[] columnNames = dt.Columns
            .Cast<DataColumn>()
            .Select(column => column.ColumnName)
            .ToArray(); var header = string.Join(",", columnNames.Select(name => $"\"{name}\""));
            lines.Add(header); var valueLines = dt.AsEnumerable()
            .Select(row => string.Join(",", row.ItemArray.Select(val => $"\"{val}\""))); lines.AddRange(valueLines);
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + filename + ".csv"))
            {
                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + filename + ".csv");
            }
            File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + filename + ".csv", lines, Encoding.Unicode);
            return "";
        }

        public static string ExportExcel(DataTable[] dt, string filename, string[] tabname)
        {
            var workbook = new XSSFWorkbook();
            for (int i = 0; i < tabname.Length; i++)
            {
                var sheet = workbook.CreateSheet(tabname[i]);
                var headerRow = sheet.CreateRow(0);
                //Below loop is create header  
                foreach (DataColumn dc in dt[i].Columns)
                {
                    var cell = headerRow.CreateCell(dt[i].Columns.IndexOf(dc));
                    cell.SetCellValue(dc.ToString());
                }

                //Below loop is fill content  
                foreach (DataRow dr in dt[i].Rows)
                {
                    var rowIndex = dt[i].Rows.IndexOf(dr) + 1;
                    var row = sheet.CreateRow(rowIndex);

                    for (int j = 0; j < dt[i].Columns.Count; j++)
                    {
                        var cell = row.CreateCell(j);
                        cell.SetCellValue(dr[j].ToString() ?? "");
                    }
                }

            }

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + filename + ".xlsx"))
            {
                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + filename + ".xlsx");
            }
            using (var file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + filename + ".xlsx", FileMode.Create, FileAccess.ReadWrite))
            {
                var stream = new MemoryStream();
                workbook.Write(file);
                file.Close();
            }
            return "";
        }
        public static DataTable ExcelToDatatable(string excelPath, bool hasHeader, bool isMixedData, string sheetName, int startRow = -1, int endRow = -1, int startColumn = -1, int endColumn = -1)
        {
            DataTable dtTable = new DataTable();
            List<string> rowList = new List<string>();
            ISheet sheet;
            using (var stream = new FileStream(excelPath, FileMode.Open))
            {
                stream.Position = 0;
                XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                sheet = xssWorkbook.GetSheet(sheetName);
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;
                for (int j = 0; j < cellCount; j++)
                {
                    ICell cell = headerRow.GetCell(j);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                    {
                        dtTable.Columns.Add(cell.ToString());
                    }
                }
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                        {
                            if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                            {
                                rowList.Add(row.GetCell(j).ToString());
                            }
                        }
                    }
                    if (rowList.Count > 0)
                        dtTable.Rows.Add(rowList.ToArray());
                    rowList.Clear();
                }
                return dtTable;
            }
        }
    }

}
