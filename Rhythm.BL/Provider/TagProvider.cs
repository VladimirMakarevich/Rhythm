using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhythm.BL.Interfaces;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Entities;

namespace Rhythm.BL.Provider
{
    public class TagProvider : ITagProvider
    {
        private ITagRepository _tagRepository;

        public TagProvider(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task AddTagAsync(Tag tag)
        {
            await _tagRepository.AddTagAsync(tag);
        }

        public async Task ChangeTagAsync(Tag tag)
        {
            await _tagRepository.ChangeTagAsync(tag);
        }

        public async Task DeleteTagAsync(Tag tag)
        {
            await _tagRepository.DeleteTagAsync(tag);
        }

        public async Task<Tag> GetTagAsync(int id)
        {
            return await _tagRepository.GetTagAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _tagRepository.GetTagsAsync();
        }
    }
}
