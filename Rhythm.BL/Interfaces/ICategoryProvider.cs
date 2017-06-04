using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Interfaces
{
    public interface ICategoryProvider
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        IEnumerable<Category> GetCategories();
        Task AddCategoryAsync(Category category);
        Task ChangeCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
        Task<Category> GetCategoryAsync(int id);
    }
}
