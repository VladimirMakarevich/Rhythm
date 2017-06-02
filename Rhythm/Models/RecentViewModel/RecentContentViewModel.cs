using System.Collections.Generic;

namespace Rhythm.Models.RecentViewModel
{
    public class RecentContentViewModel
    {
        public IEnumerable<CategoryRecentViewModel> CategoryRecentViewModel { get; set; }
        public IEnumerable<TagRecentViewModel> TagRecentViewModel { get; set; }
        public IEnumerable<PostRecentViewModel> PostRecentViewModel { get; set; }
        public List<CommentRecentViewModel> CommentRecentViewModel { get; set; }
        public ArticleWidgetViewModel ArticleWidgetViewModel { get; set; }
        //public List<Archive> Archive { get; set; }
    }
}