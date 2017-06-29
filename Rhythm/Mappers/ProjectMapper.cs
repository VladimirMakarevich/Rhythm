using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Mappers
{
    public class ProjectMapper
    {
        private IMapper _mapper;

        public ProjectMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

    }
}