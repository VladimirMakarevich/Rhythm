using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Mappers
{
    public class TagMapper
    {
        private IMapper _mapper;

        public TagMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}