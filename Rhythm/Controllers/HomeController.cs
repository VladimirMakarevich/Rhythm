using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class HomeController : Controller
    {
        // GET: BlogHome
        public ActionResult Index()
        {
            ViewBag.Title = "Blog - DogCoding, by Vladimir Makarevich";
            ViewBag.DogCoding = "DogCoding";
            return View();
        }
    }
}