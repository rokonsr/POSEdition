using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using POS.Models;

namespace POS.Controllers
{
    public class MeasurementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Measurement
        public ActionResult Index()
        {
            var measurements = db.Measurements.Include(m => m.ApplicationUser);
            return View(measurements.ToList());
        }

        // GET: Measurement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return View(measurement);
        }

        // GET: Measurement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Measurement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ModifiedDate", Exclude = "CreatedBy,CreatedAt,UpdatedAt")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                string currentUser = User.Identity.GetUserId();

                measurement.CreatedBy = currentUser;
                measurement.CreatedAt = DateTime.Now;
                measurement.UpdatedAt = DateTime.Now;

                db.Measurements.Add(measurement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(measurement);
        }

        // GET: Measurement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            Session["CreatedBy"] = measurement.CreatedBy;
            Session["CratedAt"] = measurement.CreatedAt;
            return View(measurement);
        }

        // POST: Measurement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ModifiedDate", Exclude = "CreatedBy,CreatedAt,UpdatedAt")] Measurement measurement)
        {
            measurement.CreatedBy = (string)Session["CreatedBy"];
            Session.Remove("CreatedBy");
            measurement.CreatedAt = (DateTime)Session["CratedAt"];
            Session.Remove("CratedAt");
            measurement.UpdatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(measurement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(measurement);
        }

        // GET: Measurement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return View(measurement);
        }

        // POST: Measurement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Measurement measurement = db.Measurements.Find(id);
            db.Measurements.Remove(measurement);
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
