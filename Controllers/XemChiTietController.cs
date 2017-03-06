using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class XemChiTietController : Controller
    {
        ApplicationDbContext DBContext;
        public XemChiTietController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: XemChiTiet
        public ActionResult Index()
        {   
            return View();
        }
        public ActionResult Detail(int? maTaiLieu)
        {
            var tailieus = new List<TaiLieu>();
            if (maTaiLieu != null)
                tailieus = DBContext.TaiLieus.Where(x => x.MaTaiLieu == maTaiLieu).ToList();
            else
                tailieus = DBContext.TaiLieus.ToList();
            return View();
        }
    }
}