using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Rhythm.Domain.Entities;
using Rhythm.Models.RecentViewModel;

namespace Rhythm.Mappers
{
    public class TagMapper
    {
        private IMapper _mapper;

        public TagMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<TagRecentViewModel> ToTagsRecentViewModel(IEnumerable<Tag> tag)
        {
            return tag.Select(ToTagRecentViewModel).ToList();
        }

        public TagRecentViewModel ToTagRecentViewModel(Tag tag)
        {
            return _mapper.Map<Tag, TagRecentViewModel>(tag);
        }
    }
}