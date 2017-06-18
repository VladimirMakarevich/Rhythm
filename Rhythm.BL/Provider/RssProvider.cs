using Rhythm.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<Rss> GetRss(int id)
        {
            return await _uow.Rss.GetRss(id);
        }

        public async Task<IEnumerable<Rss>> GetRsses()
        {
            return await _uow.Rss.GetRsses();
        }
    }
}
