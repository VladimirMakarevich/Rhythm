using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class ContentAdminMapper
    {
        private IMapper _mapper;

        public ContentAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ContentAdminViewModel ToContentViewModel(List<CategoryAdminViewModel> categoriesViewModel, 
            List<TagAdminViewModel> tagsViewModel, 
            List<PostAdminViewModel> postsViewModel,
            List<CommentAdminViewModel> commentsViewModel)
        {
            return new ContentAdminViewModel
            {
                Posts = postsViewModel.OrderBy(p => p.Id)
                .Take(15).ToArray().Reverse(),

                Categories = categoriesViewModel.OrderBy(c => c.Id)
                .Take(15).ToArray().Reverse(),

                Tags = tagsViewModel.OrderBy(t => t.Id)
                .Take(15).ToArray().Reverse(),

                Comments = commentsViewModel.OrderBy(c => c.Id)
                .Take(15).ToArray().Reverse()
            };
        }
    }
}