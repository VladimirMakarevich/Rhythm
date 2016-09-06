using System.Collections.Generic;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System.Linq;
using System.Data.Entity;
using System;

namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {
        public IQueryable<Category> Category
        {
            get { return context.Categories; }
        }
        public string AddCategory(Category category)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Categories.Add(category);
                    context.SaveChanges();

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

        public string ChangeCategory(Category category)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Entry(category).State = EntityState.Modified;
                    context.SaveChanges();

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

        public string DeleteCategory(Category category)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
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
