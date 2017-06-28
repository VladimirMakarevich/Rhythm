using System.Collections.Generic;
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

        public async Task<Comment> GetCommentAsync(int id)
        {
            return await _db.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<Comment> GetComments()
        {
            return _db.Comments;
        }
    }
}
