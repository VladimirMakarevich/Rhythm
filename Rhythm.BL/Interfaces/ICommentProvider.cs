using Rhythm.BL.Models;
using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Interfaces
{
    public interface ICommentProvider
    {
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task<List<RecentComment>> GetFiveCommentsList();
        Task AddCommentAsync(Comment comment);
        Task ChangeCommentAsync(Comment comment);
        Task DeleteCommentAsync(Comment comment);
    }
}
