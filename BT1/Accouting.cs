using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class Accouting
    {
        //Fields
        string code;       // Mã ngân hàng
        string account;    // Mã tài khoản
        double balance;    // Số dư tài khoản

        //Properties
        public string Code { get => this.code; set => this.code = value; }
        public string Account
        {
            get { return this.account; }
            set { this.account = value; }
        }
        public double Balance { get => balance; set => balance = value; }

        //Methods
        public Accouting()
        {
            Code = "Ex: VCB, TCB, MBB, VTB...";
            Account = " MA TAI KHOAN";
            Balance = 0;
        }

        public Accouting(string code, string account, double balance)
        {
            Code = code;
            Account = account;
            Balance = balance;

            //this.code = code;
            //this.account = account;
            //this.balance = balance;
        }

        public void ShowTK()
        {
            Console.WriteLine($"Thong tin tai khoan NH:" +
                $"\n Ma ngan hang: {Code}" +
                $"\n So tai khoan:{Account}" +
                $"\n So du tai khoan: {Balance}");
        }

        // Cach 1: Gui/Rut Tien
        public double GuiTien(double tien_gui)
        {
            // Trả về số dư tài khoản
            Balance = Balance + tien_gui;
            return Balance;
        }

        public double RutTien(double tien_rut)
        {
            // Trả về số dư tài khoản
            Balance = Balance - tien_rut;
            return Balance;
        }

        // Cach 2: Gui/Rut Tien
        /// <summary>
        /// Gui/Rut Tien
        /// </summary>
        /// <param name="x">true: gui tien | false: rut tien</param>
        /// <param name="so_tien">so tien gui / rut</param>
        public void GuiRutTien(bool x, double so_tien)
        {
            //x = true => GuiTien
            //x = false => RutTien
            if (x = true)
                Balance += so_tien;
            else
                Balance -= so_tien;
        }

        public double SoDuKhaDung()
        {
            Balance = Balance - 50000;
            return Balance;
        }
    }
}
