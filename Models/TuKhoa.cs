using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class TuKhoa
    {
        [Key]
        public int MaTuKhoa { get; set; }
        public string TenTuKhoa { get; set; }

        public virtual ICollection<TuKhoaTaiLieu> TuKhoaTaiLieus { get; set; }
    }
}