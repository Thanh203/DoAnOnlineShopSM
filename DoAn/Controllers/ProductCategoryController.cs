using DoAn.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        OnlineShopSM db = new OnlineShopSM();
        public ActionResult Index()
        {
            var productsCategory = db.ProductCategories.ToList();

            return View(productsCategory);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            try
            {
                db.ProductCategories.Add(productCategory);
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
            var productCategory = db.ProductCategories.Where(c => c.ID == id).FirstOrDefault();
            return View(productCategory);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var productCategory = db.ProductCategories.Where(c => c.ID == id).FirstOrDefault();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Edit(int id, ProductCategory productCategory)
        {
            db.Entry(productCategory).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productCategory = db.ProductCategories.Where(c => c.ID == id).FirstOrDefault();
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var productCategory = db.ProductCategories.Where(c => c.ID == id).FirstOrDefault();
                db.ProductCategories.Remove(productCategory);
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