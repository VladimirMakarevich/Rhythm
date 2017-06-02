using AutoMapper;
using System.Collections.Generic;
using Rhythm.Models.RecentViewModel;

namespace Rhythm.Mappers
{
    public class RecentContentMapper
    {
        private IMapper _mapper;

        public RecentContentMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public RecentContentViewModel ToRecentContentViewModel(IEnumerable<CategoryRecentViewModel> categoriesRecentViewModel, IEnumerable<TagRecentViewModel> tagsRecentViewModel, IEnumerable<PostRecentViewModel> postRecentViewModel, List<CommentRecentViewModel> commentsRecentViewModel, ArticleWidgetViewModel articleWidget)
        {
            return new RecentContentViewModel
            {
                ArticleWidgetViewModel = articleWidget, 
                CategoryRecentViewModel = categoriesRecentViewModel,
                CommentRecentViewModel = commentsRecentViewModel,
                PostRecentViewModel = postRecentViewModel,
                TagRecentViewModel = tagsRecentViewModel
            };
        }
    }
}