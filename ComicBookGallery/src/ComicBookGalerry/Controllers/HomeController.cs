using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicBookGalerry.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
<<<<<<< Updated upstream
            return View();
=======
            var msg = "New msg";
            return Content(msg);
>>>>>>> Stashed changes
        }
    }
}