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
        // GET: Categories
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }
    }
}