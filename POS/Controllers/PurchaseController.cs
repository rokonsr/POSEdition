using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace POS.Controllers
{
    public class PurchaseController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Purchase
        public ActionResult Index()
        {
            var supplierList = db.Suppliers.ToList();
            ViewBag.Suppliers = supplierList;

            PurchaseDetail objPurchaseDetail = new PurchaseDetail();
            ViewBag.BarcodeGenerated = objPurchaseDetail.BarCode;

            var productList = db.Products.ToList();
            ViewBag.Products = productList;
            return View();
        }

        [HttpPost]
        public JsonResult SaveOrder(Purchase objPurchase)
        {
            
            bool status = false;
            if (ModelState.IsValid)
            {
                string currentUser = User.Identity.GetUserId();

                objPurchase.CreatedBy = currentUser;
                objPurchase.CreatedAt = DateTime.Now;
                objPurchase.UpdatedAt = DateTime.Now;
                List<Product> productList = new List<Product>();
                using (ApplicationDbContext dc = new ApplicationDbContext())
                {
                    foreach (PurchaseDetail p in objPurchase.PurchaseDetails)
                    {
                        Product product = dc.Products.Where(x => x.ProductId == p.ProductId).FirstOrDefault();
                        product.Stock = product.Stock + p.Quantity;
           
                        productList.Add(product);
                    }


                    dc.Purchases.Add(objPurchase);
                    foreach (var p in productList)
                    {
                        dc.Entry(p).State = EntityState.Modified;
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}