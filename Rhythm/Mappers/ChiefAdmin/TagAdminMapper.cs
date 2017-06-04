using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Rhythm.Domain.Entities;
using Rhythm.Models.RecentViewModel;
using System;
using Rhythm.Areas.ChiefAdmin.Models;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class TagAdminMapper
    {
        private IMapper _mapper;

        public TagAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<TagAdminViewModel> ToTagsViewModel(IEnumerable<Tag> tags)
        {
            return tags.Select(ToTagViewModel).ToList();
        }

        public List<TagAdminViewModel> ToTagsViewModelByPostTag(IEnumerable<Tag> tags, HashSet<int> postTag)
        {
            var tagViewModel = new List<TagAdminViewModel>();
            foreach (var tag in tags)
            {
                tagViewModel.Add(new TagAdminViewModel
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Assigned = postTag.Contains(tag.Id)
                });
            }

            return tagViewModel;
        }

        public TagAdminViewModel ToTagViewModel(Tag tag)
        {
            return _mapper.Map<Tag, TagAdminViewModel>(tag);
        }

        public Tag ToTag(TagAdminViewModel tagViewModel)
        {
            return _mapper.Map<TagAdminViewModel, Tag>(tagViewModel);
        }
    }
}