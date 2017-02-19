using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            var chuyendes = new List<ChuyenDe>()
            {
                new ChuyenDe() { MaChuyenDe = 1, TenChuyenDe = "Chuyen de 1" },
                new ChuyenDe() { MaChuyenDe = 2, TenChuyenDe = "Chuyen de 2" },
                new ChuyenDe() { MaChuyenDe = 3, TenChuyenDe = "Chuyen de 3" },
                new ChuyenDe() { MaChuyenDe = 4, TenChuyenDe = "Chuyen de 4" }
            };
            ViewBag.ChuyenDe = new SelectList(chuyendes, "MaChuyenDe", "TenChuyenDe", chuyendes[2].MaChuyenDe);
            return View();
        }
    }
}