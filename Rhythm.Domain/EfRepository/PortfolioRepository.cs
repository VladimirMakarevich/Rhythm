using Rhythm.Domain.Model;
using System.Linq;
using System.Data.Entity;
using System;
using System.Threading.Tasks;
using Rhythm.Domain.Abstract;

namespace Rhythm.Domain.EfRepository
{
    public class PortfolioRepository : ContextDb, IPortfolioRepository
    {
        public IQueryable<Portfolio> GetPortfolio
        {
            get { return db.Portfolios; }
        }
    }
}
