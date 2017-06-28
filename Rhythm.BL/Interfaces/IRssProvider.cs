using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Interfaces
{
    public interface IRssProvider
    {
        Task<Rss> GetRssAsync(int id);
        Task<IEnumerable<Rss>> GetRssesAsync();
        Task CreateRssAsync(Rss rss);
        Task EditRssAsync(Rss rss);
        Task DeleteRssAsync(int id);
    }
}
