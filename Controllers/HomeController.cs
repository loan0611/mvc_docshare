using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                int pagesize = 2;
                int pagenumber = (page ?? 1);
              
                return View(DBContext.TaiLieus.OrderBy(x => x.Anh).ToPagedList(pagenumber, pagesize));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}