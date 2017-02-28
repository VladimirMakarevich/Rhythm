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
            get { return db.Comments; }
        }

        public List<RecentComment> GetFiveCommentsList()
        {
            var recent = new List<RecentComment>();

            var allPost = db.Posts.OrderBy(p => p.ID).ToList();

            var topComment = db.Comments
                .OrderBy(c => c.PostedOn)
                .AsEnumerable()
                .Reverse()
                .Take(5).ToList();

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
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    comment.PostedOn = DateTime.Now;
                    comment.Post.CountComments++;
                    db.Comments.Add(comment);
                    await db.SaveChangesAsync();
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
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    comment.Modified = DateTime.Now;
                    db.Entry(comment).State = EntityState.Modified;
                    await db.SaveChangesAsync();
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
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    comment.Post.CountComments--;
                    db.Comments.Remove(comment);
                    await db.SaveChangesAsync();
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
