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
    public class EditContentController : DefaultController
    {
        public EditContentController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: ChiefAdmin/AddContent

        public ActionResult EditPost()
        {
            CategoryViewModel Categories = new CategoryViewModel
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
                
            }


                return View();
        }
    }
}