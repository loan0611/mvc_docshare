using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class Rating
    {
        [Key]
        public int MaRating { get; set; }
        public int SL1Sao { get; set; }
        public int SL2Sao { get; set; }
        public int SL3Sao { get; set; }
        public int SL4Sao { get; set; }
        public int SL5Sao { get; set; }
        public int TBSao { get; set; }

        //public virtual ICollection<TaiLieu> TaiLieus { get; set; }
    }
}