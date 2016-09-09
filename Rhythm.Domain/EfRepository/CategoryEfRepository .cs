using Rhythm.Domain.Model;
using System.Linq;
using System.Data.Entity;
using System;
using System.Threading.Tasks;

namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {
        public IQueryable<Category> Category
        {
            get { return context.Categories; }
        }
        public async Task<string> AddCategoryAsync(Category category)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Categories.Add(category);
                    await context.SaveChangesAsync();

                    contextDb.Commit();
                }
                catch (System.Exception ex)
                {
                    string src = String.Format("Error AddCategory: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
                return null;
            }
        }

        public async Task<string> ChangeCategoryAsync(Category category)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Entry(category).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    contextDb.Commit();
                }
                catch (System.Exception ex)
                {
                    string src = String.Format("Error ChangeCategory: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
                return null;
            }
        }

        public async Task<string> DeleteCategoryAsync(Category category)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Categories.Remove(category);
                    await context.SaveChangesAsync();
                    contextDb.Commit();
                }
                catch (System.Exception ex)
                {
                    string src = String.Format("Error DeleteCategory: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
                return null;
            }
        }
    }
}
