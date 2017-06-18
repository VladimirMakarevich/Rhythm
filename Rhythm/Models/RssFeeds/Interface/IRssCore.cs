using System.Collections.Generic;

namespace Rhythm.Models.RssFeeds.Interface
{
    public interface IRssCore
    {
        IEnumerable<RssViewModel> GetRssFeed(string link);
        IEnumerable<RssViewModel> GetRssDNK(string link);
    }
}