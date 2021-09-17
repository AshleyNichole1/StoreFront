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
    public class AccessoriesController : Controller
    {
        private StoreFrontEntities1 db = new StoreFrontEntities1();

        // GET: Accessories
        [AllowAnonymous]
        public ActionResult Index()
        {
            var accessories = db.Accessories.Include(a => a.AccessoryType1).Include(a => a.Color).Include(a => a.Shipper);
            return View(accessories.ToList());
        }

        // GET: Accessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // GET: Accessories/Create
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Create()
        {
            ViewBag.AccessoryType = new SelectList(db.AccessoryTypes, "AccessoryType1", "AccessoryName");
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade");
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName");
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessoryID,AccessoryType,AccessoryPrice,AccessoriesSold,ColorID,AccessoryDesrcp,ShipperID,AccessoryImage,AccessorySales,StockID")] Accessory accessory, HttpPostedFileBase accessories)
        {
            if (ModelState.IsValid)
            {

                #region File Upload w/ Utility
                string file = "NoImage.png";

                if (accessories != null)
                {
                    file = accessories.FileName;

                    string ext = file.Substring(file.LastIndexOf("."));

                    string[] goodExts = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (goodExts.Contains(ext))
                    {
                        file = Guid.NewGuid() + ext;

                        #region Resize Image
                        //params for the Image Utility
                        //what we need: filepath, image file, maximum image size (full size), maximum thumb size (thumbnail)

                        //file path
                        string savePath = Server.MapPath("~/Content/img/");

                        //image file
                        Image convertedImage = Image.FromStream(accessories.InputStream);

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

                    accessory.AccessoryImage = file;

                }
                #endregion



                db.Accessories.Add(accessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoryType = new SelectList(db.AccessoryTypes, "AccessoryType1", "AccessoryName", accessory.AccessoryType);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade", accessory.ColorID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", accessory.ShipperID);
            return View(accessory);
        }

        // GET: Accessories/Edit/5
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoryType = new SelectList(db.AccessoryTypes, "AccessoryType1", "AccessoryName", accessory.AccessoryType);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade", accessory.ColorID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", accessory.ShipperID);
            return View(accessory);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessoryID,AccessoryType,AccessoryPrice,AccessoriesSold,ColorID,AccessoryDesrcp,ShipperID,AccessoryImage,AccessorySales,StockID")] Accessory accessory, HttpPostedFileBase accessories)
        {
            if (ModelState.IsValid)
            {

                #region File Upload with Utility
                //check to see if a new file has been uploaded. If not, the HiddenFor() from the View will maintain 
                //the original value

                string file = "";

                if (accessories != null)
                {
                    //retrieve the name of the file so we can check it's extension
                    file = accessories.FileName;

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
                        string savePath = Server.MapPath("~/Content/img/");

                        Image convertedImage = Image.FromStream(accessories.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 100;

                        //Call the Image Service method to resize our image
                        //ResizeImage() will save 2 resized copies of our original image -- 1 full size, 1 thumbnail size
                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                        #endregion

                        #region Delete the old Image
                        if (accessory.AccessoryImage != null && accessory.AccessoryImage != "NoImage.png")
                        {
                            string path = Server.MapPath("~/Content/imgstore/books/");
                            ImageUtility.Delete(path, accessory.AccessoryImage);
                        }
                        #endregion

                        //Assign our new filename to the book.BookImage we are currently editing
                        accessory.AccessoryImage = file;

                    }

                }
                #endregion



                db.Entry(accessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoryType = new SelectList(db.AccessoryTypes, "AccessoryType1", "AccessoryName", accessory.AccessoryType);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade", accessory.ColorID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", accessory.ShipperID);
            return View(accessory);
        }

        // GET: Accessories/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessory accessory = db.Accessories.Find(id);


            string path = Server.MapPath("~/Content/img/");
            ImageUtility.Delete(path, accessory.AccessoryImage);


            db.Accessories.Remove(accessory);
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
