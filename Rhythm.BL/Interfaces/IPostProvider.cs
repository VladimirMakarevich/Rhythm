﻿using Rhythm.BL.Models;
using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Interfaces
{
    public interface IPostProvider
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task AddPostAsync(Post post);
        Task<Post> GetPostAsync(int post, bool? flag);
        Task ChangePostAsync(Post post);
        Task DeletePostAsync(Post post);
        Task<RecentArticleWidget> GetArticleWidgetAsync();
    }
}