using DocShare.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DocShare.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDbContext DBContext;
        public LoginController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ClientLogin(ThanhVien user)
        {
            {
                var cl = DBContext.ThanhViens.Single(c => c.TenTruyCap == user.TenTruyCap && c.MatKhau == user.MatKhau);

                if (cl != null)
                {
                    Session["MaThanhVien"] = cl.MaThanhVien.ToString();
                    Session["TenTruyCap"] = cl.TenTruyCap.ToString();
                    Session["Client_Name"] = cl.HoTen.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong");
                }
            }
            return View();
        }
    }  
}