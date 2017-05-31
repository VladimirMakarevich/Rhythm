using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetTagsAsync();
        Task AddTagAsync(Tag tag);
        Task ChangeTagAsync(Tag tag);
    }
}
