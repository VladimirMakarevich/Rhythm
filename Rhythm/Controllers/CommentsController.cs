using Rhythm.Domain.Abstract;
using Rhythm.Domain.Concrete;
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
            //var comments = new List<RecentComment>();

            var allComment = repository.Comment.OrderBy(c => c.PostID).Where(i => i.PostID == id).ToList();

            return PartialView("AllComments", allComment);
        }
    }
}