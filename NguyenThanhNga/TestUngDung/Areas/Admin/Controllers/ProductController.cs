using ModelEF;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        NguyenThiThanhNgaDBContext db= new NguyenThiThanhNgaDBContext();
        // GET: Admin/Product
        public ActionResult Index()

        {
            var product = new ProductModel();
            var model = product.ListAll();
            return View(model);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            Product sp = db.Products.FirstOrDefault(x => x.ID == id);
            return View(sp);
        }

        [HttpPost]
        public ActionResult Details(Product sp)
        {
            Product ctsp = db.Products.FirstOrDefault(x => x.ID == sp.ID);
            ctsp.Name = sp.Name;
            ctsp.UnitCost = sp.UnitCost;
            ctsp.Quantity = sp.Quantity;
            ctsp.CategoryID = sp.CategoryID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        // GET: Admin/Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var lsp = new CategoryModel();
                    //var md = lsp.ListAll().ToList();
                    //ViewBag.ListLSP = new SelectList(md);
                    var model = new ProductModel();
                    int res = model.Create(collection.Name, collection.UnitCost, collection.Quantity, collection.Image, 
                        collection.Description, collection.Status, collection.CategoryID);
                    if (res > 0)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới không thành công");
                    }
                }
                return View(collection);
            }
            catch{
                return View(); }

        }


        public void SetViewBag(String id = null)
        {
            var dao = new CategoryModel();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "CategoryID", "Name", id);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
             
            return View();
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
