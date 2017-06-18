using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface IRssRepository
    {
        Task<Rss> GetRss(int id);
        Task<IEnumerable<Rss>> GetRsses();
    }
}
