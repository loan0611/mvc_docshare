using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class BinhLuan
    {
        [Key]
        public   int MaBinhLuan { get; set; }
        public int MaThanhVien { get; set; }

        public int MaTaiLieu { get; set; }
        public string NDBinhLuan { get; set; }
        public DateTime NgayBL { get; set; }
        //public virtual ICollection<Reply> Replies { get; set; }
        //public virtual ThanhVien ThanhVien { get; set; }
        //public virtual TaiLieu TaiLieu { get; set; }

    }
}