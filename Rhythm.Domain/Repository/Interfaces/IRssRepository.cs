using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface IRssRepository
    {
        Task<Rss> GetRssAsync(int id);
        Task<IEnumerable<Rss>> GetRssesAsync();
        Task CreateRssAsync(Rss rss);
        Task EditRssAsync(Rss rss);
        Task DeleteRssAsync(int id);
    }
}
