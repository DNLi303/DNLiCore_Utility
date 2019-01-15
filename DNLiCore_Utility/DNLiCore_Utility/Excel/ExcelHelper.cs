using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DNLiCore_Utility.Excel
{
    public static class ExcelHelper
    {
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";


        #region dataTable 导出excel
        /// <summary>
        /// dataTable 导出excel
        /// </summary>
        /// <param name="data">表格数据</param>
        /// <param name="path">保存的路径</param>
        /// <param name="reportHead">是否保存表头</param>
        /// <param name="workSheetName">sheet的名称</param>
        /// <remarks>
        /// string sWebRootFolder = _hostingEnvironment.WebRootPath;
        /// sWebRootFolder+"/Upload/Excel/report.xlsx"
        /// </remarks>
        public static void DataTableReport(DataTable data, string path, bool reportHead = true, string workSheetName = "Sheet1")
        {

            string savePath = Path.Combine(path);
            FileInfo newFile = new FileInfo(savePath);
            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(savePath);
            }
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(workSheetName);
                int totalColumsCount = data.Columns.Count;
                int totalRowsCount = data.Rows.Count;
                if (reportHead)
                {
                    for (int i = 0; i < totalColumsCount; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = data.Columns[i].ColumnName;
                    }
                    for (int i = 0; i < totalRowsCount; i++)
                    {
                        for (int y = 0; y < totalColumsCount; y++)
                        {
                            worksheet.Cells[i + 2, y + 1].Value = data.Rows[i][y].ToString();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < totalRowsCount; i++)
                    {
                        for (int y = 0; y < totalColumsCount; y++)
                        {
                            worksheet.Cells[i + 1, y + 1].Value = data.Rows[i][y].ToString();
                        }
                    }
                }
                package.Save();
            }
        }
        #endregion

        #region excel转成DataTable
        /// <summary>
        /// excel转成DataTable
        /// </summary>
        /// <param name="fileInfo">文件</param>
        /// <param name="worksheet">sheet名称</param>
        /// <returns></returns>
        private static DataTable readExcelPackageToDataTable(FileInfo fileInfo, string worksheetName = "Sheet1")
        {
            return GetExcelToTable(fileInfo, worksheetName);
        }
        /// <summary>
        /// excel转成DataTable
        /// </summary>
        /// <param name="fileRealPath">文件的实际路径</param>
        /// <param name="worksheetName">sheet名称</param>
        /// <remarks>
        ///  string sWebRootFolder = _hostingEnvironment.WebRootPath;
        ///  string realPath = Path.Combine(sWebRootFolder, "Upload/Excel/report.xlsx");
        /// </remarks>
        /// <returns></returns>
        private static DataTable readExcelPackageToDataTable(string fileRealPath, string worksheetName = "Sheet1")
        {
            FileInfo fileInfo = new FileInfo(fileRealPath);
            return GetExcelToTable(fileInfo, worksheetName);
        }
        public static DataTable GetExcelToTable(FileInfo fileInfo, string worksheetName)
        {
            var package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets[worksheetName];
            DataTable table = new DataTable(worksheet.Name);

            var rowCount = worksheet.Dimension?.Rows;
            var colCount = worksheet.Dimension?.Columns;

            if (!rowCount.HasValue || !colCount.HasValue)
            {
                return table;
            }

            //先构造table的列
            for (int col = 1; col <= colCount.Value; col++)
            {
                object colObject = worksheet.Cells[1, col].Value;
                string columName = colObject.ToString();
                DataColumn dataColumn = new DataColumn(columName, colObject.GetType());
                table.Columns.Add(dataColumn);  //构造列
            }
            for (int row = 2; row <= rowCount.Value; row++)
            {
                DataRow dataRow = table.NewRow();
                for (int col = 1; col <= colCount.Value; col++)
                {
                    dataRow[col - 1] = worksheet.Cells[row, col].Value;
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }
        #endregion
    }
}