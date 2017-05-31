using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Rhythm.Domain.Context;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Entities;

namespace Rhythm.Domain.Repository
{
    public class CommentRepository : ICommentRepository
    {
        DogCodingContext _db;
        public CommentRepository(DogCodingContext db)
        {
            _db = db;
        }

        //public List<RecentComment> GetFiveCommentsList()
        //{
        //    var recent = new List<RecentComment>();

        //    var allPost = db.Posts.OrderBy(p => p.ID).ToList();

        //    var topComment = db.Comments
        //        .OrderBy(c => c.PostedOn)
        //        .AsEnumerable()
        //        .Reverse()
        //        .Take(5).ToList();

        //    topComment.ForEach(comment =>
        //    {
        //        var post = allPost.SingleOrDefault(p => p.ID == comment.ID);
        //        recent.Add(new RecentComment
        //        {
        //            CommentContent = comment.Comment1,
        //            PostAddedDate = comment.PostedOn,
        //            NameUserSender = comment.NameUserSender,
        //            ID = comment.PostID
        //        });
        //    });

        //    return recent;
        //}

        public async Task AddCommentAsync(Comment comment)
        {
            comment.PostedOn = DateTime.Now;
            comment.Post.CountComments++;
            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
        }

        public async Task ChangeCommentAsync(Comment comment)
        {
            comment.Modified = DateTime.Now;
            _db.Entry(comment).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(Comment comment)
        {
            comment.Post.CountComments--;
            _db.Comments.Remove(comment);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await _db.Comments.ToListAsync();
        }
    }
}
