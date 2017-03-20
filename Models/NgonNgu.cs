using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class NgonNgu
    {
        [Key]
        public int MaNgonNgu { get; set; }
        public string TenNgonNgu { get; set; }

        public virtual ICollection<TaiLieu> TaiLieus { get; set; }

    }
}