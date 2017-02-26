using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class DiemTichLuyController : Controller
    {

        ApplicationDbContext DBContext;
   
        public DiemTichLuyController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: DiemTichLuy
        public ActionResult Index()
        {
            var diemtichluys = DBContext.DiemTichLuys.ToList();

            return View(diemtichluys);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DiemTichLuy model)
        {
            try
            {

                DBContext.DiemTichLuys.Add(model);
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