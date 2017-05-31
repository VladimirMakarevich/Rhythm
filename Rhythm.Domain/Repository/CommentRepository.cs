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
    public class CommentRepository : ICommentRepository, IRepository
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

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
