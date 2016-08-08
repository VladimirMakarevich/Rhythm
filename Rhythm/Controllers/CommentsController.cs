using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RecentComments()
        {
            var comments = GetRecentComments();
            return PartialView("RecentComments", comments);
        }

        private object GetRecentComments()
        {
            throw new NotImplementedException();
        }
    }
}