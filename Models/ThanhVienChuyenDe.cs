using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class ThanhVienChuyenDe
    {
        [Key]
        public int MaThanhVien { get; set; }

        public int MaChuyenDe { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
        public virtual ChuyenDe ChuyenDe { get; set; }
    }
}