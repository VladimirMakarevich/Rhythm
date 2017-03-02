using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rhythm.Domain.Model;
using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;

namespace Rhythm.Areas.ChiefAdmin.Mappers
{
    public class UserMapper
    {
        public UserMapper()
        {

        }

        public List<ChiefUserViewModel> ToListUsersViewModel(List<ChiefUser> users)
        {
            IMapper mapper = MappingConfig.MapperConfigChiefUser.CreateMapper();
            var usersListViewModel = mapper.Map<List<ChiefUserViewModel>>(users);

            return usersListViewModel;
        }

        public ChiefUserViewModel ToUserViewModel(ChiefUser user)
        {
            IMapper mapper = MappingConfig.MapperConfigChiefUser.CreateMapper();
            var userViewModel = mapper.Map<ChiefUserViewModel>(user);

            return userViewModel;
        }

        public ChiefUser ToChiefUser(ChiefUserViewModel userViewModel)
        {
            IMapper mapper = MappingConfig.MapperConfigChiefUser.CreateMapper();
            var user = mapper.Map<ChiefUser>(userViewModel);

            return user;
        }
    }
}