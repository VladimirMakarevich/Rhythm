using NLog;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
                .Where(m => m.Published == true)
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

        public async Task<ActionResult> Post(int? id, bool? flag)
        {
            ViewBag.Count = repository.Post.Where(p => p.Published == true).Max(m => m.ID);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post = await repository.GetPostAsync(id, flag);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Post(PostViewModel commentViewModel)
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

                    string src = await repository.AddCommentAsync(model);
                    if (src != null)
                        logger.Error(src);

                    ModelState.Clear();
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    logger.Error("Faild in PostController ActionResult Post [HttpPost]: {0}", ex.Message);
                }
            }
            ModelState.Clear();
            PostViewModel post = new PostViewModel
            {
                Post = repository.Post.FirstOrDefault(p => p.ID == commentViewModel.Post.ID)
            };

            return View(post);
        }

        public FileContentResult GetImage(int id)
        {
            try
            {
                Post post = repository.Post.FirstOrDefault(p => p.ID == id);
                if (post != null)
                {
                    return File(post.ImageData, "image/png");
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.Error("We have exceptions, can not get images: {0}", ex.Message);
            }
            return null;
        }
    }
}