using Rhythm.Domain.Concrete;
using Rhythm.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rhythm.Domain.Abstract
{
    public interface IRepository
    {
        IQueryable<Post> Post { get; }
        IQueryable<Tag> Tag { get; }
        IQueryable<Category> Category { get; }
        IQueryable<Comment> Comment { get; }
        List<RecentComment> GetFiveCommentsList();
        RecentArticleWidget GetArticleWidget();
        Task<string> AddCommentAsync(Comment comment);
        Task<string> AddPostAsync(Post post);
        Task<Post> GetPostAsync(int? post, bool? flag);
        Task<string> AddTagAsync(Tag tag);
        Task<string> AddCategoryAsync(Category category);
        Task<string> ChangeTagAsync(Tag tag);
        Task<string> ChangeCategoryAsync(Category category);
        Task<string> ChangePostAsync(Post post);
        Task<string> ChangeCommentAsync(Comment comment);
        Task<string> DeleteTagAsync(Tag tag);
        Task<string> DeleteCategoryAsync(Category category);
        Task<string> DeletePostAsync(Post post);
        Task<string> DeleteCommentAsync(Comment comment);
    }
}
