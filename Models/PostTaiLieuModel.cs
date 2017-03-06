using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocShare.Models
{
    public class PostTaiLieuModel
    {
        public int MaChuyenDe { get; set; }

        public int MaNgonNgu { get; set; }
        
        public string NhanDe { get; set; }
        public string GhiChu { get; set; }
        public int SoTrang { get; set; }
        public decimal Phi { get; set; }

        public string TuKhoa { get; set; }

    }
}