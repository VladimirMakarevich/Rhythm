using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhythm.BL.Interfaces;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.Domain.UnitOfWork;

namespace Rhythm.BL.Provider
{
    public class TagProvider : ITagProvider
    {
        private IUnitOfWork _uow;

        public TagProvider(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddTagAsync(Tag tag)
        {
            await _uow.Tag.AddTagAsync(tag);
        }

        public async Task ChangeTagAsync(Tag tag)
        {
            await _uow.Tag.ChangeTagAsync(tag);
        }

        public async Task DeleteTagAsync(Tag tag)
        {
            await _uow.Tag.DeleteTagAsync(tag);
        }

        public async Task<Tag> GetTagAsync(int id)
        {
            return await _uow.Tag.GetTagAsync(id);
        }

        public IEnumerable<Tag> GetTags()
        {
            return _uow.Tag.GetTags();
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _uow.Tag.GetTagsAsync();
        }

        public async Task<List<Tag>> GetTagsByIdAsync(int[] ids)
        {
            List<Tag> tags = new List<Tag>();

            foreach (var id in ids)
            {
                tags.Add(await _uow.Tag.GetTagAsync(id));
            }

            return tags;
        }
    }
}
