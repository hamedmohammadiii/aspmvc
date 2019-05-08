using Products.DAL;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsDBContext db;

        public ProductController()
        {
            db = new ProductsDBContext();
        }
        public ActionResult Index()
        {
            var list = new List<Product>();
            list = db.Products.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var Types = db.Types.ToList();
            var selectlist = new SelectList(Types, "Id", "Caption");
            ViewBag.Types = selectlist;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product entity)
        {
            if (!ModelState.IsValid)
            {

            }

            if (db.Products.Any(x => x.Id == entity.Id))
            {
                ViewBag.Message = "This Product Already Exists.";
                return View(entity);
            }

            if (entity.BrandName == null)
            {
                ViewBag.Message = "Please Enter Brand Name";
                return View(entity);
            }

            if (entity.ModelNo == null)
            {
                ViewBag.Message = "Please Enter Model Number.";
                return View(entity);
            }

            db.Products.Add(entity);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var entity = db.Products.Find(Id);
           

            if (entity == null)
            {
                ViewBag.Message = "Not Found.";
                return RedirectToAction("Index");
            }

            var Types = db.Types.ToList();
            var selectlist = new SelectList(Types, "Id", "Caption");
            ViewBag.Types = selectlist;
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(Product entity)
        {
            var Types = db.Types.ToList();
            var selectlist = new SelectList(Types, "Id", "Caption");
            ViewBag.Types = selectlist;

            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int code)
        {
            var entity = db.Products.FirstOrDefault(x => x.Id == code);

            if (entity == null)
            {
                ViewBag.Message = "Not Found.";
                return RedirectToAction("Index");
            }

            db.Products.Remove(entity);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult TypesPartial()
        {
            var types = db.Types.ToList();
            return PartialView(types);
        }
    }
}