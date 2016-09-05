using System.Collections.Generic;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System.Linq;
using System.Data.Entity;

namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {
        public IQueryable<Category> Category
        {
            get { return context.Categories; }
        }
        public void AddCategory(Category category)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Categories.Add(category);
                    context.SaveChanges();

                    contextDb.Commit();
                }
                catch (System.Exception)
                {
                    //TODO: Nlog
                    contextDb.Rollback();
                }
            }
        }

        public void ChangeCategory(Category category)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Entry(category).State = EntityState.Modified;
                    context.SaveChanges();

                    contextDb.Commit();
                }
                catch (System.Exception)
                {
                    //TODO: Nlog
                    contextDb.Rollback();
                }
            }
        }

        public void DeleteCategory(Category category)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                    contextDb.Commit();
                }
                catch (System.Exception)
                {
                    //TODO: Nlog
                    contextDb.Rollback();
                }
            }
        }
    }
}
