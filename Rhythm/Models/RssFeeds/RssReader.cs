using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading;

namespace Rhythm.Models.RssFeeds
{
    public class RssReader
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        public static IEnumerable<RssViewModel> GetRssFeed(string RSS)
        {
            var getRss = GetRss.GetRssFeed(RSS);
            try
            {
                XDocument feedXml = XDocument.Load(getRss);
                var feeds = from feed in feedXml.Descendants("item")
                            select new RssViewModel
                            {
                                Title = feed.Element("title").Value,
                                Link = feed.Element("link").Value,
                                Description = Regex.Replace(feed.Element("description").Value, "<.*?>", string.Empty),
                                PubDate = feed.Element("pubDate").Value
                            };
                Thread.Sleep(1);
                return (feeds);
            }
            catch (Exception ex)
            {
                logger.Error("Faild in RssRader IEnumerable<Rss> GetRssFeed: {0}", ex.Message);
            }
            return null;
        }

        public static IEnumerable<RssViewModel> GetRssDNK()
        {
            var blogURL = "https://dotnetkicks.com/feeds/rss";
            try
            {
                XDocument feedXml = XDocument.Load(blogURL);
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
            catch (Exception ex)
            {
                logger.Error("Faild in RssRader IEnumerable<Rss> GetRssFeed: {0}", ex.Message);
            }
            return null;
        }
    }
}