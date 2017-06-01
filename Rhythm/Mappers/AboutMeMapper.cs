using Rhythm.Models;
using Rhythm.Areas.ChiefAdmin.Models;
using AutoMapper;
using Rhythm.Domain.Entities;

namespace Rhythm.Mappers
{
    public class AboutMeMapper
    {
        public CommonUserViewModel ToChiefUserViewModel(ChiefUser user, Portfolio portfolio)
        {
            IMapper mapperPortfolio = MappingConfig.MapperConfigPortfolio.CreateMapper();
            PortfolioViewModel portfolioViewModel = mapperPortfolio.Map<PortfolioViewModel>(portfolio);

            IMapper mapperUser = MappingConfig.MapperConfigChiefUser.CreateMapper();
            ChiefUserViewModel userViewModel = mapperUser.Map<ChiefUserViewModel>(user);

            return new CommonUserViewModel() { PortfolioViewModel = portfolioViewModel , UserViewModel = userViewModel };
        }
    }
}