using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rhythm.Domain.Model;
using Rhythm.Domain.Abstract;

namespace Rhythm.Controllers
{
    public class PostsController : DefaultController
    {
        public PostsController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var post = repository.Posts.Include(p => p.Category1);
            return View(post.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = repository.Posts.FirstOrDefault(p => p.ID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
    }
}
