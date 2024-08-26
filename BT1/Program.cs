// See https://aka.ms/new-console-template for more information
using BT1;

Accouting vcb = new Accouting();
vcb.Code = "VCB";
vcb.Account = "9979123456";
vcb.Balance = 1000000;

vcb.ShowTK();
Console.WriteLine("\n");


Accouting vietinbank = new Accouting("VTB", "23454666767", 50000000);
vietinbank.ShowTK();

Console.WriteLine("Gui tien VCB:");

vcb.GuiTien(Double.Parse(Console.ReadLine()));
vcb.ShowTK();

People hoatx = new People();
hoatx.AddTaiKhoan(vcb);
hoatx.AddTaiKhoan(vietinbank);

Console.WriteLine($"\n Tong tien: {hoatx.TongSoDu()}");

