using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReapersTest3.Models;
using System.IO;

namespace ReapersTest3.Controllers
{
    public class ImageGalleriesController : Controller
    {
        private DbConnectionContext db = new DbConnectionContext();

        // GET: ImageGalleries
        public ActionResult Index()
        {
            var imagesModel = new ImageGallery();
            var imageFiles = Directory.GetFiles(Server.MapPath("~/Images/"));
            foreach (var item in imageFiles)
            {
                imagesModel.ImageList.Add(Path.GetFileName(item));
            }

            //imagesModel.Name = "Test1";
            //imagesModel.ImagePath = "http://www.reaperswargaming.co.uk/images/themenight.jpg";
            //imagesModel.ImageList.Add("http://www.reaperswargaming.co.uk/images/MondayNights.jpg");
            //imagesModel.ID = new Guid();

            //List<ImageGallery> list = new List<ImageGallery>(){ imagesModel };
            return View(imagesModel);
        }
        
        [HttpGet]
        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImageMethod()
        {
            if (Request.Files.Count != 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];
                    int fileSize = file.ContentLength;
                    string fileName = file.FileName;
                    file.SaveAs(Server.MapPath("~/Images/" + fileName));
                    ImageGallery imageGallery = new ImageGallery();
                    imageGallery.ID = Guid.NewGuid();
                    imageGallery.Name = fileName;
                    imageGallery.ImagePath = "~/Images/" + fileName;
                    db.ImageGallery.Add(imageGallery);
                    db.SaveChanges();
                }
                return Content("Success");
            }
            return Content("failed");
        }

        // GET: ImageGalleries/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageGallery imageGallery = db.ImageGallery.Find(id);
            if (imageGallery == null)
            {
                return HttpNotFound();
            }
            return View(imageGallery);
        }

        // GET: ImageGalleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageGalleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ImagePath")] ImageGallery imageGallery)
        {
            if (ModelState.IsValid)
            {
                imageGallery.ID = Guid.NewGuid();
                db.ImageGallery.Add(imageGallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imageGallery);
        }

        // GET: ImageGalleries/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageGallery imageGallery = db.ImageGallery.Find(id);
            if (imageGallery == null)
            {
                return HttpNotFound();
            }
            return View(imageGallery);
        }

        // POST: ImageGalleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ImagePath")] ImageGallery imageGallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageGallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imageGallery);
        }

        // GET: ImageGalleries/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageGallery imageGallery = db.ImageGallery.Find(id);
            if (imageGallery == null)
            {
                return HttpNotFound();
            }
            return View(imageGallery);
        }

        // POST: ImageGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ImageGallery imageGallery = db.ImageGallery.Find(id);
            db.ImageGallery.Remove(imageGallery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
