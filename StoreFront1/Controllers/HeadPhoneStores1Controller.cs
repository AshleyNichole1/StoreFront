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
    //[Authorize]
    public class HeadPhoneStores1Controller : Controller
    {
        private StoreFrontEntities1 db = new StoreFrontEntities1();

        // GET: HeadPhoneStores1
        [AllowAnonymous]
        public ActionResult Index()
        {
            var headPhoneStores = db.HeadPhoneStores.Include(h => h.Charger).Include(h => h.Color).Include(h => h.HeadPhoneType1).Include(h => h.Shipper).Include(h => h.Stock);
            return View(headPhoneStores.ToList());
        }

        //#region Originally Scaffolded
        //// GET: HeadPhoneStores1/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HeadPhoneStore headPhoneStore = db.HeadPhoneStores.Find(id);
        //    if (headPhoneStore == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(headPhoneStore);
        //}

        //// GET: HeadPhoneStores1/Create
        //[Authorize(Roles = "Admin,Employee")]
        //public ActionResult Create()
        //{
        //    ViewBag.ChargerID = new SelectList(db.Chargers, "ChargerID", "Charge_type");
        //    ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade");
        //    ViewBag.HeadPhoneType = new SelectList(db.HeadPhoneTypes, "HeadPhoneType1", "HPT_ID");
        //    ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName");
        //    ViewBag.StockID = new SelectList(db.Stocks, "StockID", "StockValue");
        //    return View();
        //}

        //// POST: HeadPhoneStores1/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "HeadPhoneID,HeadPhoneType,HeadPhonePrice,isWireless,UnitsSold,isInOver,ColorID,Description,isMic,ChargerID,ShipperID,isBlueTooth,Weight,Sales,StockID,Image")] HeadPhoneStore headPhoneStore, HttpPostedFileBase headPhones)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        #region File Upload w/ Utility
        //        string file = "NoImage.png";

        //        if (headPhones != null)
        //        {
        //            file = headPhones.FileName;

        //            string ext = file.Substring(file.LastIndexOf("."));

        //            string[] goodExts = { ".jpg", ".jpeg", ".png", ".gif" };

        //            if (goodExts.Contains(ext))
        //            {
        //                file = Guid.NewGuid() + ext;

        //                #region Resize Image
        //                //params for the Image Utility
        //                //what we need: filepath, image file, maximum image size (full size), maximum thumb size (thumbnail)

        //                //file path
        //                string savePath = Server.MapPath("~/Content/imgstore/books/");

        //                //image file
        //                Image convertedImage = Image.FromStream(headPhones.InputStream);

        //                //max img size
        //                int maxImageSize = 500;//value in pixels

        //                //max thumb size
        //                int maxThumbSize = 100;

        //                //Call the ImageUtility to do work
        //                ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
        //                #endregion
        //            }

        //            //update book object with new filename 
        //            //this is what is saved to the DB
        //            headPhoneStore.Image = file;

        //        }
        //        #endregion




        //        db.HeadPhoneStores.Add(headPhoneStore);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ChargerID = new SelectList(db.Chargers, "ChargerID", "Charge_type", headPhoneStore.ChargerID);
        //    ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade", headPhoneStore.ColorID);
        //    ViewBag.HeadPhoneType = new SelectList(db.HeadPhoneTypes, "HeadPhoneType1", "HPT_ID", headPhoneStore.HeadPhoneType);
        //    ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", headPhoneStore.ShipperID);
        //    ViewBag.StockID = new SelectList(db.Stocks, "StockID", "StockValue", headPhoneStore.StockID);
        //    return View(headPhoneStore);
        //}

        //// GET: HeadPhoneStores1/Edit/5
        //[Authorize(Roles = "Admin,Employee")]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HeadPhoneStore headPhoneStore = db.HeadPhoneStores.Find(id);
        //    if (headPhoneStore == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ChargerID = new SelectList(db.Chargers, "ChargerID", "Charge_type", headPhoneStore.ChargerID);
        //    ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade", headPhoneStore.ColorID);
        //    ViewBag.HeadPhoneType = new SelectList(db.HeadPhoneTypes, "HeadPhoneType1", "HPT_ID", headPhoneStore.HeadPhoneType);
        //    ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", headPhoneStore.ShipperID);
        //    ViewBag.StockID = new SelectList(db.Stocks, "StockID", "StockValue", headPhoneStore.StockID);
        //    return View(headPhoneStore);
        //}

        //// POST: HeadPhoneStores1/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "HeadPhoneID,HeadPhoneType,HeadPhonePrice,isWireless,UnitsSold,isInOver,ColorID,Description,isMic,ChargerID,ShipperID,isBlueTooth,Weight,Sales,StockID,Image")] HeadPhoneStore headPhoneStore, HttpPostedFileBase headPhones)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        #region File Upload with Utility
        //        //check to see if a new file has been uploaded. If not, the HiddenFor() from the View will maintain 
        //        //the original value

        //        string file = "";

        //        if (headPhones != null)
        //        {
        //            //retrieve the name of the file so we can check it's extension
        //            file = headPhones.FileName;

        //            //retrieve the extension 
        //            //----REVIEW---
        //            //file= myImage.png
        //            //      012345678910 -- the period is 7
        //            //file.LastIndexOf("."); -> 7
        //            //file.Substring(7);
        //            //substring will start at the value of 7 because it is the (".") and will give you back everything after that-- in this case .png


        //            string ext = file.Substring(file.LastIndexOf("."));

        //            string[] goodExts = { ".jpg", ".jpeg", ".png", ".gif" };

        //            if (goodExts.Contains(ext))
        //            {
        //                //create a new file name (using a GUID si it will be unique)
        //                file = Guid.NewGuid() + ext;

        //                #region Resize Image
        //                //params for the ResizeImage() 
        //                string savePath = Server.MapPath("~/Content/img/");

        //                Image convertedImage = Image.FromStream(headPhones.InputStream);

        //                int maxImageSize = 500;

        //                int maxThumbSize = 100;

        //                //Call the Image Service method to resize our image
        //                //ResizeImage() will save 2 resized copies of our original image -- 1 full size, 1 thumbnail size
        //                ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
        //                #endregion

        //                #region Delete the old Image
        //                if (headPhoneStore.Image != null && headPhoneStore.Image != "NoImage.png")
        //                {
        //                    string path = Server.MapPath("~/Content/img/");
        //                    ImageUtility.Delete(path, headPhoneStore.Image);
        //                }
        //                #endregion

        //                //Assign our new filename to the book.BookImage we are currently editing
        //                headPhoneStore.Image = file;

        //            }

        //        }
        //        #endregion





        //        db.Entry(headPhoneStore).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ChargerID = new SelectList(db.Chargers, "ChargerID", "Charge_type", headPhoneStore.ChargerID);
        //    ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade", headPhoneStore.ColorID);
        //    ViewBag.HeadPhoneType = new SelectList(db.HeadPhoneTypes, "HeadPhoneType1", "HPT_ID", headPhoneStore.HeadPhoneType);
        //    ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", headPhoneStore.ShipperID);
        //    ViewBag.StockID = new SelectList(db.Stocks, "StockID", "StockValue", headPhoneStore.StockID);
        //    return View(headPhoneStore);
        //}

        //// GET: HeadPhoneStores1/Delete/5
        //[Authorize(Roles = "Admin")]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HeadPhoneStore headPhoneStore = db.HeadPhoneStores.Find(id);
        //    if (headPhoneStore == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(headPhoneStore);
        //}

        //// POST: HeadPhoneStores1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    HeadPhoneStore headPhoneStore = db.HeadPhoneStores.Find(id);


        //    string path = Server.MapPath("~/Content/img/");
        //    ImageUtility.Delete(path, headPhoneStore.Image);



        //    db.HeadPhoneStores.Remove(headPhoneStore);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        //#endregion


        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize]
        public JsonResult AjaxDelete(int id)
        {
            HeadPhoneStore headPhone = db.HeadPhoneStores.Find(id);

            db.HeadPhoneStores.Remove(headPhone);
            db.SaveChanges();

            string confirmMessage = $"Deleted Headphone {headPhone.HeadPhoneType} from the database!";
            return Json(new { id = id, message = confirmMessage });
        }

        [HttpGet]
        [AllowAnonymous]
        public PartialViewResult HeadPhoneDetails(int id)
        {
            HeadPhoneStore headPhone = db.HeadPhoneStores.Find(id);
            return PartialView(headPhone);

        }


        [HttpGet]
        [Authorize]
        public ActionResult HeadPhoneCreate()
        {
            ViewBag.ChargerID = new SelectList(db.Chargers, "ChargerID", "Charge_type");
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade");
            ViewBag.HeadPhoneType = new SelectList(db.HeadPhoneTypes, "HeadPhoneType1", "HPT_ID");
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName");
            ViewBag.StockID = new SelectList(db.Stocks, "StockID", "StockValue");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public JsonResult AjaxCreate(HeadPhoneStore headPhone, HttpPostedFileBase headPhoneImage)
        {
            if (ModelState.IsValid)
            {
                #region File Upload
                string file = "noimage.png";

                if (headPhoneImage != null)
                {
                    file = headPhoneImage.FileName;

                    string ext = file.Substring(file.LastIndexOf("."));

                    string[] goodExts = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (goodExts.Contains(ext))
                    {
                        file = Guid.NewGuid() + ext;
                        headPhoneImage.SaveAs(Server.MapPath("~/Content/img/") + file);
                    }
                    
                }
                #endregion

                headPhone.Image = file;

                db.HeadPhoneStores.Add(headPhone);
                db.SaveChanges();
                return Json(headPhone);
            }

            ViewBag.ChargerID = new SelectList(db.Chargers, "ChargerID", "Charge_type");
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade");
            ViewBag.HeadPhoneType = new SelectList(db.HeadPhoneTypes, "HeadPhoneType1", "HPT_ID");
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName");
            ViewBag.StockID = new SelectList(db.Stocks, "StockID", "StockValue");

            return Json(headPhone);


        }

        //Edit

        [HttpGet]
        [Authorize]
        public PartialViewResult HeadPhoneEdit(int id)
        {
            HeadPhoneStore headphone = db.HeadPhoneStores.Find(id);


            ViewBag.ChargerID = new SelectList(db.Chargers, "ChargerID", "Charge_type", headphone.ChargerID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade", headphone.ColorID);
            ViewBag.HeadPhoneType = new SelectList(db.HeadPhoneTypes, "HeadPhoneType1", "HPT_ID", headphone.HeadPhoneType);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", headphone.ShipperID);
            ViewBag.StockID = new SelectList(db.Stocks, "StockID", "StockValue", headphone.StockID);


            return PartialView(headphone);

        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public JsonResult AjaxEdit(HeadPhoneStore headphone, HttpPostedFileBase headPhoneImage)
        {


            if (ModelState.IsValid)
            {
                #region File Upload
                string file = "noimage.png";

                if (headPhoneImage != null)
                {
                    file = headPhoneImage.FileName;

                    string ext = file.Substring(file.LastIndexOf("."));

                    string[] goodExts = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (goodExts.Contains(ext))
                    {
                        file = Guid.NewGuid() + ext;
                        headPhoneImage.SaveAs(Server.MapPath("~/Content/img/") + file);
                    }

                }
                #endregion

                headphone.Image = file;

                db.HeadPhoneStores.Add(headphone);
                db.SaveChanges();
                return Json(headphone);
            }


            //HeadPhoneStore originalHeadphone = db.HeadPhoneStores.Find(headphone.HeadPhoneID);
            //originalHeadphone.ColorID = headphone.ColorID;
            //originalHeadphone.Description = headphone.Description;
            //originalHeadphone.HeadPhonePrice = headphone.HeadPhonePrice;
            //originalHeadphone.Image = headphone.Image;

            //db.Entry(originalHeadphone).State = EntityState.Modified;
            //db.SaveChanges();
            //return Json(originalHeadphone);


            ViewBag.ChargerID = new SelectList(db.Chargers, "ChargerID", "Charge_type", headphone.ChargerID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Shade", headphone.ColorID);
            ViewBag.HeadPhoneType = new SelectList(db.HeadPhoneTypes, "HeadPhoneType1", "HPT_ID", headphone.HeadPhoneType);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "ShipperName", headphone.ShipperID);
            ViewBag.StockID = new SelectList(db.Stocks, "StockID", "StockValue", headphone.StockID);


            return Json(headphone);



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
