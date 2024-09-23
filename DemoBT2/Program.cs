// See https://aka.ms/new-console-template for more information
using DemoBT2;

Console.WriteLine("Hello, World!");


//SinhVien sv1 = new SinhVien();

//sv1.Hodem = "TRAN XUAN";
//sv1.Ten = "HOA";
//Console.WriteLine(sv1.Ten);

SinhVien sv2 = new SinhVien("TRAN DONG", "NHAT MINH", 10);
Console.WriteLine(sv2.Ten);

Console.ReadKey();