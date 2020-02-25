using HomeBudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBudgetApp.Controllers
{
    public class CategoriesController : BaseController
    {
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public ActionResult New()
        {
            var category = new Category();
            return View("Form", category);
        }

        public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
                return View("Form", category);


            if (category.CategoryId == 0)
            {
                _context.Categories.Add(category);

                TempData["ActionResultEfect"] = $"Category was successfully added";
            }
            else
            {
                var categoryDB = _context.Categories.Single(c => c.CategoryId == category.CategoryId);
                categoryDB.Name = category.Name;

                TempData["ActionResultEfect"] = $"Category was successfully changed";
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (category == null)
                return HttpNotFound();

            return View("Form", category);
        }

        public void Delete (int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (category == null)
                return;

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}