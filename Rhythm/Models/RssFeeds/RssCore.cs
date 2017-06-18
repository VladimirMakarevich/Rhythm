using Rhythm.Models.RssFeeds.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Rhythm.Models.RssFeeds
{
    public class RssCore : IRssCore
    {
        public IEnumerable<RssViewModel> GetRssDNK(string link)
        {
            XDocument feedXml = XDocument.Load(link);
            XNamespace ns = XNamespace.Get("http://www.w3.org/2005/Atom");

            var feeds = from feed in feedXml.Descendants("item")
                        select new RssViewModel
                        {
                            Title = feed.Element("title").Value,
                            Link = feed.Element("link").Value,
                            Description = Regex.Replace(feed.Element("description").Value, "<.*?>", string.Empty),
                            PubDate = feed.Element(ns + "updated").Value
                        };

            return (feeds);
        }

        public IEnumerable<RssViewModel> GetRssFeed(string link)
        {
            XDocument feedXml = XDocument.Load(link);

            var feeds = from feed in feedXml.Descendants("item")
                        select new RssViewModel
                        {
                            Title = feed.Element("title").Value,
                            Link = feed.Element("link").Value,
                            Description = Regex.Replace(feed.Element("description").Value, "<.*?>", string.Empty),
                            PubDate = feed.Element("pubDate").Value
                        };

            return (feeds);
        }
    }
}