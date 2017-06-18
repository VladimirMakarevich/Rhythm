using System.Collections.Generic;

namespace Rhythm.Models.RssFeeds
{
    public class RssListViewModel
    {
        public string Id { get; set; }
        public IEnumerable<RssViewModel> RssReaders { get; set; }
        public ListView PagingView { get; set; }
        public string Site { get; set; }
        public string Theme { get; set; }
        public HeaderViewModel HeaderViewModel { get; set; }
    }
}