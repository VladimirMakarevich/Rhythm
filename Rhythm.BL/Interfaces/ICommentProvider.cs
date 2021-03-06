﻿using Rhythm.BL.Models;
using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Interfaces
{
    public interface ICommentProvider
    {
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task<List<Comment>> GetFiveCommentsListAsync();
        Task AddCommentAsync(Comment comment);
        Task ChangeCommentAsync(Comment comment);
        Task DeleteCommentAsync(Comment comment);
        Task<Comment> GetCommentAsync(int id);
        List<Comment> GetFiveCommentsList();
    }
}
