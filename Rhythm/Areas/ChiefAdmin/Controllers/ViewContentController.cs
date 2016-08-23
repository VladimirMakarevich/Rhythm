using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class ViewContentController : DefaultController
    {
        public ViewContentController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: ChiefAdmin/ViewContent
        public ActionResult Index()
        {
            return View();
        }
    }
}