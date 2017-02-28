using Rhythm.Domain.Model;
using System.Linq;
using System.Data.Entity;
using System;
using System.Threading.Tasks;

namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {
        public IQueryable<Tag> Tag
        {
            get { return db.Tags; }
        }

        public async Task<string> AddTagAsync(Tag tag)
        {
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    db.Tags.Add(tag);
                    await db.SaveChangesAsync();

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

        public async Task<string> ChangeTagAsync(Tag tag)
        {
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    db.Entry(tag).State = EntityState.Modified;
                    await db.SaveChangesAsync();

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

        public async Task<string> DeleteTagAsync(Tag tag)
        {
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    db.Tags.Remove(tag);
                    await db.SaveChangesAsync();
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
