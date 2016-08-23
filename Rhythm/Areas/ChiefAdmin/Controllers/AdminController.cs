using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class AdminController : DefaultController
    {
        // GET: ChiefAdmin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}