using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class PortfolioAdminMapper
    {
        private IMapper _mapper;

        public PortfolioAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<PortfolioAdminViewModel> ToListPortfolioViewModel(IEnumerable<Portfolio> portfolio)
        {
            return portfolio.Select(ToPortfolioViewModel).ToList();
        }

        public PortfolioAdminViewModel ToPortfolioViewModel(Portfolio portfolio)
        {
            return _mapper.Map<Portfolio, PortfolioAdminViewModel>(portfolio);
        }

        public Portfolio ToPortfolio(PortfolioAdminViewModel portfolioViewModel)
        {
            return _mapper.Map<PortfolioAdminViewModel, Portfolio>(portfolioViewModel);
        }
    }
}