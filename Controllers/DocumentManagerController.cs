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
    public class DocumentManagerController : Controller
    {
        ApplicationDbContext DBContext;
        public DocumentManagerController()
        {
            DBContext = new ApplicationDbContext();
        }
        // GET: DocumentManager
        //public IEnumerable<TaiLieu> List(int page, int pagesize)
        //{
        //    return DBContext.TaiLieus.OrderBy(x => x.NgayUpload).ToPagedList(page,pagesize);
        //}
        public ActionResult Index(/*int? maChuyenDe,*/ int? page)
        {
            try
            {
                //var tailieus = new List<TaiLieu>();
                int pagesize = 10;
                int pagenumber = (page ?? 1);
                //tailieus.ToPagedList(page, pagesize);
                //if (maChuyenDe != null)
                //{
                //    tailieus = DBContext.TaiLieus.Where(x => x.MaChuyenDe == maChuyenDe).ToList();
                //}
                //else
                //{
                //    tailieus = DBContext.TaiLieus.ToList();
                //}
                return View(DBContext.TaiLieus.OrderBy(x => x.SoTrang).ToPagedList(pagenumber, pagesize));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
      
        public ActionResult Submit()
        {
            var chuyendes = new List<ChuyenDe>()
            {
                new ChuyenDe() { MaChuyenDe = 1, TenChuyenDe = "Kỹ Thuật" },
                new ChuyenDe() { MaChuyenDe = 2, TenChuyenDe = "Văn Hóa" },
                new ChuyenDe() { MaChuyenDe = 3, TenChuyenDe = "Xã Hội" },
                new ChuyenDe() { MaChuyenDe = 4, TenChuyenDe = "Kinh Tế" }
            };
            ViewBag.ChuyenDe = new SelectList(chuyendes, "MaChuyenDe", "TenChuyenDe", chuyendes[1].MaChuyenDe);

            var ngonngus = new List<NgonNgu>()
            {
                new NgonNgu() {MaNgonNgu=1, TenNgonNgu="Tiếng Việt" },
                new NgonNgu() {MaNgonNgu=2, TenNgonNgu="Tiếng Anh" },
            };
            ViewBag.NgonNgu = new SelectList(ngonngus, "MaNgonNgu", "TenNgonNgu", ngonngus[1].MaNgonNgu);


            return View();
        }

        [HttpPost]
        public ActionResult Submit(TaiLieu model)
        {
            try
            {
                model.NgayUpload = DateTime.Now;

                DBContext.TaiLieus.Add(model);
                DBContext.SaveChanges();
                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        //protected void UploadFile(object sender, EventArgs e)
        //{
        //    string folderPath = Server.MapPath("~/Files/");

        //    //Check whether Directory (Folder) exists.
        //    if (!Directory.Exists(folderPath))
        //    {
        //        //If Directory (Folder) does not exists. Create it.
        //        Directory.CreateDirectory(folderPath);
        //    }

        //    //Save the File to the Directory (Folder).
        //    FileUpload.SaveAs(folderPath + Path.GetFileName(FileUpload.FileName));

        //    //Display the success message.
        //    lblMessage.Text = Path.GetFileName(FileUpload.FileName) + " has been uploaded.";
        //}
    }
}