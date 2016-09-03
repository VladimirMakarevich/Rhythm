using System.Collections.Generic;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System.Linq;
using Rhythm.Domain.Concrete;
using System;
using System.Data.Entity;

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

        public void AddComment(Comment comment)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    comment.PostedOn = DateTime.Now;
                    comment.Post.CountComments++;
                    comment.DescriptionComment = false;
                    context.Comments.Add(comment);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    //TODO: Nlog
                }
            }
        }

        public void ChangeComment(Comment comment)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    comment.Modified = DateTime.Now;
                    context.Entry(comment).State = EntityState.Modified;
                    context.SaveChanges();

                    contextDb.Commit();
                }
                catch (System.Exception)
                {
                    //TODO: Nlog

                }
            }
        }

        public void DeleteComment(Comment comment)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Comments.Remove(comment);
                    context.SaveChanges();
                    contextDb.Commit();
                }
                catch (System.Exception)
                {
                    //TODO: Nlog
                }
            }
        }
    }
}
