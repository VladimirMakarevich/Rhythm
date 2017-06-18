using System.Collections.Generic;

namespace Rhythm.Models.RssFeeds
{
    public class RssesViewModel
    {
        public IEnumerable<RssEntityViewModel> RssEntity { get; set; }
        public ListView PagingView { get; set; }
        public HeaderViewModel HeaderViewModel { get; set; }
    }
}