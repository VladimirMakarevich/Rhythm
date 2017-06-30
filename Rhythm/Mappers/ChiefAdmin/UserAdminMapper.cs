using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Entities;
using System.Threading.Tasks;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class UserAdminMapper
    {
        private IMapper _mapper;

        public UserAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ChiefUserAdminViewModel> ToListUsersViewModel(IEnumerable<ChiefUser> users)
        {
            return users.Select(ToUserViewModel).ToList();

        }

        public ChiefUserAdminViewModel ToUserViewModel(ChiefUser user)
        {
            return _mapper.Map<ChiefUser, ChiefUserAdminViewModel>(user);
        }

        public ChiefUser ToChiefUser(ChiefUserAdminViewModel userViewModel, string imagePath)
        {
            if (imagePath != null)
            {
                userViewModel.ImagePath = imagePath;
            }

            return _mapper.Map<ChiefUserAdminViewModel, ChiefUser>(userViewModel);
        }
    }
}