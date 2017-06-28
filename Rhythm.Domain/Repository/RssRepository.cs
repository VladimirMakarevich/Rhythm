using Rhythm.Domain.Context;
using Rhythm.Domain.Entities;
using Rhythm.Domain.Repository.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository
{
    public class RssRepository : IRssRepository
    {
        DogCodingContext _db;

        public RssRepository(DogCodingContext db)
        {
            _db = db;
        }

        public async Task<Rss> GetRssAsync(int id)
        {
            return await _db.Rsses.FirstOrDefaultAsync(r => r.Id == id);
        }

        public void CreateRssAsync(Rss rss)
        {
            _db.Rsses.Add(rss);
            //await _db.SaveChangesAsync();
        }

        public void DeleteRssAsync(Rss rss)
        {
            _db.Rsses.Remove(rss);
            //await _db.SaveChangesAsync();
        }

        public void EditRssAsync(Rss rss)
        {
            _db.Entry(rss).State = EntityState.Modified;
            //await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rss>> GetRssesAsync()
        {
            return await _db.Rsses.ToListAsync();
        }
    }
}
