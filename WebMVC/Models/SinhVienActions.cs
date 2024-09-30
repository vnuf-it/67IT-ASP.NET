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
        //const string file_excel = @"C:\Users\hoatx\Source\Repos\67IT-ASP.NET\WebMVC\Datas\ds_sinhvien.xlsx";

        // Lấy tất cả các sinh viên (GetAll)
        public List<SinhVien> GetAll()
        {
            var ds_sv = new List<SinhVien>();

            // Thiết lập LicenseContext
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;


            var filePath = @"C:\Users\hoatx\Source\Repos\67IT-ASP.NET\WebMVC\Datas\ds_sinhvien.xlsx";
            var file_excel = new FileInfo(filePath);

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


        // Thêm (Add)


        // Cập nhật (UpdateByID)


        // Xóa tất cả (DeleteAll)


        // Xóa một sinh viên (DeleteByID)

    }
}
