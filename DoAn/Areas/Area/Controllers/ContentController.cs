using DoAn.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DoAn.Areas.Area.Controllers
{
    public class ContentController : Controller
    {
        // GET: Area/Content
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDao();
            var content = dao.GetByID(id);
            SetViewBag(content.CategoryID);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {

            }
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid)
            {

            }
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? selectedID = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(),"ID","Name", selectedID);
        }
    }
}