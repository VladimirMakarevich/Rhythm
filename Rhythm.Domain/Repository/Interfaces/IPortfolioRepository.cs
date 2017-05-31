using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<IEnumerable<Portfolio>> GetPortfoliosAsync();
        Task<List<Portfolio>> GetListPortfolioAsync();
        Task<Portfolio> GetPortfolioAsync(int portfolio);
        Portfolio GetPortfolio(int portfolio);
        Task CreatePortfolioAsync(Portfolio portfolio);
        Task EditPortfolioAsync(Portfolio portfolio);
        Task DeletePortfolioAsync(int id);
    }
}
