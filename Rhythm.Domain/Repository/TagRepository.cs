using System.Data.Entity;
using System.Threading.Tasks;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.Domain.Context;
using System.Collections.Generic;

namespace Rhythm.Domain.Repository
{
    public class TagRepository : ITagRepository
    {
        DogCodingContext _db;
        public TagRepository(DogCodingContext db)
        {
            _db = db;
        }

        public async Task AddTagAsync(Tag tag)
        {
            _db.Tags.Add(tag);
            await _db.SaveChangesAsync();
        }

        public async Task ChangeTagAsync(Tag tag)
        {
            _db.Entry(tag).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteTagAsync(Tag tag)
        {

            _db.Tags.Remove(tag);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _db.Tags.ToListAsync();
        }
    }
}
