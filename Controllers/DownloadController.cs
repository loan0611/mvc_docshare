using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocShare.Controllers
{
    public class DownloadController : Controller
    {
        // GET: Download
        public ActionResult Index()
        {
            var dl = new System.IO.DirectoryInfo(Server.MapPath("~/Content/Documents"));
            System.IO.FileInfo[] fileNames = dl.GetFiles("*.*");
            List<string> items = new List<string>();
            foreach(var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }

        public FileResult Download(int id , string FileName)
        {
            return File("~/Content/Documents/" + FileName, System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
        }
    }
}