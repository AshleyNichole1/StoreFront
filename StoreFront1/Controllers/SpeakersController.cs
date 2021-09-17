using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.Data.EF;
using StoreFront1.Utilities;

namespace StoreFront1.Controllers
{
    [Authorize]
    public class SpeakersController : Controller
    {
        private StoreFrontEntities1 db = new StoreFrontEntities1();

        // GET: Speakers
        [AllowAnonymous]
        public ActionResult Index()
        {
            var speakers = db.Speakers.Include(s => s.Color).Include(s => s.Shipper).Include(s => s.SpeakersType);
            return View(speakers.ToList());
        }

        // GET: Speakers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speaker speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            return View(speaker);
        }

        // GET: Speakers/Create
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Create()
        {
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade");
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName");
            ViewBag.SpeakerType = new SelectList(db.SpeakersTypes, "SpeakerType", "SpkerName");
            return View();
        }

        // POST: Speakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpeakerID,SpeakerType,SpeakerPrice,SpkrsSold,ColorID,SpkrDescription,ShipperID,SpeakersImage,SpkrSales,StockID")] Speaker speaker, HttpPostedFileBase speakers)
        {
            if (ModelState.IsValid)
            {
                #region File Upload w/ Utility
                string file = "NoImage.png";

                if (speakers != null)
                {
                    file = speakers.FileName;

                    string ext = file.Substring(file.LastIndexOf("."));

                    string[] goodExts = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (goodExts.Contains(ext))
                    {
                        file = Guid.NewGuid() + ext;

                        #region Resize Image
                        //params for the Image Utility
                        //what we need: filepath, image file, maximum image size (full size), maximum thumb size (thumbnail)

                        //file path
                        string savePath = Server.MapPath("~/Content/imgstore/books/");

                        //image file
                        Image convertedImage = Image.FromStream(speakers.InputStream);

                        //max img size
                        int maxImageSize = 500;//value in pixels

                        //max thumb size
                        int maxThumbSize = 100;

                        //Call the ImageUtility to do work
                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                        #endregion
                    }

                    //update book object with new filename 
                    //this is what is saved to the DB
                    speaker.SpeakersImage = file;

                }
                #endregion


                db.Speakers.Add(speaker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade", speaker.ColorID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", speaker.ShipperID);
            ViewBag.SpeakerType = new SelectList(db.SpeakersTypes, "SpeakerType", "SpkerName", speaker.SpeakerType);
            return View(speaker);
        }

        // GET: Speakers/Edit/5
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speaker speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade", speaker.ColorID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", speaker.ShipperID);
            ViewBag.SpeakerType = new SelectList(db.SpeakersTypes, "SpeakerType", "SpkerName", speaker.SpeakerType);
            return View(speaker);
        }

        // POST: Speakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpeakerID,SpeakerType,SpeakerPrice,SpkrsSold,ColorID,SpkrDescription,ShipperID,SpeakersImage,SpkrSales,StockID")] Speaker speaker, HttpPostedFileBase speakers)
        {
            if (ModelState.IsValid)
            {

                #region File Upload with Utility
                //check to see if a new file has been uploaded. If not, the HiddenFor() from the View will maintain 
                //the original value

                string file = "";

                if (speakers != null)
                {
                    //retrieve the name of the file so we can check it's extension
                    file = speakers.FileName;

                    //retrieve the extension 
                    //----REVIEW---
                    //file= myImage.png
                    //      012345678910 -- the period is 7
                    //file.LastIndexOf("."); -> 7
                    //file.Substring(7);
                    //substring will start at the value of 7 because it is the (".") and will give you back everything after that-- in this case .png


                    string ext = file.Substring(file.LastIndexOf("."));

                    string[] goodExts = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (goodExts.Contains(ext))
                    {
                        //create a new file name (using a GUID si it will be unique)
                        file = Guid.NewGuid() + ext;

                        #region Resize Image
                        //params for the ResizeImage() 
                        string savePath = Server.MapPath("~/Content/imgstore/books/");

                        Image convertedImage = Image.FromStream(speakers.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 100;

                        //Call the Image Service method to resize our image
                        //ResizeImage() will save 2 resized copies of our original image -- 1 full size, 1 thumbnail size
                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                        #endregion

                        #region Delete the old Image
                        if (speaker.SpeakersImage != null && speaker.SpeakersImage != "NoImage.png")
                        {
                            string path = Server.MapPath("~/Content/imgstore/books/");
                            ImageUtility.Delete(path, speaker.SpeakersImage);
                        }
                        #endregion

                        //Assign our new filename to the book.BookImage we are currently editing
                        speaker.SpeakersImage = file;

                    }

                }
                #endregion






                db.Entry(speaker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade", speaker.ColorID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", speaker.ShipperID);
            ViewBag.SpeakerType = new SelectList(db.SpeakersTypes, "SpeakerType", "SpkerName", speaker.SpeakerType);
            return View(speaker);
        }

        // GET: Speakers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speaker speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            return View(speaker);
        }

        // POST: Speakers/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Speaker speaker = db.Speakers.Find(id);

            string path = Server.MapPath("~/Content/img/");
            ImageUtility.Delete(path, speaker.SpeakersImage);


            db.Speakers.Remove(speaker);
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
