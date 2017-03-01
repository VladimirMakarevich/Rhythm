using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhythm.Domain.Abstract
{
    public interface IPortfolioRepository
    {
        IQueryable<Portfolio> GetPortfolio { get; }
        Task<List<Portfolio>> GetListPortfolioAsync();
        Task<Portfolio> GetPortfolioAsync(int? portfolio);
        Task CreatePortfolioAsync(Portfolio portfolio);
        Task EditPortfolioAsync(Portfolio portfolio);
        Task DeletePortfolioAsync(int id);
    }
}
