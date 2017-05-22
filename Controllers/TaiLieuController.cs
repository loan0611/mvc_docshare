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

        //public ActionResult Edit(int? id)
        //{
        //    if(id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TaiLieu tlieu = DBContext.TaiLieus.Find(id);
        //    if(tlieu == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var taiLieuEditModel = new TaiLieuViewModel()
        //    {
        //        MaTaiLieu = tlieu.MaTaiLieu,
        //        NhanDe = tlieu.NhanDe,
        //        MaTacGia = tlieu.MaTacGia,
        //        MaChuyenDe = tlieu.MaChuyenDe,
        //        MaNgonNgu = tlieu.MaNgonNgu,
        //        SoTrang = tlieu.SoTrang,
        //        Phi = tlieu.Phi,
        //        GhiChu = tlieu.GhiChu,
        //        Anh = tlieu.Anh,
        //        LinkFile = tlieu.LinkFile

        //    };
        //    var tg = (from tgia in DBContext.TacGias select tgia).ToList();
        //    ViewBag.MaTacGia = new SelectList(tg, "MaTacGia", "TenTacGia", tlieu.MaTacGia);
        //    var cd = (from cde in DBContext.ChuyenDes select cde).ToList();
        //    ViewBag.MaChuyenDe = new SelectList(cd, "MaChuyenDe", "TenChuyenDe", tlieu.MaChuyenDe);
        //    var nn = (from nngu in DBContext.NgonNgus select nngu).ToList();
        //    ViewBag.MaNgonNgu = new SelectList(nn, "MaNgonNgu", "TenNgonNgu", tlieu.MaNgonNgu);
        //    return View(taiLieuEditModel);
        //}
        //[ValidateInput(false)]
        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Edit(TaiLieuViewModel tl, HttpPostedFileBase file, HttpPostedFileBase image)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(tl);              
        //    }

        //    var pathImage = string.Empty;
        //    if (image != null)
        //    {
        //        pathImage = Path.Combine("/Content/Images", image.FileName);
        //        image.SaveAs(Server.MapPath(pathImage));
        //    }

        //    var pathFile = string.Empty;
        //    var fileSize = 0;
        //    if (file != null)
        //    {
        //        fileSize = file.ContentLength;
        //        pathFile = Path.Combine("/Content/Documents", file.FileName);
        //        file.SaveAs(Server.MapPath(pathFile));
        //    }

        //    var tailieu = DBContext.TaiLieus.SingleOrDefault(x=>x.MaTaiLieu == tl.MaTaiLieu);

        //    tailieu.NhanDe = tl.NhanDe;
        //    tailieu.SoTrang = tl.SoTrang;
        //    tailieu.Phi = tl.Phi;
        //    tailieu.MaTacGia = tl.MaTacGia;
        //    tailieu.MaChuyenDe = tl.MaChuyenDe;
        //    tailieu.MaNgonNgu = tl.MaNgonNgu;
        //    tailieu.GhiChu = tl.GhiChu;
        //    tailieu.Anh = !string.IsNullOrEmpty(pathImage) ? pathImage : tl.Anh;
        //    tailieu.LinkFile = !string.IsNullOrEmpty(pathFile) ? pathFile : tl.LinkFile;

        //    DBContext.TaiLieus.Attach(tailieu);
        //    DBContext.Entry(tailieu).State = EntityState.Modified;
        //    DBContext.SaveChanges();

        //    return RedirectToAction("Index");
        //}
        //public ActionResult Submit()
        //{
        //    var cd = (from cde in DBContext.ChuyenDes select cde).ToList();
        //    ViewBag.MaChuyenDe = new SelectList(cd, "MaChuyenDe", "TenChuyenDe");
        //    var nn = (from nngu in DBContext.NgonNgus select nngu).ToList();
        //    ViewBag.MaNgonNgu = new SelectList(nn, "MaNgonNgu", "TenNgonNgu");
        //    var tg = (from tgia in DBContext.TacGias select tgia).ToList();
        //    ViewBag.MaTacGia = new SelectList(tg, "MaTacGia", "TenTacGia");
        //    return View();
        //}

        public ActionResult Listing()
        {
            return View();
        }

        

    }
}