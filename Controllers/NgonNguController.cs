using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class NgonNguController : Controller
    {
        ApplicationDbContext DBContext;
        public NgonNguController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: NgonNgu
        public ActionResult Index()
        {
            var ngonngus = DBContext.NgonNgus.ToList();

            return View(ngonngus);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NgonNgu model)
        {
            try
            {

                DBContext.NgonNgus.Add(model);
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