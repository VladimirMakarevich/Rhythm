using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class UserMapper
    {
        private IMapper _mapper;

        public UserMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        private PortfolioMapper _porfolioMapper;
        IPortfolioRepository _portfolioRepository;
        public UserMapper(PortfolioMapper porfolioMapper, IPortfolioRepository portfolioRepository)
        {
            _porfolioMapper = porfolioMapper;
            _portfolioRepository = portfolioRepository;
        }

        public List<ChiefUserAdminViewModel> ToListUsersViewModel(List<ChiefUser> users)
        {
            var usersListViewModel = users.Select(ToUserViewModel).ToList();
            //IMapper mapper = MappingConfig.MapperConfigChiefUser.CreateMapper();
            //List<ChiefUserViewModel> usersListViewModel = mapper.Map<List<ChiefUserViewModel>>(users);

            return usersListViewModel;
        }

        public ChiefUserAdminViewModel ToUserViewModel(ChiefUser user)
        {
            IMapper mapper = MappingConfig.MapperConfigChiefUser.CreateMapper();
            ChiefUserAdminViewModel userViewModel = mapper.Map<ChiefUserAdminViewModel>(user);

            var portfolio = _portfolioRepository.GetPortfolio(user.PortfolioID);
            if (portfolio != null)
            {
                var portfolioViewModel = _porfolioMapper.ToPortfolioViewModel(portfolio);
                userViewModel.PortfolioViewModel = portfolioViewModel;
            }

            return userViewModel;
        }

        public ChiefUser ToChiefUser(ChiefUserAdminViewModel userViewModel)
        {
            IMapper mapper = MappingConfig.MapperConfigChiefUser.CreateMapper();
            ChiefUser user = mapper.Map<ChiefUser>(userViewModel);

            return user;
        }
    }
}