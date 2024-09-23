using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BT2
{
    internal abstract class NguoiDung
    {
        string cccd;
        string hodem;
        string ten;
        string nickname;
        string email;
        string phone;
        int tuoi;

        public string Cccd { get => cccd; set => cccd = value; }
        public string Hodem { get => hodem; set => hodem = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Email
        {
            get => email;
            set
            {
                //// Way 1:
                //Regex validateEmailRegex = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
                //var check = validateEmailRegex.IsMatch(value);
                //if (check) 
                //    email = value;
                //else
                //    Console.WriteLine("Nhap email khong chinh xac. Vui long nhap lai !!");

                // Way 2:
                if (Regex.IsMatch(value, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
                    email = value;
                else
                    Console.WriteLine("Nhap email khong chinh xac. Vui long nhap lai !!");

            }
        }
        public string Phone { get => phone; set => phone = value; }

        public int Tuoi
        {
            get => tuoi;
            set
            {
                if (value > 0)
                    tuoi = value;
                else
                    Console.WriteLine("Nhap tuoi khong chinh xac. Vui long nhap lai !!");
            }
        }

        /// <summary>
        /// Ham khoi tao Nguoi dung
        /// </summary>
        public NguoiDung()
        {
            Cccd = "Ex: 0010234456";
            Hodem = "Ex: Nguyen Van";
            Ten = "Ex: An";
            Nickname = "Ex: annv";
            Email = "Ex: annv@vnuf.edu.vn";
            Phone = "Ex: 0979 123 456";
            Tuoi = 0;
        }

        public NguoiDung(string hodem, string ten)
        {
            Hodem = hodem;
            Ten = ten;
        }

        public NguoiDung(string cccd, string hodem, string ten, int tuoi)
        {
            Cccd = cccd;
            Hodem = hodem;
            Ten = ten;
            Tuoi = tuoi;
        }

        public NguoiDung(string cccd, string hodem, string ten, string nickname, string email, string phone, int tuoi)
        {
            Cccd = cccd;
            Hodem = hodem;
            Ten = ten;
            Nickname = nickname;
            Email = email;
            Phone = phone;
            Tuoi = tuoi;
        }

        /// <summary>
        /// Phuong thuc ao (virtual) InThongTin
        /// </summary>
        public virtual void InThongTin()
        {
            var str_in =
                $"\nHo va ten: {Hodem} {Ten}" +
                $"\nSo CCCD: {Cccd}" +
                $"\nNick name: {Nickname}";

            Console.WriteLine(str_in);
        }
    }
}
