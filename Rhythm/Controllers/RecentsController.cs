using Rhythm.Domain.Abstract;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Rhythm.Domain.Model;
using Rhythm.Collections;
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
            //TODO: Async
            var category = repository.Category.OrderBy(p => p.ID).ToList();
            return PartialView("RecentCategories", category);
        }

        [ChildActionOnly]
        public ActionResult RecentTags()
        {
            //TODO: Async
            var tag = repository.Tag.OrderBy(p => p.ID).ToList();
            return PartialView("RecentTags", tag);
        }


        [ChildActionOnly]
        public ActionResult RecentPosts()
        {
            //TODO: Async
            var posts = GetPost();
            return PartialView("RecentPosts", posts);
        }

        [ChildActionOnly]
        public ActionResult RecentComments()
        {
            //TODO: Async
            var comments = repository.GetFiveCommentsList();
            return PartialView("RecentComments", comments);
        }

        [ChildActionOnly]
        public ActionResult RecentArticleWidgets()
        {
            //TODO: Async
            var articleWidget = repository.GetArticleWidget();

            if (articleWidget != null)
            {
                return PartialView("RecentArticleWidgets", articleWidget);
            }
            return View();
        }

        [ChildActionOnly]
        public ActionResult RecentArchives()
        {
            //TODO: Async
            var model = new ArchiveCollection(GetPost());
            return PartialView(model);
        }
        public List<Post> GetPost()
        {
            var posts = repository.Post
                .OrderBy(p => p.ID)
                .Where(m => m.Published == true)
                .ToList();
            return posts;
        }
        public IEnumerable<Post> GetPosts()
        {
            var posts = repository.Post
                .OrderBy(p => p.ID)
                .Where(m => m.Published == true)
                .AsEnumerable()
                .Reverse()
                .Take(5);
            
            return posts;
        }
    }
}