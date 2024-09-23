using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBT2
{
    internal abstract class NguoiDung
    {
        string cccd;
        string hodem;
        string ten;
        string nichkname;
        int tuoi;

        public string Cccd { get => cccd; set => cccd = value; }
        public string Hodem { get => hodem; set => hodem = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Nichkname { get => nichkname; set => nichkname = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }


        public NguoiDung()
        {
            Cccd = "Ex: 1122334455";
            Hodem = "Ex: Nguyen Van";
            Ten = "Ex: Nam";
            Nichkname = "Ex: namnv";
            Tuoi = 0;
        }

        public NguoiDung(string hodem, string ten, int tuoi)
        {
            Hodem = hodem;
            Ten = ten;
            Tuoi = tuoi;
        }
    }
}
