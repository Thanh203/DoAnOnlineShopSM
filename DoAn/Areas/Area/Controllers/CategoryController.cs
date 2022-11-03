using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Area.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Area/Category
        public ActionResult Create()
        {
            return View();
        }
    }
}