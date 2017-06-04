using Rhythm.Domain.Entities;
using System.Data.Entity;
using System.Threading.Tasks;
using Rhythm.Domain.Repository.Interfaces;
using System.Collections.Generic;
using Rhythm.Domain.Context;
using System;
using System.Linq;

namespace Rhythm.Domain.Repository
{
    public class CategoryRepository : ICategoryRepository, IRepository
    {
        DogCodingContext _db;
        public CategoryRepository(DogCodingContext db)
        {
            _db = db;
        }

        public async Task AddCategoryAsync(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
        }

        public async Task ChangeCategoryAsync(Category category)
        {
            _db.Entry(category).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _db.Categories.FirstOrDefaultAsync(i => i.Id == id);
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories;
        }
    }
}
