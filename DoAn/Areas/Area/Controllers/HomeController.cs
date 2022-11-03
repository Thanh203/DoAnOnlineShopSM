using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Area.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Area/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}