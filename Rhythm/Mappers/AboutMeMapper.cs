using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rhythm.Domain.Model;
using Rhythm.Models;
using Rhythm.Areas.ChiefAdmin.Models;
using AutoMapper;

namespace Rhythm.Mappers
{
    public class AboutMeMapper
    {
        public CommonUserViewModel ToCommonUserViewModel(ChiefUser user, Portfolio portfolio)
        {
            IMapper mapperPortfolio = MappingConfig.MapperConfigPortfolio.CreateMapper();
            PortfolioViewModel portfolioViewModel = mapperPortfolio.Map<PortfolioViewModel>(portfolio);

            IMapper mapperUser = MappingConfig.MapperConfigChiefUser.CreateMapper();
            ChiefUserViewModel userViewModel = mapperUser.Map<ChiefUserViewModel>(user);


            return new CommonUserViewModel() { PortfolioViewModel = portfolioViewModel , UserViewModel = userViewModel };
        }
    }
}