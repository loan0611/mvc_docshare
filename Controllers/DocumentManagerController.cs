using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class DocumentManagerController : Controller
    {
        ApplicationDbContext DBContext;
        public DocumentManagerController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: DocumentManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(TaiLieu model)
        {
            model.NgayUpload = DateTime.Now;
            DBContext.TaiLieus.Add(model);
            DBContext.SaveChanges();
            return View();
        }
    }
}