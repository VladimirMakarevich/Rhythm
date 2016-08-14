using Castle.Core.Internal;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class RecentsController : DefaultController
    {
        public RecentsController(IRepository repository)
        {
            this.repository = repository;
        }

        [ChildActionOnly]
        public ActionResult RecentCategories()
        {
            var category = repository.Category.OrderBy(p => p.ID).ToList();
            return PartialView("RecentCategories", category);
        }

        [ChildActionOnly]
        public ActionResult RecentTags()
        {
            var tag = repository.Tag.OrderBy(p => p.ID).ToList();
            return PartialView("RecentTags", tag);
        }



        [ChildActionOnly]
        public ActionResult RecentPosts()
        {
            var posts = repository.Post.OrderBy(p => p.ID).Take(5).ToList();
            return PartialView("RecentPosts", posts);
        }

        [ChildActionOnly]
        public ActionResult RecentComments()
        {
            var comments = repository.GetCommentsList();
            return PartialView("RecentComments", comments);
        }

        //[ChildActionOnly]
        //public ActionResult RecentArticleWidgets()
        //{
        //    int r = 100;
        //    var articleWidget = new Random();
        //    articleWidget.
        //        return 
        //}


    }
}