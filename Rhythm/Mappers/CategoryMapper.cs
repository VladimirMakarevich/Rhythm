using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Mappers
{
    public class CategoryMapper
    {
        private IMapper _mapper;

        public CategoryMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}