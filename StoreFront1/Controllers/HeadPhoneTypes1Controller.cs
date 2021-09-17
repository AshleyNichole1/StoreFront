using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.Data.EF;

namespace StoreFront1.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class HeadPhoneTypes1Controller : Controller
    {
        private StoreFrontEntities1 db = new StoreFrontEntities1();

        // GET: HeadPhoneTypes1
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.HeadPhoneTypes.ToList());
        }

        // GET: HeadPhoneTypes1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadPhoneType headPhoneType = db.HeadPhoneTypes.Find(id);
            if (headPhoneType == null)
            {
                return HttpNotFound();
            }
            return View(headPhoneType);
        }

        // GET: HeadPhoneTypes1/Create
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeadPhoneTypes1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HeadPhoneType1,HPT_ID")] HeadPhoneType headPhoneType)
        {
            if (ModelState.IsValid)
            {
                db.HeadPhoneTypes.Add(headPhoneType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(headPhoneType);
        }

        // GET: HeadPhoneTypes1/Edit/5
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadPhoneType headPhoneType = db.HeadPhoneTypes.Find(id);
            if (headPhoneType == null)
            {
                return HttpNotFound();
            }
            return View(headPhoneType);
        }

        // POST: HeadPhoneTypes1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HeadPhoneType1,HPT_ID")] HeadPhoneType headPhoneType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(headPhoneType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(headPhoneType);
        }

        // GET: HeadPhoneTypes1/Delete/5
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadPhoneType headPhoneType = db.HeadPhoneTypes.Find(id);
            if (headPhoneType == null)
            {
                return HttpNotFound();
            }
            return View(headPhoneType);
        }

        // POST: HeadPhoneTypes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeadPhoneType headPhoneType = db.HeadPhoneTypes.Find(id);
            db.HeadPhoneTypes.Remove(headPhoneType);
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
