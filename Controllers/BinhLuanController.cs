using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class BinhLuanController : Controller
    {
        ApplicationDbContext DBContext;

        public BinhLuanController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: BinhLuan
        public ActionResult Index()
        {
            var binhluans = DBContext.BinhLuans.ToList();

            return View(binhluans);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BinhLuan model)
        {
            try
            {
                model.NgayBL = DateTime.Now;
                DBContext.BinhLuans.Add(model);
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