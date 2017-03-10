using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class ThanhVienController : Controller
    {
        ApplicationDbContext DBContext;

        public ThanhVienController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: ThanhVien
        public ActionResult Index()
        {
            var thanhviens = DBContext.ThanhViens.ToList();
            return View(thanhviens);
        }

        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ThanhVien model)
        {
            try
            {
                model.NgayDangKy = DateTime.Now;
                DBContext.ThanhViens.Add(model);
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