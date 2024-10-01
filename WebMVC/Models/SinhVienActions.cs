using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System.Data;
using System.IO;
using OfficeOpenXml;


namespace WebMVC.Models
{
    public class SinhVienActions
    {
        // Khai báo đường dẫn file excel
        private string filePath = @"C:\Users\hoatx\Source\Repos\67IT-ASP.NET\WebMVC\Datas\ds_sinhvien.xlsx";
        private FileInfo GetFileExcel()
        {
            return new FileInfo(filePath);
        }

        // Lấy tất cả các sinh viên (GetAll)
        public List<SinhVien> GetAll()
        {
            var ds_sv = new List<SinhVien>();

            // Thiết lập LicenseContext
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            var file_excel = GetFileExcel();

            using (var package = new ExcelPackage(file_excel))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Lấy về sheet đầu tiên
                var rowCount = worksheet.Dimension.Rows; // Đếm số dòng trong excel (có dữ liệu
                var colCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++) // Mỗi một dong trong danh là một sinh viên
                {
                    // Ex Row Data: 0 |   1   |    2       | 3  | ....
                    // Ex Row Data: 1 | 11234 | Nguyễn Văn | An | ....
                    SinhVien sv = new SinhVien();
                    sv.Tt = Int32.Parse(worksheet.Cells[row, 1].Text);
                    sv.Cccd = worksheet.Cells[row, 2].Text;
                    sv.Hodem = worksheet.Cells[row, 3].Text;
                    sv.Ten = worksheet.Cells[row, 4].Text;
                    sv.Nickname = worksheet.Cells[row, 5].Text;
                    sv.Email = worksheet.Cells[row, 6].Text;
                    sv.Dienthoai = worksheet.Cells[row, 7].Text;
                    sv.Diem_tichluy = Double.Parse(worksheet.Cells[row, 8].Text);
                    sv.Diem_renluyen = Double.Parse(worksheet.Cells[row, 9].Text);

                    ds_sv.Add(sv);
                }
            }

            return ds_sv;
        }

        // Lấy thông chi tiết của một sinh viên (GetByID)
        public SinhVien GetByID(int id)
        {
            var file_excel = GetFileExcel();
            SinhVien sv = null;

            using (var package = new ExcelPackage(file_excel))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    if (Int32.Parse(worksheet.Cells[row, 1].Text) == id) // Kiểm tra ID
                    {
                        sv = new SinhVien
                        {
                            Tt = id,
                            Cccd = worksheet.Cells[row, 2].Text,
                            Hodem = worksheet.Cells[row, 3].Text,
                            Ten = worksheet.Cells[row, 4].Text,
                            Nickname = worksheet.Cells[row, 5].Text,
                            Email = worksheet.Cells[row, 6].Text,
                            Dienthoai = worksheet.Cells[row, 7].Text,
                            Diem_tichluy = Double.Parse(worksheet.Cells[row, 8].Text),
                            Diem_renluyen = Double.Parse(worksheet.Cells[row, 9].Text)
                        };
                        break; // Dừng vòng lặp khi tìm thấy sinh viên
                    }
                }
            }

            return sv; // Trả về sinh viên hoặc null nếu không tìm thấy
        }

        // Thêm (Add)
        public void Add(SinhVien sv)
        {
            var file_excel = GetFileExcel(); // Sử dụng phương thức để lấy FileInfo

            using (var package = new ExcelPackage(file_excel))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                // Thêm sinh viên mới vào hàng tiếp theo
                worksheet.Cells[rowCount + 1, 1].Value = sv.Tt;
                worksheet.Cells[rowCount + 1, 2].Value = sv.Cccd;
                worksheet.Cells[rowCount + 1, 3].Value = sv.Hodem;
                worksheet.Cells[rowCount + 1, 4].Value = sv.Ten;
                worksheet.Cells[rowCount + 1, 5].Value = sv.Nickname;
                worksheet.Cells[rowCount + 1, 6].Value = sv.Email;
                worksheet.Cells[rowCount + 1, 7].Value = sv.Dienthoai;
                worksheet.Cells[rowCount + 1, 8].Value = sv.Diem_tichluy;
                worksheet.Cells[rowCount + 1, 9].Value = sv.Diem_renluyen;

                package.Save(); // Lưu thay đổi vào tệp
            }
        }

        // Cập nhật (UpdateByID)
        public void Update(SinhVien sv)
        {
            var file_excel = GetFileExcel(); // Sử dụng phương thức để lấy FileInfo

            using (var package = new ExcelPackage(file_excel))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    if (Int32.Parse(worksheet.Cells[row, 1].Text) == sv.Tt) // Kiểm tra ID
                    {
                        // Cập nhật thông tin sinh viên
                        worksheet.Cells[row, 2].Value = sv.Cccd;
                        worksheet.Cells[row, 3].Value = sv.Hodem;
                        worksheet.Cells[row, 4].Value = sv.Ten;
                        worksheet.Cells[row, 5].Value = sv.Nickname;
                        worksheet.Cells[row, 6].Value = sv.Email;
                        worksheet.Cells[row, 7].Value = sv.Dienthoai;
                        worksheet.Cells[row, 8].Value = sv.Diem_tichluy;
                        worksheet.Cells[row, 9].Value = sv.Diem_renluyen;

                        break; // Dừng vòng lặp khi đã cập nhật
                    }
                }

                package.Save(); // Lưu thay đổi vào tệp
            }
        }

        // Xóa tất cả (DeleteAll)
        public void DeleteAll()
        {
            var file_excel = GetFileExcel(); // Sử dụng phương thức để lấy FileInfo

            using (var package = new ExcelPackage(file_excel))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                // Xóa tất cả hàng từ hàng 2 trở đi
                for (int row = 2; row <= rowCount; row++)
                {
                    worksheet.DeleteRow(2); // Luôn xóa hàng thứ 2 cho đến khi không còn hàng
                }

                package.Save(); // Lưu thay đổi vào tệp
            }
        }

        // Xóa một sinh viên (DeleteByID)
        public void DeleteByID(int id)
        {
            var file_excel = GetFileExcel(); // Sử dụng phương thức để lấy FileInfo

            using (var package = new ExcelPackage(file_excel))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    if (Int32.Parse(worksheet.Cells[row, 1].Text) == id) // Kiểm tra ID
                    {
                        worksheet.DeleteRow(row); // Xóa hàng sinh viên
                        break; // Dừng vòng lặp khi đã xóa
                    }
                }

                package.Save(); // Lưu thay đổi vào tệp
            }
        }

    }
}
