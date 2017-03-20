using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class TuKhoaTaiLieu
    {
        [Key]
        public int MaTuKhoa { get; set; }
        public int MaTaiLieu { get; set; }

        public virtual TuKhoa TuKhoa { get; set; }
        public virtual TaiLieu TaiLieu { get; set; }
    }
}