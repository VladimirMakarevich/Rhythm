using AutoMapper;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class MapperCategoryConfig : IMapperCategory
    {
        static MapperCategoryConfig()
        { 
            Mapper.Initialize(t => t.CreateMap<Category, CategoryViewModel>());
            Mapper.Initialize(t => t.CreateMap<CategoryViewModel, Category>());
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
    public class MapperTagConfig : IMapperTag
    {
        static MapperTagConfig()
        {
            Mapper.Initialize(t => t.CreateMap<Tag, TagViewModel>());
            Mapper.Initialize(t => t.CreateMap<TagViewModel, Tag>());
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}
