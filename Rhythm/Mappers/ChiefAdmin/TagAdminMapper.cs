using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Rhythm.Domain.Entities;
using Rhythm.Models.RecentViewModel;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class TagAdminMapper
    {
        private IMapper _mapper;

        public TagAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}