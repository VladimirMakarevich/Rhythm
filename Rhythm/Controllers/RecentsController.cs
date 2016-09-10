using Rhythm.Domain.Abstract;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Rhythm.Domain.Model;
using Rhythm.Collections;
using System;
using Rhythm.Models;
using System.Threading.Tasks;
using System.Data.Entity;

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
            var posts = GetPosts();
            return PartialView("RecentPosts", posts);
        }

        [ChildActionOnly]
        public ActionResult RecentComments()
        {
            var comments = repository.GetFiveCommentsList();
            return PartialView("RecentComments", comments);
        }

        [ChildActionOnly]
        public ActionResult RecentArticleWidgets()
        {
            var articleWidget = repository.GetArticleWidget();

            return PartialView("RecentArticleWidgets", articleWidget);
        }

        [ChildActionOnly]
        public ActionResult RecentArchives()
        {
            var model = new ArchiveCollection(GetPost());
            return PartialView(model);
        }
        public List<Post> GetPost()
        {
            var posts = repository.Post.OrderBy(p => p.ID).Where(m => m.Published == true).ToList();
            return posts;
        }
        public IEnumerable<Post> GetPosts()
        {
            var posts = repository.Post.OrderBy(p => p.ID).Where(m => m.Published == true).ToArray().Reverse();
            return posts;
        }
    }
}