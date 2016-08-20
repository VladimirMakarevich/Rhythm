using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace Rhythm.Models
{
    public class RssReader
    {
        private static string blogURL = "https://dev.by/rss";
        public  static IEnumerable<Rss> GetRssFeedDevBy()
        {
            XDocument feedXml = XDocument.Load(blogURL);
            var feeds = from feed in feedXml.Descendants("item")
                        select new Rss
                        {
                            Title = feed.Element("title").Value,
                            Link = feed.Element("link").Value,
                            Description = Regex.Match(feed.Element("description").Value, @"^.{1, 1000}\b(?<!/s)").Value,
                            PubDate = feed.Element("pubDate").Value
                        };

            return feeds;
        }

    }
}