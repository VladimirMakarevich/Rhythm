using System.Collections.Generic;
using Rhythm.Domain.Model;
using System.Linq;
using Rhythm.Domain.Concrete;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {
        public IQueryable<Comment> Comment
        {
            get { return context.Comments; }
        }

        public List<RecentComment> GetFiveCommentsList()
        {
            var recent = new List<RecentComment>();

            var allPost = context.Posts.OrderBy(p => p.ID).ToList();

            var topComment = context.Comments
                .OrderBy(c => c.PostedOn)
                .Take(5)
                .ToList();

            topComment.ForEach(comment =>
            {
                var post = allPost.SingleOrDefault(p => p.ID == comment.ID);
                recent.Add(new RecentComment
                {
                    CommentContent = comment.Comment1,
                    PostAddedDate = comment.PostedOn,
                    NameUserSender = comment.NameUserSender,
                    ID = comment.PostID
                });
            });

            return recent;
        }

        public async Task<string> AddCommentAsync(Comment comment)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    comment.Post.CountComments++;
                    context.Comments.Add(comment);
                    await context.SaveChangesAsync();
                    contextDb.Commit();

                }
                catch (Exception ex)
                {
                    string src = String.Format("Error AddComment: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
                return null;
            }
        }

        public async Task<string> ChangeCommentAsync(Comment comment)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    comment.Modified = DateTime.Now;
                    context.Entry(comment).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    contextDb.Commit();
                }
                catch (System.Exception ex)
                {
                    string src = String.Format("Error ChangeComment: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
                return null;
            }
        }

        public async Task<string> DeleteCommentAsync(Comment comment)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    comment.Post.CountComments--;
                    context.Comments.Remove(comment);
                    await context.SaveChangesAsync();
                    contextDb.Commit();
                }
                catch (System.Exception ex)
                {
                    string src = String.Format("Error DeleteComment: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
                return null;
            }
        }
    }
}
