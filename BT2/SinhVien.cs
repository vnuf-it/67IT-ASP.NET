using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2
{
    internal class SinhVien:NguoiDung
    {
        // Fields
        string lop;
        string khoavien;
        Double diem_tichluy;
        Double diem_renluyen;


        // Properties
        public string Lop { get => lop; set => lop = value; }
        public string Khoavien { get => khoavien; set => khoavien = value; }
        public double Diem_tichluy { get => diem_tichluy; set => diem_tichluy = value; }
        public double Diem_renluyen { get => diem_renluyen; set => diem_renluyen = value; }


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

        public SinhVien(string hodem, string ten, string lop, string khoavien, double diem_tl, double diem_rl) : base(hodem, ten)
        {
            Hodem = hodem;
            Ten = ten;
            Lop = lop;
            Khoavien = khoavien;
            Diem_tichluy = diem_tl;
            Diem_renluyen = diem_rl;
        }

        //public static SinhVien NhapThongTin()
        //{
        //    Console.WriteLine("NHAP THONG TIN:");
        //    Console.WriteLine("Ho dem:\t");
        //    var hodem = Console.ReadLine();
        //    Console.WriteLine("Ten:\t");
        //    var ten = Console.ReadLine();
        //    Console.WriteLine("CCCD:\t");
        //    var cccd = Console.ReadLine();
        //    Console.WriteLine("Tuoi:\t");
        //    var tuoi = Int32.Parse(Console.ReadLine()); // Chuyển đổi dữ liệu kiểu string sang kiểu int

        //    SinhVien sv_tmp = new SinhVien(cccd, hodem, ten, tuoi);
        //    return sv_tmp;
        //}

        public static SinhVien NhapThongTin()
        {
            Console.WriteLine("NHAP THONG TIN:");
            Console.WriteLine("Ho dem:\t");
            var hodem = Console.ReadLine();
            Console.WriteLine("Ten:\t");
            var ten = Console.ReadLine();
            Console.WriteLine("Lop:\t");
            var lop = Console.ReadLine();
            Console.WriteLine("Khoa/Vien:\t");
            var khoavien = Console.ReadLine();

            Console.WriteLine("Diem tich luy:\t");
            var dtl = Double.Parse(Console.ReadLine());
            Console.WriteLine("Diem ren luyen:\t");
            var drl = Double.Parse(Console.ReadLine());

            SinhVien sv_tmp = new SinhVien(hodem, ten, lop, khoavien, dtl, drl);
            return sv_tmp;
        }

        public override void InThongTin()
        {
            var str_in =
                $"\nHo va ten: {Hodem} {Ten}" +
                $"\nLop: {Lop}" +
                $"\nKhoa/Vien: {Khoavien}" +
                $"\nDiem tich luy: {Diem_tichluy}" +
                $"\nDiem ren luyen: {Diem_renluyen}";

            Console.WriteLine(str_in);
        }
    }
}
