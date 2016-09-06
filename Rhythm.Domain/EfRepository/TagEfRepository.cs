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
        public IQueryable<Tag> Tag
        {
            get { return context.Tags; }
        }

        public string AddTag(Tag tag)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Tags.Add(tag);
                    context.SaveChanges();

                    contextDb.Commit();
                }
                catch (System.Exception ex)
                {
                    string src = String.Format("Error AddTag: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
                return null;
            }
        }

        public string ChangeTag(Tag tag)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Entry(tag).State = EntityState.Modified;
                    context.SaveChanges();

                    contextDb.Commit();
                }
                catch (System.Exception ex)
                {
                    string src = String.Format("Error ChangeTag: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
                return null;
            }
        }

        public string DeleteTag(Tag tag)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Tags.Remove(tag);
                    context.SaveChanges();
                    contextDb.Commit();
                }
                catch (System.Exception ex)
                {
                    string src = String.Format("Error DeleteTag: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
                return null;
            }
        }
    }
}
