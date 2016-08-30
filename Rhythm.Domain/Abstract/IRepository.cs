﻿using Rhythm.Domain.Concrete;
using Rhythm.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Rhythm.Domain.Abstract
{
    public interface IRepository
    {
        IQueryable<Post> Post { get; }
        IQueryable<Tag> Tag { get; }
        IQueryable<Category> Category { get; }
        IQueryable<Comment> Comment { get; }
        IQueryable<DogUser> User { get; }
        IQueryable<DogRole> Role { get; }
        List<RecentComment> GetFiveCommentsList();
        RecentArticleWidget GetArticleWidget();
        void AddComment(Comment comment);
        void AddPost(Post post);
        DogUser Login(string email, string password);
        DogUser GetUser(string email);

    }
}
