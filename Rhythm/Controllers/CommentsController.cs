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
                catch (Exception)
                {
                    //TODO: NLog
                }

            }
            //commentViewModel.Comment.PostID = commentViewModel.ID;
            //commentViewModel.Comment.Post = repository.Post.FirstOrDefault(p => p.ID == commentViewModel.ID);
            //repository.AddComment(commentViewModel.Comment);

            //var allComment = repository.Comment.OrderBy(c => c.PostID).Where(i => i.PostID == commentViewModel.ID).ToList();
            //return PartialView(allComment);
            return RedirectToAction("Post", "Posts", commentViewModel.Post.ID);
        }

        //[ChildActionOnly]
        //public ActionResult addComment(int id)
        //{

        //    return PartialView();
        //}

        //private ActionResult RiderectByPostType(CommentViewModel commentViewModel, bool flagCheck)
        //{
        //    return RiderectByPostType(commentViewModel, flagCheck);
        //}

        //private List<string> GetModelErrors()
        //{
        //    var errors = new List<string>();
        //    ModelState.Values.ToList().ForEach(value =>
        //    {
        //        if (value.Errors.Count > 0)
        //            errors.Add(value.Errors.First().ErrorMessage);
        //    });
        //    return errors;
        //}
    }
}