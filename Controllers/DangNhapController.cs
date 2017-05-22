using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class DangNhapController : Controller
    {
        ApplicationDbContext DBContext;
        public DangNhapController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult vd()
        {
            return View();
        }
        public ActionResult vidu()
        {
            return View();
        }
    }
}