using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Entities;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class UserAdminMapper
    {
        private IMapper _mapper;

        public UserAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ChiefUserAdminViewModel> ToListUsersViewModel(List<ChiefUser> users)
        {
            var usersListViewModel = users.Select(ToUserViewModel).ToList();
            //IMapper mapper = MappingConfig.MapperConfigChiefUser.CreateMapper();
            //List<ChiefUserViewModel> usersListViewModel = mapper.Map<List<ChiefUserViewModel>>(users);

            return usersListViewModel;
        }

        public ChiefUserAdminViewModel ToUserViewModel(ChiefUser user, PortfolioAdminViewModel portfolioAdminViewModel)
        {
            var userViewModel = _mapper.Map<ChiefUser, ChiefUserAdminViewModel>(user);
            userViewModel.PortfolioViewModel = portfolioAdminViewModel;

            //var portfolio = _portfolioRepository.GetPortfolio(user.PortfolioId);
            //if (portfolio != null)
            //{
            //    var portfolioViewModel = _porfolioMapper.ToPortfolioViewModel(portfolio);
            //    userViewModel.PortfolioViewModel = portfolioViewModel;
            //}

            return userViewModel;
        }

        public ChiefUser ToChiefUser(ChiefUserAdminViewModel userViewModel)
        {
            return _mapper.Map<ChiefUserAdminViewModel, ChiefUser>(userViewModel);
        }
    }
}