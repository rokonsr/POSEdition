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
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ApplicationUser).Include(p => p.Brand).Include(p => p.Category).Include(p => p.Measurement).Include(p => p.Shop);
            return View(products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.MeasurementId = new SelectList(db.Measurements, "Id", "Name");
            ViewBag.ShopId = new SelectList(db.Shops, "Id", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,BarCode,CategoryId,ShopId,BrandId,MeasurementId,Stock,ModifiedDate", Exclude = "CreatedBy,CreatedAt,UpdatedAt")] Product product)
        {
            if (ModelState.IsValid)
            {
                string currentUser = User.Identity.GetUserId();

                product.CreatedBy = currentUser;
                product.CreatedAt = DateTime.Now;
                product.UpdatedAt = DateTime.Now;

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.MeasurementId = new SelectList(db.Measurements, "Id", "Name", product.MeasurementId);
            ViewBag.ShopId = new SelectList(db.Shops, "Id", "Name", product.ShopId);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            Session["CreatedBy"] = product.CreatedBy;
            Session["CratedAt"] = product.CreatedAt;

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.MeasurementId = new SelectList(db.Measurements, "Id", "Name", product.MeasurementId);
            ViewBag.ShopId = new SelectList(db.Shops, "Id", "Name", product.ShopId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,BarCode,CategoryId,ShopId,BrandId,MeasurementId,Stock,ModifiedDate", Exclude = "CreatedBy,CreatedAt,UpdatedAt")] Product product)
        {
            product.CreatedBy = (string)Session["CreatedBy"];
            Session.Remove("CreatedBy");
            product.CreatedAt = (DateTime)Session["CratedAt"];
            Session.Remove("CratedAt");
            product.UpdatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.MeasurementId = new SelectList(db.Measurements, "Id", "Name", product.MeasurementId);
            ViewBag.ShopId = new SelectList(db.Shops, "Id", "Name", product.ShopId);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
