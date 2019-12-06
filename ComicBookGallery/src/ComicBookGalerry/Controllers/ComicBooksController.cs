using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicBookGalerry.Controllers
{
    public class ComicBooksController : Controller
    {
        public ActionResult Detail()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
            {
                return Redirect("/");
                // return new RedirectResult("/");
            }

            return Content("Helo from comic book controller");

            //return new ContentResult()
            //{
            //    Content = "Helo from comic book controller"
            //};
        }
    }
}