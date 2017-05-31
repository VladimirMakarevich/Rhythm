using Rhythm.Domain.Concrete;
using Rhythm.Domain.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface IPostRepository
    {
        IQueryable<Post> Post { get; }
        RecentArticleWidget GetArticleWidget();
        Task<string> AddPostAsync(Post post);
        Task<Post> GetPostAsync(int? post, bool? flag);
        Task<string> ChangePostAsync(Post post);
        Task<string> DeletePostAsync(Post post);
    }
}
