using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class ArticlesController : DefaultController
    {
        public int PageSize = 8;
        public ArticlesController(IRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(int page = 1)
        {
            PostListViewModel model = new PostListViewModel
            {
                Posts = repository.Post
                .OrderBy(s => s.ID)
                .Where(p => p.IfArticle == true)
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

        public ActionResult Article(int? id)
        {
            //TODO: change
            if (id == 0)
            {
                id++;
            }
            if (id >= repository.Post.Count())
            {
                id--;
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = repository.Post.FirstOrDefault(p => p.ID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
    }
}