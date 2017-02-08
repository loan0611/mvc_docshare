using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class TaiLieu
    {
        [Key]
        public int MaTaiLieu { get; set; }
        public int MaChuyenDe { get; set; }
        public int MaTuKhoa { get; set; }
        public int MaNgonNgu { get; set; }
        public int MaThanhVienUpload { get; set; }
        public int MaThanhVienDuyet { get; set; }
        public int MaRating { get; set; }
        public string NhanDe { get; set; }
        public int SoTrang { get; set; }
        public DateTime NgayUpload { get; set; }
        public int KichThuoc { get; set; }
        public int LuotXem { get; set; }
        public string LinkFile { get; set; }
        public int SoLanDownload { get; set; }
        public string GhiChu { get; set; }
        public decimal Phi { get; set; }
        public string TinhTrang { get; set; }

        public virtual ChuyenDe ChuyenDe { get; set; }
        public virtual NgonNgu NgonNgu { get; set; }
        public virtual TacGia TacGia { get; set; }
        public virtual Rating Rating { get; set; }


        public virtual ICollection<LichSuDownload> LichSuDownloads { get; set; }

        public virtual ICollection<DanhSachTaiLieuYeuTich> DanhSachTaiLieuYeuThichs { get; set; }

        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

    }
}