using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class DeleteContentController : DefaultController
    {
        public DeleteContentController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: ChiefAdmin/DeleteContent
        public ActionResult Index()
        {
            return View();
        }
    }
}