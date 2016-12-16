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
    public class ShopController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Shop
        public ActionResult Index()
        {
            var shops = db.Shops.Include(s => s.ApplicationUser).Include(s => s.FinancialYear);
            return View(shops.ToList());
        }

        // GET: Shop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            ViewBag.FinancialYearId = new SelectList(db.FinancialYears, "Id", "Name");
            return View();
        }

        // POST: Shop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Email,WebAddress,Phone,FinancialYearId,ModifiedDate", Exclude = "CreatedBy,CreatedAt,UpdatedAt")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                string currentUser = User.Identity.GetUserId();

                shop.CreatedBy = currentUser;
                shop.CreatedAt = DateTime.Now;
                shop.UpdatedAt = DateTime.Now;

                db.Shops.Add(shop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FinancialYearId = new SelectList(db.FinancialYears, "Id", "Name", shop.FinancialYearId);
            return View(shop);
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            Session["CreatedBy"] = shop.CreatedBy;
            Session["CratedAt"] = shop.CreatedAt;
            ViewBag.FinancialYearId = new SelectList(db.FinancialYears, "Id", "Name", shop.FinancialYearId);
            return View(shop);
        }

        // POST: Shop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Email,WebAddress,Phone,FinancialYearId,ModifiedDate", Exclude = "CreatedBy,CreatedAt,UpdatedAt")] Shop shop)
        {
            shop.CreatedBy = (string)Session["CreatedBy"];
            Session.Remove("CreatedBy");
            shop.CreatedAt = (DateTime)Session["CratedAt"];
            Session.Remove("CratedAt");
            shop.UpdatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FinancialYearId = new SelectList(db.FinancialYears, "Id", "Name", shop.FinancialYearId);
            return View(shop);
        }

        // GET: Shop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop shop = db.Shops.Find(id);
            db.Shops.Remove(shop);
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
