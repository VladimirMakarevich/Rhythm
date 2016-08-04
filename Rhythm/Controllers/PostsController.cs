using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class PostsController : Controller
    {
        private IRepository repository;
        public PostsController(IRepository articleRepository)
        {
            this.repository = articleRepository;
        }
        // GET: Articles
        public ActionResult Index()
        {
            return View(repository.Posts);
        }
    }
}