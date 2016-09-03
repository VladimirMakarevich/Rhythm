using System.Collections.Generic;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System.Linq;
using System.Data.Entity;

namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {
        public IQueryable<Tag> Tag
        {
            get { return context.Tags; }
        }

        public void AddTag(Tag tag)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Tags.Add(tag);
                    context.SaveChanges();

                    contextDb.Commit();
                }
                catch (System.Exception)
                {
                    //TODO: Nlog
                }
            }
        }

        public void ChangeTag(Tag tag)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Entry(tag).State = EntityState.Modified;
                    context.SaveChanges();

                    contextDb.Commit();
                }
                catch (System.Exception)
                {
                    //TODO: Nlog

                }
            }
        }

        public void DeleteTag(Tag tag)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Tags.Remove(tag);
                    context.SaveChanges();
                    contextDb.Commit();
                }
                catch (System.Exception)
                {
                    //TODO: Nlog
                }
            }
        }
    }
}
