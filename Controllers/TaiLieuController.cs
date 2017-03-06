using DocShare.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace DocShare.Controllers
{
    public class TaiLieuController : Controller
    {
        ApplicationDbContext DBContext;
        public TaiLieuController()
        {
            DBContext = new ApplicationDbContext();
        }

        //[HttpPost]
        public ActionResult Index(int? page, int? pageSize, string searchString)
        {
            int limit = 4;
            if (pageSize != null)
            {
                limit = pageSize.Value;
            }
            int pagenumber = (page ?? 1);
            ViewBag.SearchString = searchString;
            ViewBag.PageSize = limit;
            var query = DBContext.TaiLieus as IQueryable<TaiLieu>;

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.NhanDe.Contains(searchString));
            }

            return View(query.OrderBy(n => n.NgayUpload).ToPagedList(pagenumber, limit));

        }

        public ActionResult Detail(int id)
        {
            var tailieu = DBContext.TaiLieus.FirstOrDefault(x => x.MaTaiLieu == id);
            return View(tailieu);
        }

        public ActionResult Submit()
        {
            var cd = (from cde in DBContext.ChuyenDes select cde).ToList();
                       
            ViewBag.ChuyenDe = new SelectList(cd, "MaChuyenDe", "TenChuyenDe");

            ViewBag.NgonNgu = new SelectList(DBContext.NgonNgus, "MaNgonNgu", "TenNgonNgu");
            return View();
        }

        [HttpPost]
        public ActionResult Submit(PostTaiLieuModel model, HttpPostedFileBase file, HttpPostedFileBase image)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }


                var pathImageDirectory = Server.MapPath(@"~/Content/Images");
                var pathFileDirectory = Server.MapPath(@"~/Content/Documents");
                if (!System.IO.Directory.Exists(pathImageDirectory))
                {
                    System.IO.Directory.CreateDirectory(pathImageDirectory);
                }

                if (!System.IO.Directory.Exists(pathFileDirectory))
                {
                    System.IO.Directory.CreateDirectory(pathFileDirectory);
                }
                var pathImage = string.Empty;
                if (image != null)
                {
                    pathImage = Path.Combine(pathImageDirectory,image.FileName);
                    image.SaveAs(pathImage);
                }

                var pathFile = string.Empty;
                if (file != null)
                {
                    pathFile = Path.Combine(pathFileDirectory, file.FileName);
                    file.SaveAs(pathFile);
                }
                var nhande = string.Empty;
                
                List<TuKhoa> tukhoas_saved = new List<TuKhoa>();

                if (!string.IsNullOrEmpty(model.TuKhoa))
                {
                    var tukhoas = model.TuKhoa.Split(';');
                    foreach (string tukhoa in tukhoas)
                    {
                        var tkentity = new TuKhoa()
                        {
                            TenTuKhoa = tukhoa.Trim()
                        };
                        tukhoas_saved.Add(tkentity);
                    }

                    DBContext.TuKhoas.AddRange(tukhoas_saved);
                    DBContext.SaveChanges();
                }

                TaiLieu tailieu = new TaiLieu()
                {
                    LinkFile = pathFile,
                    Anh = pathImage
                };
                DBContext.TaiLieus.Add(tailieu);
                DBContext.SaveChanges();
               
                return RedirectToAction("Index");
                    
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }

    }
}