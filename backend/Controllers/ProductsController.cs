using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using backend.Models;
using PagedList;

namespace backend.Controllers
{
    public class ProductsController : Controller
    {
        private MSPetShop4Entities db = new MSPetShop4Entities();
        private int pageSize = 10;

        // GET: Products
        public ActionResult Index(string keyword, int page = 1  )
        {
            int currentPage = page < 1 ? 1 : page;

            IQueryable<Product> products = db.Products.Include(p => p.Category).OrderBy(x => x.CategoryId);

            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(x => x.Name.Contains(keyword));
                ViewBag.Keyword = keyword;
            }

            var result = products.ToPagedList(currentPage, pageSize);
            return View(result);
        }

        // GET: Products/Details/5
        public ActionResult Details(string id)
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

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,CategoryId,Name,Descn,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase upload)
        {

            if (ModelState.IsValid)
            {
                CheckFiles(upload);
                HandleFiles(product, upload);
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }


        private void HandleFiles(Product product, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                //指定檔案存放位置
                var path = string.Concat("~/Prod_Images/", "Birds", "/", upload.FileName);
                var filepath = Server.MapPath(string.Concat("~/Prod_Images/", "Birds", "/")).Replace("Backend", "Web");


                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                upload.SaveAs(Path.Combine(filepath, upload.FileName));
                product.Image = path;
            }
                
        }

        // GET: Products/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void CheckFiles(HttpPostedFileBase upload)
        {

                    //檢查檔名
                    //檢查格式
                    if (upload != null && !Regex.IsMatch(upload.FileName, @"\.(jpg|jpeg|gif|png)$"))
                    {
                        ModelState.AddModelError("Upload", "僅可上傳圖片檔");
                    }
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
