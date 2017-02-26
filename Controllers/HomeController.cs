using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using PagedList;
namespace DocShare.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext DBContext;
        public HomeController()
        {
            DBContext = new ApplicationDbContext();
        }
        public ActionResult Index(int? page)
        {
            try
            {
                //var tailieus = new List<TaiLieu>();
                int pagesize = 10;
                int pagenumber = (page ?? 1);
                //tailieus.ToPagedList(page, pagesize);
                //if (maChuyenDe != null)
                //{
                //    tailieus = DBContext.TaiLieus.Where(x => x.MaChuyenDe == maChuyenDe).ToList();
                //}
                //else
                //{
                //    tailieus = DBContext.TaiLieus.ToList();
                //}
                return View(DBContext.TaiLieus.OrderBy(x => x.Anh).ToPagedList(pagenumber, pagesize));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}