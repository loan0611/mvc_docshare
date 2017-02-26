using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class TuKhoaController : Controller
    {
        ApplicationDbContext DBContext;

        public TuKhoaController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: TuKhoa
        public ActionResult Index()
        {
            var tukhoas = DBContext.TuKhoas.ToList();

            return View(tukhoas);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TuKhoa model)
        {
            try
            {

                DBContext.TuKhoas.Add(model);
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