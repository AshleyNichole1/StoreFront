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
    [Authorize]
    public class Employees1Controller : Controller
    {
        private StoreFrontEntities1 db = new StoreFrontEntities1();

        // GET: Employees1
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Position);
            return View(employees.ToList());
        }

        // GET: Employees1/Details/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees1/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "Position1");
            return View();
        }

        // POST: Employees1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,PositionID,FirstName,LastName,HireDate,BIrthdate,Phone_,Email,Emp_Street,Adress2,Emp_City,Emp_state,Emp_zip")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "Position1", employee.PositionID);
            return View(employee);
        }

        // GET: Employees1/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "Position1", employee.PositionID);
            return View(employee);
        }

        // POST: Employees1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,PositionID,FirstName,LastName,HireDate,BIrthdate,Phone_,Email,Emp_Street,Adress2,Emp_City,Emp_state,Emp_zip")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "Position1", employee.PositionID);
            return View(employee);
        }

        // GET: Employees1/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
