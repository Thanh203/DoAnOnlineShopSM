using DoAn.Models.Dao;
using DoAn.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace DoAn.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        OnlineShopSM db = new OnlineShopSM(); 
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPagingProduct(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    var fileName = Path.GetFileName(Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    product.Image = fileName;
                    Image.SaveAs(path);
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.ProductCategories, "ID", "Name",product.CategoryID);
            return View(product);
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
        public ActionResult Edit(Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var productDB = db.Products.FirstOrDefault(p => p.ID == product.ID);
                if (productDB != null)
                {
                    productDB.Name = product.Name;
                    productDB.Code = product.Code;
                    productDB.MetaTitle = product.MetaTitle;
                    productDB.Price = product.Price;
                    productDB.Quantity = product.Quantity;
                    if (Image != null)
                    {
                        //Lấy tên file của hình được up lên
                        var fileName = Path.GetFileName(Image.FileName);
                        //Tạo đường dẫn tới file
                        var path = Path.Combine(Server.MapPath("~/Images"),
                       fileName);
                        //Lưu tên
                        productDB.Image = fileName;
                        //Save vào Images Folder
                        Image.SaveAs(path);
                    }
                    productDB.CategoryID = product.CategoryID;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.Categories, "IDCate", "NameCate",product.CategoryID);
            return View(product);

        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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