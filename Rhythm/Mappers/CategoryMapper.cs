using AutoMapper;
using Rhythm.Domain.Entities;
using Rhythm.Models.RecentViewModel;
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
        
        public List<CategoryRecentViewModel> ToCategoriesRecentViewModel(IEnumerable<Category> category)
        {
            return category.Select(ToCategoryRecentViewModel).ToList();
        }

        public CategoryRecentViewModel ToCategoryRecentViewModel(Category category)
        {
            return _mapper.Map<Category, CategoryRecentViewModel>(category);
        }
    }
}