using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class ContactsController : DefaultController
    {
        // GET: Contacts
        public ActionResult Index()
        {
            ViewBag.Title = "Contact";
            ViewBag.Text = "DogBlog - Vladimir Makarevich - junior backend Developer ASP.NET MVC";
            ViewBag.WordFirst = "C#";
            ViewBag.WordSecond = "ASP.NET MVC";
            ViewBag.WordThird = "WEB";
            return View();
        }
    }
}