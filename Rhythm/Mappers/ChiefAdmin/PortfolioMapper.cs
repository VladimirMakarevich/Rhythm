using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using System.Collections.Generic;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class PortfolioMapper
    {
        private IMapper _mapper;

        public PortfolioMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<PortfolioAdminViewModel> ToListPortfolioViewModel(List<Portfolio> portfolio)
        {
            IMapper mapper = MappingConfig.MapperConfigPortfolio.CreateMapper();
            var portfolioListViewModel = mapper.Map<List<PortfolioAdminViewModel>>(portfolio);

            return portfolioListViewModel;
        }

        public PortfolioAdminViewModel ToPortfolioViewModel(Portfolio portfolio)
        {
            IMapper mapper = MappingConfig.MapperConfigPortfolio.CreateMapper();
            var portfolioViewModel = mapper.Map<PortfolioAdminViewModel>(portfolio);

            return portfolioViewModel;
        }

        public Portfolio ToPortfolio(PortfolioAdminViewModel portfolioViewModel)
        {
            IMapper mapper = MappingConfig.MapperConfigPortfolio.CreateMapper();
            var portfolio = mapper.Map<Portfolio>(portfolioViewModel);

            return portfolio;
        }
    }
}