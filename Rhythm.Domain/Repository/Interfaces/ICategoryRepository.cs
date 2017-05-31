using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoryAsync();
        Task AddCategoryAsync(Category category);
        Task ChangeCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
    }
}
