using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAzureRaspberry.Models;

namespace MVCAzureRaspberry.Controllers
{
    public class measurementsController : Controller
    {
        private IoTDBEntities db = new IoTDBEntities();

        // GET: measurements
        public ActionResult Index()
        {
            return View(db.measurements.ToList());
        }

        // GET: measurements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            measurements measurements = db.measurements.Find(id);
            if (measurements == null)
            {
                return HttpNotFound();
            }
            return View(measurements);
        }

        // GET: measurements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: measurements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,sender,time,type,value")] measurements measurements)
        {
            if (ModelState.IsValid)
            {
                db.measurements.Add(measurements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(measurements);
        }

        // GET: measurements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            measurements measurements = db.measurements.Find(id);
            if (measurements == null)
            {
                return HttpNotFound();
            }
            return View(measurements);
        }

        // POST: measurements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,sender,time,type,value")] measurements measurements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measurements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(measurements);
        }

        // GET: measurements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            measurements measurements = db.measurements.Find(id);
            if (measurements == null)
            {
                return HttpNotFound();
            }
            return View(measurements);
        }

        // POST: measurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            measurements measurements = db.measurements.Find(id);
            db.measurements.Remove(measurements);
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
