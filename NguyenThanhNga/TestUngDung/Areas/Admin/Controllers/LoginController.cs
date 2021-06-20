using ModelEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TestUngDung.Areas.Admin.Data;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var user = new AccountModel();
                var result = user.login(login.UserName,login.Password);
                if (result == 1)
                {
                    //ModelState.AddModelError("", "Đăng nhập thành công");
                    Session.Add(Constants.UserSession,login);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }
             }
            return View("Index");
        }
    }
}