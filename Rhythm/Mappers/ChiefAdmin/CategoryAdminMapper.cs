using AutoMapper;
using Rhythm.Domain.Entities;
using Rhythm.Models.RecentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class CategoryAdminMapper
    {
        private IMapper _mapper;

        public CategoryAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}