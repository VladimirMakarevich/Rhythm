using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Interfaces
{
    public interface ITagProvider
    {
        Task<IEnumerable<Tag>> GetTagsAsync();
        Task AddTagAsync(Tag tag);
        Task DeleteTagAsync(Tag tag);
        Task ChangeTagAsync(Tag tag);
        Task<Tag> GetTagAsync(int id);
    }
}
