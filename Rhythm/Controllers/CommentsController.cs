using Rhythm.Domain.Abstract;
using Rhythm.Domain.Concrete;
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


        [ChildActionOnly]
        public ActionResult AllComments(int id)
        {
            var allComment = repository.Comment.OrderBy(c => c.PostID).Where(i => i.PostID == id).ToList();

            return PartialView(allComment);
        }

        public ActionResult addComments(CommentViewModel commentViewModel)
        {

            commentViewModel.Comment.PostID = commentViewModel.ID;
            commentViewModel.Comment.Post = repository.Post.FirstOrDefault(p => p.ID == commentViewModel.ID);
            repository.AddComment(commentViewModel.Comment);

            //var allComment = repository.Comment.OrderBy(c => c.PostID).Where(i => i.PostID == commentViewModel.ID).ToList();
            //return PartialView(allComment);
            return null;
        }
        //[ChildActionOnly]
        //public ActionResult AddComment(int id)
        //{
        //    CommentViewModel comment = new CommentViewModel()
        //    {
        //        EmailSender = "Type your mail",
        //        NameSender = "Type your name",
        //        ID = id
        //    };
        //    return PartialView(comment);
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