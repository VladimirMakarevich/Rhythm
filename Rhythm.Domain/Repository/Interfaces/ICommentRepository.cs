using Rhythm.Domain.Concrete;
using Rhythm.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comment { get; }
        List<RecentComment> GetFiveCommentsList();
        Task<string> AddCommentAsync(Comment comment);
        Task<string> ChangeCommentAsync(Comment comment);
        Task<string> DeleteCommentAsync(Comment comment);
    }
}
