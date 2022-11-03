using DoAn.Common;
using DoAn.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Area.Controllers
{
    public class LoginController : Controller
    {
        // GET: Area/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(Models.LoginModels models)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(models.UserName, Encryptor.MD5Hash(models.Password));
                if (result == 1)
                {
                    var user = dao.GetById(models.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tông tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
            }
            return View("Index");
        }
    }
}