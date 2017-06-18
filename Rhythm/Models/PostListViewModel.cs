using Rhythm.Domain.Entities;
using System.Collections.Generic;

namespace Rhythm.Models
{
    public class PostListViewModel
    {
        public IEnumerable<PostViewModel> PostsViewModel { get; set; }
        public ListView PagingView { get; set; }
        public HeaderViewModel HeaderViewModel { get; set; }
    }
}