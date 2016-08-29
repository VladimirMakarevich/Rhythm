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


        public ViewResult UpdatePost()
        {

            return View();
        }


        [HttpPost]
        public ActionResult UpdatePost(PostViewModel post)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UpdateTag()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UpdateTag(TagViewModel tag)
        {

            return View();
        }

        public ActionResult UpdateCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UpdateCategory(CategoryViewModel category)
        {

            return View();
        }
    }
}