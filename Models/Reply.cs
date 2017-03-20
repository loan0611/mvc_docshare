using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class Reply
    {
        [Key]
        //public int MaReply { get; set; }
        
        public int MaThanhVien { get; set; }
        
        public int MaBinhLuan { get; set; }
        public string NDReply { get; set; }
        public DateTime NgayReply { get; set; }
        public virtual BinhLuan BinhLuan { get; set; }
        public virtual ThanhVien ThanhVien { get; set; }
    }
}