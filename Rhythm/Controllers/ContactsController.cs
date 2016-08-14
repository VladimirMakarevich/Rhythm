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
            return View();
        }
    }
}