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
    public class AccessoryTypesController : Controller
    {
        private StoreFrontEntities1 db = new StoreFrontEntities1();

        // GET: AccessoryTypes
        public ActionResult Index()
        {
            return View(db.AccessoryTypes.ToList());
        }

        // GET: AccessoryTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoryType accessoryType = db.AccessoryTypes.Find(id);
            if (accessoryType == null)
            {
                return HttpNotFound();
            }
            return View(accessoryType);
        }

        // GET: AccessoryTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccessoryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessoryType1,AccsID,AccessoryName")] AccessoryType accessoryType)
        {
            if (ModelState.IsValid)
            {
                db.AccessoryTypes.Add(accessoryType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessoryType);
        }

        // GET: AccessoryTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoryType accessoryType = db.AccessoryTypes.Find(id);
            if (accessoryType == null)
            {
                return HttpNotFound();
            }
            return View(accessoryType);
        }

        // POST: AccessoryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessoryType1,AccsID,AccessoryName")] AccessoryType accessoryType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessoryType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessoryType);
        }

        // GET: AccessoryTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessoryType accessoryType = db.AccessoryTypes.Find(id);
            if (accessoryType == null)
            {
                return HttpNotFound();
            }
            return View(accessoryType);
        }

        // POST: AccessoryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccessoryType accessoryType = db.AccessoryTypes.Find(id);
            db.AccessoryTypes.Remove(accessoryType);
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
