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
    public class humiditiesController : Controller
    {
        private IoTDBEntities db = new IoTDBEntities();

        // GET: humidities
        public ActionResult Index()
        {
            return View(db.humidities.ToList());
        }

        // GET: humidities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            humidities humidities = db.humidities.Find(id);
            if (humidities == null)
            {
                return HttpNotFound();
            }
            return View(humidities);
        }

        // GET: humidities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: humidities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Humidity,sender,time,type,value")] humidities humidities)
        {
            if (ModelState.IsValid)
            {
                db.humidities.Add(humidities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(humidities);
        }

        // GET: humidities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            humidities humidities = db.humidities.Find(id);
            if (humidities == null)
            {
                return HttpNotFound();
            }
            return View(humidities);
        }

        // POST: humidities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Humidity,sender,time,type,value")] humidities humidities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(humidities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(humidities);
        }

        // GET: humidities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            humidities humidities = db.humidities.Find(id);
            if (humidities == null)
            {
                return HttpNotFound();
            }
            return View(humidities);
        }

        // POST: humidities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            humidities humidities = db.humidities.Find(id);
            db.humidities.Remove(humidities);
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
