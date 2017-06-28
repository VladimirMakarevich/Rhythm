using Rhythm.BL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rhythm.Domain.Entities;
using Rhythm.Domain.UnitOfWork;

namespace Rhythm.BL.Provider
{
    public class RssProvider : IRssProvider
    {
        private IUnitOfWork _uow;

        public RssProvider(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task CreateRssAsync(Rss rss)
        {
            _uow.Rss.CreateRssAsync(rss);

            await _uow.SaveAsync();
        }

        public async Task DeleteRssAsync(int id)
        {
            var rss = await GetRssAsync(id);
            _uow.Rss.DeleteRssAsync(rss);

            await _uow.SaveAsync();
        }

        public async Task EditRssAsync(Rss rss)
        {
            _uow.Rss.EditRssAsync(rss);

            await _uow.SaveAsync();
        }

        public async Task<Rss> GetRssAsync(int id)
        {
            return await _uow.Rss.GetRssAsync(id);
        }

        public async Task<IEnumerable<Rss>> GetRssesAsync()
        {
            return await _uow.Rss.GetRssesAsync();
        }
    }
}
