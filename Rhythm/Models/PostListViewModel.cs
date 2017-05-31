using Rhythm.Domain.Entities;
using System.Collections.Generic;

namespace Rhythm.Models
{
    public class PostListViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public ListView PagingView { get; set; }

    }
}