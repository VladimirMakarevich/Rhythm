using Rhythm.Domain.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface ITagRepository
    {
        IQueryable<Tag> Tag { get; }
        Task<string> AddTagAsync(Tag tag);
        Task<string> ChangeTagAsync(Tag tag);
    }
}
