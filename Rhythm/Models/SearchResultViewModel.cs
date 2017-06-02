using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models
{
    public class SearchResultViewModel
    {
        public PostListViewModel PostListViewModel { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}