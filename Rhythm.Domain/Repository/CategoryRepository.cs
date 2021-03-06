﻿using Rhythm.Domain.Entities;
using System.Data.Entity;
using System.Threading.Tasks;
using Rhythm.Domain.Repository.Interfaces;
using System.Collections.Generic;
using Rhythm.Domain.Context;

namespace Rhythm.Domain.Repository
{
    public class CategoryRepository : ICategoryRepository
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

        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories;
        }
    }
}
