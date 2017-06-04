using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task AddPostAsync(Post post);
        Task ChangePostAsync(Post post);
        Task DeletePostAsync(Post post);
        Task<Post> GetPostAsync(int id);
    }
}
