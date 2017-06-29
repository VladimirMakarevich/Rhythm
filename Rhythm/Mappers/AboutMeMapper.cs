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
            var portfolioViewModel = _mapper.Map<Portfolio, PortfolioAdminViewModel>(portfolio);
            var userViewModel = _mapper.Map<ChiefUser, ChiefUserAdminViewModel>(user);

            return new CommonUserViewModel() { PortfolioViewModel = portfolioViewModel , UserViewModel = userViewModel, HeaderViewModel = GetHeader() };
        }

        private HeaderViewModel GetHeader()
        {
            return new HeaderViewModel
            {
                Title = "About Me",
                Text = "",
                FirstTagWord = "C#",
                SecondTagWord = ".NET MVC",
                ThirdTagWord = "WEB"
            };
        }
    }
}