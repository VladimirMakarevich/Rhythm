using Rhythm.Domain.Context;
using Rhythm.Domain.Repository.Interfaces;
using System;

namespace Rhythm.Domain.Repository
{
    public class RssRepository : IRssRepository, IRepository
    {
        DogCodingContext _db;
        public RssRepository(DogCodingContext db)
        {
            _db = db;
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
