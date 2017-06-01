using Rhythm.BL.Interfaces;
using Rhythm.Mappers;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class CommentsController : DefaultController
    {
        private CommentMapper _commentMapper;

        public CommentsController(ICommentProvider commentProvider, CommentMapper commentMapper)
        {
            _commentProvider = commentProvider;
            _commentMapper = commentMapper;
        }


        public async Task<ActionResult> AllComments(int id)
        {
            var comments = await _commentProvider.GetCommentsAsync();
            var commentsViewModel = _commentMapper.ToCommentsViewModel(comments);
            //var sortedComments = allComment.OrderBy(c => c.PostID).Where(i => i.PostID == id).ToList();

            return PartialView(commentsViewModel);
        }
    }
}