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
    public class FinancialYearController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FinancialYear
        public ActionResult Index()
        {
            var financialYears = db.FinancialYears.Include(f => f.ApplicationUser);
            return View(financialYears.ToList());
        }

        // GET: FinancialYear/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinancialYear financialYear = db.FinancialYears.Find(id);
            if (financialYear == null)
            {
                return HttpNotFound();
            }
            return View(financialYear);
        }

        // GET: FinancialYear/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinancialYear/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartingDate,EndingDate,Name", Exclude = "CreatedBy,CreatedAt,UpdatedAt")] FinancialYear financialYear)
        {
            if (ModelState.IsValid)
            {
                string currentUser = User.Identity.GetUserId();

                financialYear.CreatedBy = currentUser;
                financialYear.CreatedAt = DateTime.Now;
                financialYear.UpdatedAt = DateTime.Now;

                db.FinancialYears.Add(financialYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(financialYear);
        }

        // GET: FinancialYear/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinancialYear financialYear = db.FinancialYears.Find(id);
            if (financialYear == null)
            {
                return HttpNotFound();
            }
            Session["CreatedBy"] = financialYear.CreatedBy;
            Session["CratedAt"] = financialYear.CreatedAt;
            return View(financialYear);
        }

        // POST: FinancialYear/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartingDate,EndingDate,Name", Exclude = "CreatedBy,CreatedAt,UpdatedAt")] FinancialYear financialYear)
        {
            financialYear.CreatedBy = (string)Session["CreatedBy"];
            Session.Remove("CreatedBy");
            financialYear.CreatedAt = (DateTime)Session["CratedAt"];
            Session.Remove("CratedAt");
            financialYear.UpdatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(financialYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(financialYear);
        }

        // GET: FinancialYear/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinancialYear financialYear = db.FinancialYears.Find(id);
            if (financialYear == null)
            {
                return HttpNotFound();
            }
            return View(financialYear);
        }

        // POST: FinancialYear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FinancialYear financialYear = db.FinancialYears.Find(id);
            db.FinancialYears.Remove(financialYear);
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
