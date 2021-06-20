using ModelEF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(int page=1,int pagesize= 5)
        {
            var user = new AccountModel();
            var model = user.ListAll();
            return View(model.ToPagedList(page,pagesize));
        }
        [HttpPost]

        public ActionResult Index(string searchString,int page=1,int pagesize=5)
        {
            var user = new AccountModel();
            var model = user.ListWhereUser(searchString,page,pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpDelete]
        public ActionResult Delete(string UserName)
        {
             new AccountModel().Delete(UserName);
            return RedirectToAction("Index");
        }
    }
}