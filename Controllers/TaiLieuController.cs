using DocShare.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;
using System.Data.Entity;

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

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiLieu tlieu = DBContext.TaiLieus.Find(id);
            if(tlieu == null)
            {
                return HttpNotFound();
            }

            var taiLieuEditModel = new TaiLieuViewModel()
            {
                MaTaiLieu = tlieu.MaTaiLieu,
                NhanDe = tlieu.NhanDe,
                MaChuyenDe = tlieu.MaChuyenDe,
                MaNgonNgu = tlieu.MaNgonNgu,
                SoTrang = tlieu.SoTrang,
                Phi = tlieu.Phi,
                GhiChu = tlieu.GhiChu,
                Anh = tlieu.Anh,
                LinkFile = tlieu.LinkFile

            };

            var cd = (from cde in DBContext.ChuyenDes select cde).ToList();
            ViewBag.MaChuyenDe = new SelectList(cd, "MaChuyenDe", "TenChuyenDe", tlieu.MaChuyenDe);
            var nn = (from nngu in DBContext.NgonNgus select nngu).ToList();
            ViewBag.MaNgonNgu = new SelectList(nn, "MaNgonNgu", "TenNgonNgu", tlieu.MaNgonNgu);
            return View(taiLieuEditModel);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(TaiLieuViewModel tl, HttpPostedFileBase file, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                return View(tl);              
            }

            var pathImage = string.Empty;
            if (image != null)
            {
                pathImage = Path.Combine("/Content/Images", image.FileName);
                image.SaveAs(Server.MapPath(pathImage));
            }

            var pathFile = string.Empty;
            var fileSize = 0;
            if (file != null)
            {
                fileSize = file.ContentLength;
                pathFile = Path.Combine("/Content/Documents", file.FileName);
                file.SaveAs(Server.MapPath(pathFile));
            }

            var tailieu = DBContext.TaiLieus.SingleOrDefault(x=>x.MaTaiLieu == tl.MaTaiLieu);

            tailieu.NhanDe = tl.NhanDe;
            tailieu.SoTrang = tl.SoTrang;
            tailieu.Phi = tl.Phi;
            tailieu.MaChuyenDe = tl.MaChuyenDe;
            tailieu.MaNgonNgu = tl.MaNgonNgu;
            tailieu.GhiChu = tl.GhiChu;
            tailieu.Anh = !string.IsNullOrEmpty(pathImage) ? pathImage : tl.Anh;
            tailieu.LinkFile = !string.IsNullOrEmpty(pathFile) ? pathFile : tl.LinkFile;

            DBContext.TaiLieus.Attach(tailieu);
            DBContext.Entry(tailieu).State = EntityState.Modified;
            DBContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Submit()
        {
            var cd = (from cde in DBContext.ChuyenDes select cde).ToList();
                       
            ViewBag.MaChuyenDe = new SelectList(cd, "MaChuyenDe", "TenChuyenDe");

            ViewBag.MaNgonNgu = new SelectList(DBContext.NgonNgus, "MaNgonNgu", "TenNgonNgu");
            return View();
        }

        [HttpPost]
        public ActionResult Submit(TaiLieuViewModel model, HttpPostedFileBase file, HttpPostedFileBase image)
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
                    pathImage = Path.Combine("/Content/Images", image.FileName);
                    image.SaveAs(Server.MapPath(pathImage));
                }

                var pathFile = string.Empty;
                var fileSize = 0;
                if (file != null)
                {
                    fileSize = file.ContentLength;
                    pathFile = Path.Combine("/Content/Documents", file.FileName);
                    file.SaveAs(Server.MapPath(pathFile));
                }

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
                    NhanDe = model.NhanDe,
                    LinkFile = pathFile,
                    Anh = pathImage,
                    Phi = model.Phi,
                    SoTrang = model.SoTrang,
                    MaNgonNgu = model.MaNgonNgu,
                    NgayUpload = DateTime.Now,
                    MaChuyenDe = model.MaChuyenDe,
                    KichThuoc = fileSize,
                    GhiChu = model.GhiChu
                };

                DBContext.TaiLieus.Add(tailieu);
                DBContext.SaveChanges();

                foreach (var item in tukhoas_saved)
                {
                    var tukhoa_tailieu = new TuKhoaTaiLieu()
                    {
                        MaTaiLieu = tailieu.MaTaiLieu,
                        MaTuKhoa = item.MaTuKhoa
                    };

                    DBContext.TuKhoaTaiLieus.Add(tukhoa_tailieu);
                    DBContext.SaveChanges();
                }
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