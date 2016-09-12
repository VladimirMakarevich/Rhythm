using Rhythm.Domain.Abstract;
using Rhythm.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using NLog;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Rhythm.Authentication;
using System.Security.Claims;
using System;

namespace Rhythm.Controllers
{
    public class HomeController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        public int PageSize = 8;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
            ViewBag.Title = "DOGCODING";
            ViewBag.Text = "DogBlog - Vladimir Makarevich - junior backend Developer ASP.NET MVC";
            ViewBag.WordFirst = "C#";
            ViewBag.WordSecond = "ASP.NET MVC";
            ViewBag.WordThird = "WEB";
        }

        public ViewResult Index(int page = 1)
        {
            PostListViewModel model = new PostListViewModel
            {
                Posts = repository.Post
                .OrderBy(p => p.ID)
                .Where(m => m.Published == true)
                .AsEnumerable()
                .Reverse()
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = repository.Post.Count()
                }
            };

            return View(model);
        }

        public ActionResult BadAction()
        {
            throw new Exception("You forgot to implement this ACTION!");
        }
    }
}