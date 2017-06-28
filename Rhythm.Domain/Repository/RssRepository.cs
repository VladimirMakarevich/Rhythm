using Rhythm.Domain.Context;
using Rhythm.Domain.Entities;
using Rhythm.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository
{
    public class RssRepository : IRssRepository, IRepository
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

        public async Task CreateRssAsync(Rss rss)
        {
            _db.Rsses.Add(rss);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRssAsync(int id)
        {
            _db.Projects.Remove(project);
            await _db.SaveChangesAsync();
        }

        public async Task EditRssAsync(Rss rss)
        {
            _db.Entry(rss).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rss>> GetRssesAsync()
        {
            return await _db.Rsses.ToListAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
