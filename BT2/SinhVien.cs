using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2
{
    internal class SinhVien:NguoiDung
    {
        // Bien thanh vien (Truong thong tin)


        // Thuoc tinh

        /// <summary>
        /// Hàm khởi tạo SinhVien được base (kế thừa) từ hàm khởi tạo NguoiDung
        /// </summary>
        /// <param name="cccd"></param>
        /// <param name="hodem"></param>
        /// <param name="ten"></param>
        /// <param name="tuoi"></param>
        public SinhVien(string cccd, string hodem, string ten, int tuoi): base(cccd, hodem, ten, tuoi)
        {
            Cccd = cccd;
            Hodem = hodem;
            Ten = ten;
            Tuoi = tuoi;
        }

        public static SinhVien NhapThongTin()
        {
            Console.WriteLine("NHAP THONG TIN:");
            Console.WriteLine("\nHo dem:");
            var hodem = Console.ReadLine();
            Console.WriteLine("\nTen:");
            var ten = Console.ReadLine();
            Console.WriteLine("\nCCCD:");
            var cccd = Console.ReadLine();
            Console.WriteLine("\nTuoi:");
            var tuoi = Int32.Parse(Console.ReadLine()); // Chuyển đổi dữ liệu kiểu string sang kiểu int

            SinhVien sv_tmp = new SinhVien(cccd, hodem, ten, tuoi);
            return sv_tmp;
        }
    }
}
