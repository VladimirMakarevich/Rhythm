﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.BL.Models;
using Rhythm.Domain.Entities;
using Rhythm.BL.Interfaces;

namespace Rhythm.BL.Provider
{
    public class CommentProvider : ICommentProvider
    {
        private ICommentRepository _commentRepository;
        private IPostRepository _postRepository;

        public CommentProvider(ICommentRepository commentRepository, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }

        public async Task<List<Comment>> GetFiveCommentsListAsync()
        {
            IEnumerable<Comment> allComments = await _commentRepository.GetCommentsAsync();

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
            comment.Post.CountComments++;

            await _commentRepository.AddCommentAsync(comment);
        }

        public async Task ChangeCommentAsync(Comment comment)
        {
            comment.Modified = DateTime.Now;

            await _commentRepository.ChangeCommentAsync(comment);
        }

        public async Task DeleteCommentAsync(Comment comment)
        {
            comment.Post.CountComments--;

            await _commentRepository.DeleteCommentAsync(comment);
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await _commentRepository.GetCommentsAsync();
        }
    }
}
