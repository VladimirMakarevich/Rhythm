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
        string AddComment(Comment comment);
        string AddPost(Post post);
        string AddTag(Tag tag);
        string AddCategory(Category category);
        string ChangeTag(Tag tag);
        string ChangeCategory(Category category);
        string ChangePost(Post post);
        string ChangeComment(Comment comment);
        string DeleteTag(Tag tag);
        string DeleteCategory(Category category);
        string DeletePost(Post post);
        string DeleteComment(Comment comment);
        DogUser Login(string email, string password);
        DogUser GetUser(string email);
    }
}
