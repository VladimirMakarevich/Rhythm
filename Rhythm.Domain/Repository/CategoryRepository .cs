using Rhythm.Domain.Model;
using System.Linq;
using System.Data.Entity;
using System;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository
{
    public class CategoryRepository
    {
        public IQueryable<Category> Category
        {
            get { return db.Categories; }
        }
        public async Task<string> AddCategoryAsync(Category category)
        {
            try
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                string src = String.Format("Error AddCategory: {0}", ex.Message);
                return src;
            }
            return null;

        }

        public async Task<string> ChangeCategoryAsync(Category category)
        {
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    db.Entry(category).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    contextDb.Commit();
                }
                catch (System.Exception ex)
                {
                    string src = String.Format("Error ChangeCategory: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
            }
            return null;
        }

        public async Task<string> DeleteCategoryAsync(Category category)
        {
            try
            {
                db.Categories.Remove(category);
                await db.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                string src = String.Format("Error DeleteCategory: {0}", ex.Message);
                return src;
            }
            return null;
        }
    }
}
