using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class TacGia
    {
        [Key]
        public int MaTacGia { get; set; }
        public string TenTacGia { get; set; }

        //public virtual ICollection<TaiLieu> TaiLieus { get; set; }
    }
}