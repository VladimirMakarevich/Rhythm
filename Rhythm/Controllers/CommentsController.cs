using NLog;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Concrete;
using Rhythm.Domain.Model;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class CommentsController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        public CommentsController(IRepository repository)
        {
            this.repository = repository;
        }


        public ActionResult AllComments(int id)
        {
            var allComment = repository.Comment.OrderBy(c => c.PostID).Where(i => i.PostID == id).ToList();

            return PartialView(allComment);
        }

        [HttpPost]
        public ActionResult addComment(PostViewModel commentViewModel)
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

                    repository.AddComment(model);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ContactsController async Task<ActionResult> Index [HttpPost]: ", ex.Message);
                }

            }
            return RedirectToAction("Post", "Posts", commentViewModel.Post.ID);
        }
    }
}