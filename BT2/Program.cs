// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using BT2;

//SinhVien sv1 = new SinhVien("123", "Tran Van", "Nam", 25);
//sv1.InThongTin();
//Console.ReadKey();


var sv1 = SinhVien.NhapThongTin();
Console.ReadKey();
sv1.InThongTin();
