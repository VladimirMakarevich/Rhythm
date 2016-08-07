using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models
{
    public class PostListViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public ListView PagingView { get; set; }

    }
}