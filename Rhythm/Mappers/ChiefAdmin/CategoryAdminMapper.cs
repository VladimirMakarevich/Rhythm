using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Entities;
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

        public List<CategoryAdminViewModel> ToCategoriesViewModel(IEnumerable<Category> categories)
        {
            return categories.Select(ToCategoryViewModel).ToList();
        }

        public CategoryAdminViewModel ToCategoryViewModel(Category category)
        {
            return _mapper.Map<Category, CategoryAdminViewModel>(category);
        }

        public Category ToCategory(CategoryAdminViewModel categoryViewModel)
        {
            return _mapper.Map<CategoryAdminViewModel, Category>(categoryViewModel);
        }
    }
}