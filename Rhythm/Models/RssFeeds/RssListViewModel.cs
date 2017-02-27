using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models.RssFeeds
{
    public class RssListViewModel
    {
        public IEnumerable<RssViewModel> RssReaders { get; set; }
        public ListView PagingView { get; set; }
        public string Source { get; set; }
    }
}