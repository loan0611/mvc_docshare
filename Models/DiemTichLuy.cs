using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class DiemTichLuy
    {
        [Key]
        public int MaThanhVien { get; set; }
        public int Diem { get; set; }

        //public virtual ThanhVien ThanhVien { get; set; }
    }
}