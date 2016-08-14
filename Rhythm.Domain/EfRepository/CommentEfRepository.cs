using System.Collections.Generic;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System.Linq;
using Rhythm.Domain.Concrete;

namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {
        public IQueryable<Comment> Comment
        {
            get { return context.Comments; }
        }

        public List<RecentComment> GetCommentsList()
        {
            var recent = new List<RecentComment>();

            var allPost = context.Posts.OrderBy(p => p.ID).ToList();

            var topComment = context.Comments
                .OrderBy(c => c.PostedOn)
                .Take(5)
                .ToList();

            topComment.ForEach(comment =>
            {
                var post = allPost.Single(p => p.ID == comment.ID);
                recent.Add(new RecentComment
                {
                    CommentContent = comment.Comment1,
                    PostAddedDate = comment.PostedOn,
                    NameUserSender = comment.NameUserSender
                });
            });

            return recent;
        }
    }
}
