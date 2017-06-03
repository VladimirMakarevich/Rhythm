using Rhythm.BL.Models;
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
        Task<Post> GetPostWidgetAsync();
        Task<IEnumerable<Post>> GetPostsByCategoryAsync(int id);
        Task<IEnumerable<Post>> GetPostsByTagAsync(int id);
        Task<IEnumerable<Post>> GetPostsByTextAsync(string searchText);
    }
}
