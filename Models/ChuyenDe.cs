using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace DocShare.Models
{
    [TableName("ChuyenDes")]
    public class ChuyenDe
    {
        [Key]
        public int MaChuyenDe { get; set; }
        public string TenChuyenDe { get; set; }

        //public virtual ICollection<TaiLieu> TaiLieus { get; set; }
    }
}