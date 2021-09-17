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
    [Authorize(Roles = "Admin, Employee")]
    public class Chargers1Controller : Controller
    {
       
        private StoreFrontEntities1 db = new StoreFrontEntities1();

        // GET: Chargers1
        public ActionResult Index()
        {
            return View(db.Chargers.ToList());
        }

        // GET: Chargers1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charger charger = db.Chargers.Find(id);
            if (charger == null)
            {
                return HttpNotFound();
            }
            return View(charger);
        }

        // GET: Chargers1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chargers1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChargerID,Charge_type")] Charger charger)
        {
            if (ModelState.IsValid)
            {
                db.Chargers.Add(charger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(charger);
        }

        // GET: Chargers1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charger charger = db.Chargers.Find(id);
            if (charger == null)
            {
                return HttpNotFound();
            }
            return View(charger);
        }

        // POST: Chargers1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChargerID,Charge_type")] Charger charger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(charger);
        }

        // GET: Chargers1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charger charger = db.Chargers.Find(id);
            if (charger == null)
            {
                return HttpNotFound();
            }
            return View(charger);
        }

        // POST: Chargers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Charger charger = db.Chargers.Find(id);
            db.Chargers.Remove(charger);
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
