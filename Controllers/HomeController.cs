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
        public ActionResult Search(int? page, int? pageSize, string searchString)
        {
            int limit = 20;
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

            return View(query.Where(x => x.PheDuyet).OrderBy(n => n.MaTaiLieu).Take(2).ToPagedList(pagenumber, limit));

        }

        public ActionResult Index()
        {
            var model = new HomeViewModel();
            model.TaiLieuMoi = DBContext.TaiLieus.Where(x => x.PheDuyet).OrderBy(x => x.NgayUpload).Take(50).ToList();
            model.TaiLieuNoiBat = DBContext.TaiLieus.Where(x => x.PheDuyet).OrderBy(x => x.NgayUpload).Take(6).ToList();
            return View(model);


        }
        public ActionResult MenuLeft()
        {
            var chuyende = DBContext.ChuyenDes.ToList();
            return PartialView(chuyende);
        }
    }
}