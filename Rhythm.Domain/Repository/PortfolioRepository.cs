using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.Domain.Context;
using System;

namespace Rhythm.Domain.Repository
{
    public class PortfolioRepository : IPortfolioRepository, IRepository
    {
        DogCodingContext _db;
        public PortfolioRepository(DogCodingContext db)
        {
            _db = db;
        }

        public async Task CreatePortfolioAsync(Portfolio portfolio)
        {
            _db.Portfolios.Add(portfolio);
            await _db.SaveChangesAsync();
        }

        public async Task DeletePortfolioAsync(Portfolio portfolio)
        {
            _db.Portfolios.Remove(portfolio);
            await _db.SaveChangesAsync();
        }

        public async Task EditPortfolioAsync(Portfolio portfolio)
        {
            _db.Entry(portfolio).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<List<Portfolio>> GetListPortfolioAsync()
        {
            return await _db.Portfolios.ToListAsync();
        }

        public async Task<Portfolio> GetPortfolioAsync(int portfolio)
        {
            return await _db.Portfolios.FindAsync(portfolio);
        }

        public async Task<IEnumerable<Portfolio>> GetPortfoliosAsync()
        {
            return await _db.Portfolios.ToListAsync();
        }

        public async Task<Portfolio> GetPortfolioByUserAsync(int userId)
        {
            return await _db.Portfolios.FirstOrDefaultAsync(user => user.ChiefUserId == userId);
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
