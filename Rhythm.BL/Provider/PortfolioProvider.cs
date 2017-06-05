using Rhythm.BL.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Provider
{
    public class PortfolioProvider : IPortfolioProvider
    {
        private IUnitOfWork _uow;

        public PortfolioProvider(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task CreatePortfolioAsync(Portfolio portfolio)
        {
            await _uow.Portfolio.CreatePortfolioAsync(portfolio);
        }

        public async Task DeletePortfolioAsync(int id)
        {
            var portfolio = await _uow.Portfolio.GetPortfolioAsync(id);

            await _uow.Portfolio.DeletePortfolioAsync(portfolio);
        }

        public async Task EditPortfolioAsync(Portfolio portfolio)
        {
            await _uow.Portfolio.EditPortfolioAsync(portfolio);
        }

        public async Task<List<Portfolio>> GetListPortfolioAsync()
        {
            return await _uow.Portfolio.GetListPortfolioAsync();
        }

        public async Task<Portfolio> GetPortfolioAsync(int portfolio)
        {
            return await _uow.Portfolio.GetPortfolioAsync(portfolio);
        }

        public async Task<Portfolio> GetPortfolioByUserAsync(int userId)
        {
            return await _uow.Portfolio.GetPortfolioByUserAsync(userId);
        }

        public async Task<IEnumerable<Portfolio>> GetPortfoliosAsync()
        {
            return await _uow.Portfolio.GetPortfoliosAsync();
        }
    }
}
