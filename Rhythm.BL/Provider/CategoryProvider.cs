using System.Collections.Generic;
using System.Threading.Tasks;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.BL.Interfaces;

namespace Rhythm.BL.Provider
{
    public class CategoryProvider : ICategoryProvider
    {
        private ICategoryRepository _categoryRepository;
        
        public CategoryProvider(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task ChangeCategoryAsync(Category category)
        {
            await _categoryRepository.ChangeCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            await _categoryRepository.DeleteCategoryAsync(category);
        }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            return await _categoryRepository.GetCategoryAsync();
        }
    }
}
