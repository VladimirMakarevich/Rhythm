using System.Collections.Generic;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class ContentAdminViewModel
    {
        public IEnumerable<PostAdminViewModel> Posts { get; set; }
        public IEnumerable<CategoryAdminViewModel> Categories { get; set; }
        public IEnumerable<TagAdminViewModel> Tags { get; set; }
        public IEnumerable<CommentAdminViewModel> Comments { get; set; }
    }
}