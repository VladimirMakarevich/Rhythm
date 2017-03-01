using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Mappers
{
    public class PortfolioMapper
    {
        public PortfolioMapper()
        {

        }

        public List<PortfolioViewModel> ToListPortfolioViewModel(List<Portfolio> portfolio)
        {
            IMapper mapper = MappingConfig.MapperConfigPortfolio.CreateMapper();
            var portfolioListViewModel = mapper.Map<List<PortfolioViewModel>>(portfolio);

            return portfolioListViewModel;
        }

        public PortfolioViewModel ToPortfolioViewModel(Portfolio portfolio)
        {
            IMapper mapper = MappingConfig.MapperConfigPortfolio.CreateMapper();
            var portfolioViewModel = mapper.Map<PortfolioViewModel>(portfolio);

            return portfolioViewModel;
        }

        public Portfolio ToPortfolio(PortfolioViewModel portfolioViewModel)
        {
            IMapper mapper = MappingConfig.MapperConfigPortfolio.CreateMapper();
            var portfolio = mapper.Map<Portfolio>(portfolioViewModel);

            return portfolio;
        }
    }
}