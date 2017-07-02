using Rhythm.Models.RssFeeds.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Terradue.ServiceModel.Syndication;

namespace Rhythm.Models.RssFeeds
{
    public class RssCore : IRssCore
    {
        public List<RssViewModel> GetRssFeedCommon(string link)
        {
            var reader = XmlReader.Create(link);
            var feeds = SyndicationFeed.Load(reader);
            var feedsViewModel = new List<RssViewModel>();

            foreach (SyndicationItem item in feeds.Items)
            {
                if (item.Summary != null)
                {
                    feedsViewModel.Add(new RssViewModel()
                    {
                        Title = item.Title?.Text,
                        Description = item.Summary?.Text,
                        Link = item.Links?.Reverse().Take(1).FirstOrDefault().Uri.ToString(),
                        PubDate = item.PublishDate.DateTime.ToString()
                    });
                }
                else
                {
                    feedsViewModel.Add(new RssViewModel()
                    {
                        Title = item.Title?.Text,
                        Description = " ",
                        Link = item.Links?.Reverse().Take(1).FirstOrDefault().Uri.ToString(),
                        PubDate = item.PublishDate.DateTime.ToString()
                    });
                }
            }

            return feedsViewModel;
        }

        public List<RssViewModel> GetRssFeedXml(string link)
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

            return feeds.ToList();
        }

        public List<RssViewModel> GetRssFeedAtom(string link)
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

            return feeds.ToList();
        }
    }
}