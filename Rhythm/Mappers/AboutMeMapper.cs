using Rhythm.Models;
using Rhythm.Areas.ChiefAdmin.Models;
using AutoMapper;
using Rhythm.Domain.Entities;

namespace Rhythm.Mappers
{
    public class AboutMeMapper
    {
        private IMapper _mapper;

        public AboutMeMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CommonUserViewModel ToChiefUserViewModel(ChiefUser user, Portfolio portfolio)
        {
            IMapper mapperPortfolio = MappingConfig.MapperConfigPortfolio.CreateMapper();
            PortfolioAdminViewModel portfolioViewModel = mapperPortfolio.Map<PortfolioAdminViewModel>(portfolio);

            IMapper mapperUser = MappingConfig.MapperConfigChiefUser.CreateMapper();
            ChiefUserAdminViewModel userViewModel = mapperUser.Map<ChiefUserAdminViewModel>(user);

            return new CommonUserViewModel() { PortfolioViewModel = portfolioViewModel , UserViewModel = userViewModel };
        }
    }
}