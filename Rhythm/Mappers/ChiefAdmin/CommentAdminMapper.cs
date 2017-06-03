using System.Collections.Generic;
using System.Linq;
using Rhythm.Domain.Entities;
using AutoMapper;
using Rhythm.Models;
using Rhythm.BL.Models;
using System;
using Rhythm.Models.RecentViewModel;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class CommentAdminMapper
    {
        private IMapper _mapper;

        public CommentAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}