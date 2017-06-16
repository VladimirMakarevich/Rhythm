using System.Collections.Generic;

namespace Rhythm.Models.RssFeeds
{
    public class RssListViewModel
    {
        public IEnumerable<RssViewModel> RssReaders { get; set; }
        public ListView PagingView { get; set; }
        public string Source { get; set; }
        public HeaderViewModel HeaderViewModel { get; set; }
    }
}