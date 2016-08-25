using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class UpdateContentController : DefaultController
    {
        public UpdateContentController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: ChiefAdmin/ViewContent
        public ViewResult Index()
        {

            return View();
        }
    }
}