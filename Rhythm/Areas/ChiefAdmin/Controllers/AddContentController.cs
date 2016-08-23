using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class AddContentController : DefaultController
    {
        public AddContentController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: ChiefAdmin/AddContent
        public ActionResult Index()
        {
            return View();
        }
    }
}