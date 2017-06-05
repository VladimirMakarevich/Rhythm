using System.Collections.Generic;
using System.Threading.Tasks;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.BL.Interfaces;
using System;
using Rhythm.Domain.UnitOfWork;

namespace Rhythm.BL.Provider
{
    public class CategoryProvider : ICategoryProvider
    {
        private IUnitOfWork _uow;

        public CategoryProvider(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _uow.Category.AddCategoryAsync(category);
        }

        public async Task ChangeCategoryAsync(Category category)
        {
            await _uow.Category.ChangeCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            await _uow.Category.DeleteCategoryAsync(category);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _uow.Category.GetCategories();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _uow.Category.GetCategoriesAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _uow.Category.GetCategoryAsync(id);
        }
    }
}
