using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class ThanhVien
    {
        [Key]
        public int MaThanhVien { get; set; }
        public string TenTruyCap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public string Email { get; set; }
        public DateTime NgayDangKy { get; set; }
        public int MaQH { get; set; }

        public virtual ICollection<LichSuDownload> LichSuDownloads { get; set; }

        public virtual ICollection<DanhSachTaiLieuYeuTich> DanhSachTaiLieuYeuThichs { get; set; }

        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<ThanhVienChuyenDe> ThanhVienChuyenDes { get; set; }
        public virtual ICollection<DiemTichLuy> DiemTichLuys { get; set; }
    }
}