using Rhythm.BL.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.Domain.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Provider
{
    public class PortfolioProvider : IPortfolioProvider
    {
        private IPortfolioRepository _portfolioRepository;

        public PortfolioProvider(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task CreatePortfolioAsync(Portfolio portfolio)
        {
            await _portfolioRepository.CreatePortfolioAsync(portfolio);
        }

        public async Task DeletePortfolioAsync(int id)
        {
            var portfolio = await _portfolioRepository.GetPortfolioAsync(id);

            await _portfolioRepository.DeletePortfolioAsync(portfolio);
        }

        public async Task EditPortfolioAsync(Portfolio portfolio)
        {
            await _portfolioRepository.EditPortfolioAsync(portfolio);
        }

        public async Task<List<Portfolio>> GetListPortfolioAsync()
        {
            return await _portfolioRepository.GetListPortfolioAsync();
        }

        public async Task<Portfolio> GetPortfolioAsync(int portfolio)
        {
            return await _portfolioRepository.GetPortfolioAsync(portfolio);
        }

        public async Task<Portfolio> GetPortfolioByUserAsync(int userId)
        {
            return await _portfolioRepository.GetPortfolioByUserAsync(userId);
        }

        public async Task<IEnumerable<Portfolio>> GetPortfoliosAsync()
        {
            return await _portfolioRepository.GetPortfoliosAsync();
        }
    }
}
