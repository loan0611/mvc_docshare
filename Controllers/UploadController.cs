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
        ApplicationDbContext DBContext;
        public UploadController()
        {
            DBContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var chuyendes = new List<ChuyenDe>()
            {
                //DBContext.ChuyenDes.Where(x => x.TenChuyenDe == )
                new ChuyenDe() { MaChuyenDe = 1, TenChuyenDe = "Chuyen de 1" },
                new ChuyenDe() { MaChuyenDe = 2, TenChuyenDe = "Chuyen de 2" },
                new ChuyenDe() { MaChuyenDe = 3, TenChuyenDe = "Chuyen de 3" },
                new ChuyenDe() { MaChuyenDe = 4, TenChuyenDe = "Chuyen de 4" }
            };

            ViewBag.ChuyenDe = new SelectList(chuyendes, "MaChuyenDe", "TenChuyenDe", chuyendes[1].MaChuyenDe);
            return View();
            
            //try
            //{
            //    tl.NgayUpload = DateTime.Now;

            //    DBContext.TaiLieus.Add(tl);
            //    //DBContext.TuKhoas.Add(tk);
            //    DBContext.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //catch (Exception ex)
            //{

            //    return null;
            //}           
        }
    }
}