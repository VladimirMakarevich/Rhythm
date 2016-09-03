using Rhythm.Domain.Concrete;
using Rhythm.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

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
        void AddTag(Tag tag);
        void AddCategory(Category category);
        void ChangeTag(Tag tag);
        void ChangeCategory(Category category);
        void ChangePost(Post post);
        void ChangeComment(Comment comment);
        void DeleteTag(Tag tag);
        void DeleteCategory(Category category);
        void DeletePost(Post post);
        void DeleteComment(Comment comment);
        DogUser Login(string email, string password);
        DogUser GetUser(string email);
    }
}
