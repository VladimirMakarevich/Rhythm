using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task AddCategoryAsync(Category category);
        Task ChangeCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
        Task<Category> GetCategoryAsync(int id);
    }
}
