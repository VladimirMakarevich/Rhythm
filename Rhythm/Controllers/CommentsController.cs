﻿using Rhythm.Domain.Abstract;
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
        public ActionResult AllComments(int? id)
        {
            var allComment = repository.Comment.OrderBy(c => c.PostID).Where(i => i.PostID == id).ToList();

            return PartialView("AllComments", allComment);
        }

        public ActionResult Add(CommentViewModel commentViewModel)
        {
            bool flagCheck = false;
            if (commentViewModel.NameSender != null && commentViewModel.IsHuman == true)
            {
                commentViewModel.Comment.PostID = commentViewModel.Post.ID;
                flagCheck = true;
            }
            else
            {
                TempData["CommentErrors"] = GetModelErrors();
            }

            return View(); 
        }

        private ActionResult RiderectByPostType(CommentViewModel commentViewModel, bool flagCheck)
        {
            return RiderectByPostType(commentViewModel, flagCheck);
        }

        private List<string> GetModelErrors()
        {
            var errors = new List<string>();
            ModelState.Values.ToList().ForEach(value =>
            {
                if (value.Errors.Count > 0)
                    errors.Add(value.Errors.First().ErrorMessage);
            });
            return errors;
        }
    }
}