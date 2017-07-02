using System.Collections.Generic;

namespace Rhythm.Models.RssFeeds.Interface
{
    public interface IRssCore
    {
        List<RssViewModel> GetRssFeedXml(string link);
        List<RssViewModel> GetRssFeedCommon(string link);
        List<RssViewModel> GetRssFeedAtom(string link);
    }
}