using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class DanhSachTaiLieuYeuTich
    {
        [Key]
        public int MaThanhVien { get; set; }
        public int MaTaiLieu { get; set; }

        //public virtual ThanhVien ThanhVien { get; set; }
        //public virtual TaiLieu TaiLieu { get; set; }
    }
}