using DoAn.Models.Dao;
using DoAn.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        OnlineShopSM db = new OnlineShopSM(); 
        public ActionResult Index()
        {
            var products = db.Products.ToList();

            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Lỗi tạo mới sản phẩm");
            }
        }
        public ActionResult Details(int id)
        {
            var product = db.Products.Where(c => c.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = db.Products.Where(c => c.ID == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new
               HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Products.Where(c => c.ID == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var product = db.Products.Where(c => c.ID == id).FirstOrDefault();
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Không xóa được do có liên quan đến bảng khác");
            }
        }
    }
}