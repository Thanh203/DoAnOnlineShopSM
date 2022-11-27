using DoAn.Common;
using DoAn.Models.Dao;
using DoAn.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Area.Controllers
{
    public class UserController : BaseController
    {
        // GET: Area/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            var dao = new UserDao();
            var encryptedMd5Pass = Encryptor.MD5Hash(user.Password);
            user.Password = encryptedMd5Pass;
            long id = dao.Insert(user);
            if (id > 0)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Thêm thành công");
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            var dao = new UserDao();
            if (!string.IsNullOrEmpty(user.Password))
            {
                var encryptedMd5Pass = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pass;
            }

            var result = dao.Update(user);
            if (result)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhập thành công");
            }
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}