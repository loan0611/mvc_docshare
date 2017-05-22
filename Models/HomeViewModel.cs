using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class HomeViewModel
    {
        public List<TaiLieu> TaiLieuNoiBat { get; set; }

        public List<TaiLieu> TaiLieuMoi { get; set; }
    }
}