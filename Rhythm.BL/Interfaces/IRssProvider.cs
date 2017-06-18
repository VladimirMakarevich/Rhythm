using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Interfaces
{
    public interface IRssProvider
    {
        Task<Rss> GetRss(int id);
        Task<IEnumerable<Rss>> GetRsses();
    }
}
