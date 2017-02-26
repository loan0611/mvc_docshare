using DocShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class RatingController : Controller
    {
        ApplicationDbContext DBContext;

        public RatingController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: Rating
        public ActionResult Index()
        {
            var ratings = DBContext.Ratings.ToList();

            return View(ratings);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Rating model)
        {
            try
            {

                DBContext.Ratings.Add(model);
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