using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class LibraryController : DefaultController
    {
        // GET: Library
        public ActionResult Index()
        {
            ViewBag.Title = "Library";
            ViewBag.Text = "";
            ViewBag.WordFirst = "C#";
            ViewBag.WordSecond = "ASP.NET MVC";
            ViewBag.WordThird = "WEB";
            return View();
        }
    }
}