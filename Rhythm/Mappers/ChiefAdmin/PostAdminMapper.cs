using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rhythm.Domain.Entities;
using Rhythm.Models;
using AutoMapper;
using Rhythm.Models.RecentViewModel;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class PostAdminMapper
    {
        private IMapper _mapper;

        public PostAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}