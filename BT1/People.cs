using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class People
    {
        string cccd;
        string hodem;
        string ten;
        string nickname;
        string email;
        string dienthoai;
        int tuoi;
        List<Accouting> dstaikhoan = new List<Accouting>();

        public string Cccd { get => cccd; set => cccd = value; }
        public string Hodem { get => hodem; set => hodem = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Email { get => email; set => email = value; }
        public string Dienthoai { get => dienthoai; set => dienthoai = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }

        public void AddTaiKhoan(Accouting tk)
        {
            dstaikhoan.Add(tk);
        }

        // Cach 1:
        //public Double TongSoDu()
        //{
        //    return dstaikhoan.Sum(obj => obj.Balance);
        //}

        // 
        public Double TongSoDu()
        {
            Double total = 0;
            foreach (var tk in dstaikhoan)
            {
                if (tk.Balance == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    total += tk.Balance;
                }
            }
            //Console.WriteLine($"\n Tong So Du (cac tai khoan): {total}");
            return total;
        }

        // Cach 3:
        public void TongSoDu(params Double[] args)
        {
            Double total = 0;
            foreach (var so_du in args)
            {
                if (so_du == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    total += so_du;
                }
            }
            Console.WriteLine($"\n Tong So Du (cac tai khoan): {total}");
        }

    }
}
