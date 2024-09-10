using ExcelDataReader;
using OfficeOpenXml;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    internal class ReadDataExcel
    {
        /// <summary>
        /// Hàm đọc file excel sử dụng ExcelDataReader
        /// </summary>
        /// <param name="path">path/to/your/file.xlsx</param>
        public static void ReadExcel_1 (string filePath)
        {
            // Đăng ký nhà cung cấp mã hóa
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            // Mở tệp Excel
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Đọc dữ liệu từ tệp Excel
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Chuyển đổi dữ liệu thành DataSet
                    var result = reader.AsDataSet();

                    // Lặp qua các bảng dữ liệu
                    foreach (DataTable table in result.Tables)
                    {
                        Console.WriteLine($"Table: {table.TableName}");

                        // Lặp qua các hàng và cột
                        foreach (DataRow row in table.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                Console.Write($"{item}\t"); // In giá trị ô
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }


        public static void ReadExcel_2(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var fileInfo = new FileInfo(filePath);

            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Get the first worksheet
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;

                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= colCount; col++)
                    {
                        Console.Write($"{worksheet.Cells[row, col].Text}\t"); // Read cell value
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
