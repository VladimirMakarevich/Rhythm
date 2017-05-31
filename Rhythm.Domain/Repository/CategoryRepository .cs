using Rhythm.Domain.Model;
using System.Data.Entity;
using System.Threading.Tasks;
using Rhythm.Domain.Repository.Interfaces;
using System.Collections.Generic;

namespace Rhythm.Domain.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task AddCategoryAsync(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
        }

        public async Task ChangeCategoryAsync(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            return await db.Categories.ToListAsync();
        }
    }
}
