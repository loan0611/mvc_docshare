using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class TacGiaController : Controller
    {
        
        ApplicationDbContext DBContext;
        public TacGiaController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: TacGia
        public ActionResult Index()
        {
            var tacgias = DBContext.TacGias.ToList();

            return View(tacgias);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TacGia model)
        {
            try
            {

                DBContext.TacGias.Add(model);
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