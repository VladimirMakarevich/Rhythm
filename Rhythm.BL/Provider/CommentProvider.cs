using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.BL.Interfaces;
using Rhythm.Domain.UnitOfWork;

namespace Rhythm.BL.Provider
{
    public class CommentProvider : ICommentProvider
    {
        private IUnitOfWork _uow;

        public CommentProvider(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Comment>> GetFiveCommentsListAsync()
        {
            IEnumerable<Comment> allComments = await _uow.Comment.GetCommentsAsync();

            List<Comment> topComment = allComments
                .OrderBy(c => c.PostedOn)
                .AsEnumerable()
                .Reverse()
                .Take(5).ToList();

            return topComment;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            comment.PostedOn = DateTime.Now;
            comment.Post.CountComments = comment.Post.CountComments + 1;

            await _uow.Comment.AddCommentAsync(comment);
        }

        public async Task ChangeCommentAsync(Comment comment)
        {
            comment.Modified = DateTime.Now;

            await _uow.Comment.ChangeCommentAsync(comment);
        }

        public async Task DeleteCommentAsync(Comment comment)
        {
            comment.Post.CountComments = comment.Post.CountComments - 1;

            await _uow.Comment.DeleteCommentAsync(comment);
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await _uow.Comment.GetCommentsAsync();
        }

        public async Task<Comment> GetCommentAsync(int id)
        {
            return await _uow.Comment.GetCommentAsync(id);
        }

        public List<Comment> GetFiveCommentsList()
        {
            IEnumerable<Comment> comments = _uow.Comment.GetComments();

            return comments
                .OrderBy(c => c.PostedOn)
                .AsEnumerable()
                .Reverse()
                .Take(5).ToList();
        }
    }
}
