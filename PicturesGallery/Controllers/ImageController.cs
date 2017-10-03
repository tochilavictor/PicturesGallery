using PicturesGallery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PicturesGallery.Controllers
{
    public class ImageController : Controller
    {
        private readonly int pagesize = 4;
        public ActionResult Index(int page = 1)
        {
            DirectoryInfo d = new DirectoryInfo(Server.MapPath("~/Content/Images/"));
            FileInfo[] Files = d.GetFiles("*.jpg");
            IEnumerable<GalleryViewModel> names = Files.OrderBy(x => x.CreationTime)
                .Skip((page - 1) * pagesize).Take(pagesize)
                .Select(x => new GalleryViewModel
                {
                    Filename = x.Name
                });
            return View(names);
        }
        //public ActionResult DisplayAvatar(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest); ;
        //    }
        //    string file_path = Server.MapPath("~/Content/Images/" + id +".jpg");
        //    return File(file_path, "image/jpeg");
        //}
    }
}