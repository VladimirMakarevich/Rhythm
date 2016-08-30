using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class DeleteContentController : DefaultController
    {
        public DeleteContentController(IRepository repository)
        {
            this.repository = repository;
        }


        public ViewResult DeletePost()
        {

            return View();
        }


        [HttpPost]
        public ActionResult DeletePost(PostViewModel post)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteTag()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DeleteTag(TagViewModel tag)
        {

            return View();
        }

        public ActionResult DeleteCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DeleteCategory(CategoryViewModel category)
        {

            return View();
        }
    }
}