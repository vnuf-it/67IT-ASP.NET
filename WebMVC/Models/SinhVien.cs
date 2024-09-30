using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class SinhVien
    {
        // tt	cccd	hodem	ten	nickname	email	dienthoai	diem_tichluy	diem_renluyen	xet_hocbong
        int tt;
        string cccd;
        string hodem;
        string ten;
        string nickname;
        string email;
        string dienthoai;
        double diem_tichluy;
        double diem_renluyen;
        bool xet_hocbong;

        [Key]
        public int Tt { get => tt; set => tt = value; }
        [Required]
        public string Cccd { get => cccd; set => cccd = value; }
        [Required]
        public string Hodem { get => hodem; set => hodem = value; }
        [Required]
        public string Ten { get => ten; set => ten = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Email { get => email; set => email = value; }
        public string Dienthoai { get => dienthoai; set => dienthoai = value; }
        [Range(0,4)]
        public double Diem_tichluy { get => diem_tichluy; set => diem_tichluy = value; }
        [Range(0, 10)]
        public double Diem_renluyen { get => diem_renluyen; set => diem_renluyen = value; }
        public bool Xet_hocbong { get => xet_hocbong; set => xet_hocbong = value; }
    }
}
