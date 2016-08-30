using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class EditContentController : DefaultController
    {
        public EditContentController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: ChiefAdmin/AddContent

        public ActionResult EditPost()
        {
            CategoreDropDownList Categories = new CategoreDropDownList
            {
                Category = repository.Category
                    .OrderBy(c => c.ID)
                    .ToList()
            };

            ViewBag.Category = new SelectList(Categories.Category, "ID", "Name", 1);
            return View();
        }

        [HttpPost]
        public ActionResult EditPost(PostViewModel post)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Post p = new Post
                    {
                        Title = post.Title
                        //TODO: Automapper

                    };
                }
                catch (Exception)
                {

                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditTag()
        {

            return View();
        }

        [HttpPost]
        public ActionResult EditTag(TagViewModel tag)
        {

            return View();
        }

        public ActionResult EditCategory()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult EditCategory(CategoryViewModel category)
        {

            return View();
        }
    }
}