using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task AddCommentAsync(Comment comment);
        Task ChangeCommentAsync(Comment comment);
        Task DeleteCommentAsync(Comment comment);
        Task<Comment> GetCommentAsync(int id);
    }
}
