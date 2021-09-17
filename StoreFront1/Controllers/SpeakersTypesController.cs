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
    public class SpeakersTypesController : Controller
    {
        private StoreFrontEntities1 db = new StoreFrontEntities1();

        // GET: SpeakersTypes
        public ActionResult Index()
        {
            return View(db.SpeakersTypes.ToList());
        }

        // GET: SpeakersTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpeakersType speakersType = db.SpeakersTypes.Find(id);
            if (speakersType == null)
            {
                return HttpNotFound();
            }
            return View(speakersType);
        }

        // GET: SpeakersTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpeakersTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpeakerType,SpkrID,SpkerName")] SpeakersType speakersType)
        {
            if (ModelState.IsValid)
            {
                db.SpeakersTypes.Add(speakersType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(speakersType);
        }

        // GET: SpeakersTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpeakersType speakersType = db.SpeakersTypes.Find(id);
            if (speakersType == null)
            {
                return HttpNotFound();
            }
            return View(speakersType);
        }

        // POST: SpeakersTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpeakerType,SpkrID,SpkerName")] SpeakersType speakersType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speakersType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speakersType);
        }

        // GET: SpeakersTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpeakersType speakersType = db.SpeakersTypes.Find(id);
            if (speakersType == null)
            {
                return HttpNotFound();
            }
            return View(speakersType);
        }

        // POST: SpeakersTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpeakersType speakersType = db.SpeakersTypes.Find(id);
            db.SpeakersTypes.Remove(speakersType);
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
