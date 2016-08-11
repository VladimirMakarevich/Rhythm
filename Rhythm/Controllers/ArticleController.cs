using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class ArticleController : DefaultController
    {
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }
    }
}