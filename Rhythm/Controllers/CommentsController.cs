using Rhythm.Domain.Abstract;
using System.Linq;
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
    }
}