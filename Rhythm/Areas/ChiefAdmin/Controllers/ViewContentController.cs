using Rhythm.Areas.ChiefAdmin.Models;
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
        public ViewResult Index()
        {
            Content content = new Content
            {
                Posts = repository.Post
                .OrderBy(p => p.ID).ToList(),

                Categories = repository.Category
                .OrderBy(c => c.ID).ToList(),

                Tags = repository.Tag
                .OrderBy(t => t.ID).ToList(),

                Comments = repository.Comment
                .OrderBy(co => co.ID).ToList()

            };

            return View(content);
        }
    }
}