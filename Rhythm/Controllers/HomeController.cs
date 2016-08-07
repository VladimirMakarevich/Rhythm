using Rhythm.Domain.Abstract;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;
        public int PageSize = 2;
        public HomeController(IRepository postRepository)
        {
            this.repository = postRepository;
        }
        // GET: BlogHome
        public ActionResult Index()
        {
            ViewBag.Title = "Blog - DogCoding, by Vladimir Makarevich";
            ViewBag.DogCoding = "DogCoding";
            return View();
        }

        public ViewResult List(int page = 1)
        {
            PostListViewModel model = new PostListViewModel
            {
                Posts = repository.Posts
                .OrderBy(p => p.ID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = repository.Posts.Count()
                }
            };

            return View(model);
        }
    }
}