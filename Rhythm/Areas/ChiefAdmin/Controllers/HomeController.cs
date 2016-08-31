using Ninject.Infrastructure.Language;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize(Roles = "DogAdmin")]
    public class HomeController : DefaultController
    {
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }

        public ViewResult Index()
        {
            Content content = new Content
            {
                Posts = repository.Post
                .OrderBy(p => p.ID)
                .Take(15).ToArray().Reverse(),

                Categories = repository.Category
                .OrderBy(c => c.ID).ToList(),

                Tags = repository.Tag
                .OrderBy(t => t.ID).ToList(),

                Comments = repository.Comment
                .OrderBy(co => co.ID)
                .Take(15).ToArray().Reverse()

            };

            return View(content);
        }
    }
}