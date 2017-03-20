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
        public ActionResult Index(int? page, int? pageSize, string searchString)
        {
            int limit = 4;
            if (pageSize != null)
            {
                limit = pageSize.Value;
            }
            int pagenumber = (page ?? 1);
            ViewBag.SearchString = searchString;
            ViewBag.PageSize = limit;
            var query = DBContext.TaiLieus as IQueryable<TaiLieu>;

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.NhanDe.Contains(searchString));
            }

            return View(DBContext.TaiLieus.Where(x => x.PheDuyet).OrderBy(x => x.NgayUpload).ToPagedList(pagenumber,limit));

        }
        

        public ActionResult Manager()
        {
            return View();

        }
        public ActionResult MenuLeft()
        {
            var chuyende = DBContext.ChuyenDes.ToList();
            return PartialView(chuyende);
        }
    }
}