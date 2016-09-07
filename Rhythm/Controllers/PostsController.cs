using NLog;
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
    public class PostsController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        public int PageSize = 8;
        public PostsController(IRepository repository)
        {
            this.repository = repository;
            ViewBag.Title = "Posts";
            ViewBag.Text = "";
            ViewBag.WordFirst = "C#";
            ViewBag.WordSecond = "ASP.NET MVC";
            ViewBag.WordThird = "WEB";
        }

        public ViewResult Index(int page = 1)
        {
            PostListViewModel model = new PostListViewModel
            {
                Posts = repository.Post
                .OrderBy(s => s.ID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize).ToArray().Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = repository.Post.Count()
                }
            };

            return View(model);
        }

        public ActionResult Post(int? id)
        {
            ViewBag.Count = repository.Post.Count();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = repository.Post.FirstOrDefault(p => p.ID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            PostViewModel postView = new PostViewModel
            {
                Post = post
            };
            return View(postView);
        }

        public FileContentResult GetImage(int id)
        {
            Post post = repository.Post.FirstOrDefault(p => p.ID == id);
            if (post != null)
            {
                return File(post.ImageData, post.ImageMime);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(PostViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Comment model = new Comment
                    {
                        PostID = commentViewModel.Post.ID,
                        NameUserSender = commentViewModel.Comment.NameUserSender,
                        EmailUserSender = commentViewModel.Comment.EmailUserSender,
                        Comment1 = commentViewModel.Comment.Comment1,
                        DescriptionComment = commentViewModel.Comment.DescriptionComment,
                        Post = repository.Post.FirstOrDefault(p => p.ID == commentViewModel.Post.ID),
                        PostedOn = DateTime.Now
                    };

                    string src = repository.AddComment(model);
                    if (src != null)
                        logger.Error(src);

                    ModelState.Clear();
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    logger.Error("Faild in PostController ActionResult Post [HttpPost]: ", ex.Message);
                }
            }

            PostViewModel post = new PostViewModel
            {
                Post = repository.Post.FirstOrDefault(p => p.ID == commentViewModel.Post.ID)
            };

            return View(post);
        }
    }
}