using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class ChuyenDeController : Controller
    {
        ApplicationDbContext DBContext;
        public ChuyenDeController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: ChuyenDe
        public ActionResult Index()
        {
            var chuyendes = DBContext.ChuyenDes.ToList();

            return View(chuyendes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ChuyenDe model)
        {
            try
            {

                DBContext.ChuyenDes.Add(model);
                DBContext.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}