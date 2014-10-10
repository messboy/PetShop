using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using backend.Models;

namespace backend.Controllers
{
    public class ItemsController : Controller
    {
        private MSPetShop4Entities db = new MSPetShop4Entities();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Product).Include(i => i.Supplier1);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "CategoryId");
            ViewBag.Supplier = new SelectList(db.Suppliers, "SuppId", "Name");
            return View();
        }

        // POST: Items/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,ProductId,ListPrice,UnitCost,Supplier,Status,Name,Image")] Item item)
        {
            if (ModelState.IsValid)
            {
                Inventory inventory = new Inventory();
                inventory.ItemId = item.ItemId;
                inventory.Qty = 10000;

                db.Items.Add(item);
                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "CategoryId", item.ProductId);
            ViewBag.Supplier = new SelectList(db.Suppliers, "SuppId", "Name", item.Supplier);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "CategoryId", item.ProductId);
            ViewBag.Supplier = new SelectList(db.Suppliers, "SuppId", "Name", item.Supplier);
            return View(item);
        }

        // POST: Items/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,ProductId,ListPrice,UnitCost,Supplier,Status,Name,Image")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "CategoryId", item.ProductId);
            ViewBag.Supplier = new SelectList(db.Suppliers, "SuppId", "Name", item.Supplier);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Item item = db.Items.Find(id);
            Inventory inventory = db.Inventories.Find(id);

            db.Items.Remove(item);
            db.Inventories.Remove(inventory);
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
