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
    public class CustomerProductsController : Controller
    {
        private OnlineShopSM db = new OnlineShopSM();
        // GET: CustomerProducts
        public ActionResult Index(string searchString, int page = 1, int pageSize = 100)
        {
            var dao = new UserDao();
            var model = dao.ListAllPagingCustomer(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new
               HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult LayChuDe()
        {
            var dsChuDe = db.ProductCategories.ToList();
            return PartialView(dsChuDe);
        }
        public ActionResult SPTheoChuDe(int id)
        {
            var dsTheoChuDe = db.Products.Where(x => x.CategoryID == id).ToList();  
            return View("Index", dsTheoChuDe);
        }
    }
}