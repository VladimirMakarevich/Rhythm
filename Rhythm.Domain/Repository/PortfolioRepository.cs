using Rhythm.Domain.Model;
using System.Linq;
using System.Data.Entity;
using System;
using System.Threading.Tasks;
using Rhythm.Domain.Abstract;
using System.Collections.Generic;

namespace Rhythm.Domain.Repository
{
    public class PortfolioRepository : ContextDb, IPortfolioRepository
    {
        public IQueryable<Portfolio> GetPortfolioProperty
        {
            get
            {
                return db.Portfolios;
            }
        }

        public async Task CreatePortfolioAsync(Portfolio portfolio)
        {
            db.Portfolios.Add(portfolio);
            await db.SaveChangesAsync();
        }

        public async Task DeletePortfolioAsync(int id)
        {
            var portfolio = await db.Portfolios.FindAsync(id);
            db.Portfolios.Remove(portfolio);
            await db.SaveChangesAsync();
        }

        public async Task EditPortfolioAsync(Portfolio portfolio)
        {
            db.Entry(portfolio).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<List<Portfolio>> GetListPortfolioAsync()
        {
            return await db.Portfolios.ToListAsync();
        }

        public async Task<Portfolio> GetPortfolioAsync(int? portfolio)
        {
            return await db.Portfolios.FindAsync(portfolio);
        }

        public Portfolio GetPortfolio(int? portfolio)
        {
            return db.Portfolios.Find(portfolio);
        }
    }
}
