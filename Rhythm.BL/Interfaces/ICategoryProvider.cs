using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Interfaces
{
    public interface ICategoryProvider
    {
        Task<IEnumerable<Category>> GetCategoryAsync();
        Task AddCategoryAsync(Category category);
        Task ChangeCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
    }
}
