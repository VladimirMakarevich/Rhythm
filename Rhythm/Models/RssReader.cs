using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using System.Data.Entity;
using System.Xml;

namespace Rhythm.Models
{
    #region RssListViewModel 
    public class RssListViewModel
    {
        public IEnumerable<Rss> RssReaders { get; set; }
        public ListView PagingView { get; set; }
        public string Source { get; set; }
    }
    #endregion

    #region Rss
    public class Rss
    {
        public string Link { get; set; }
        public string Title { get; set; }
        private string description { get; set; }
        public string PubDate { get; set; }
        public string Description
        {
            get { return GetPlainText(description, 500); }
            set { description = value; }
        }
        private string GetPlainText(string htmlContent, int lenght = 0)
        {
            return lenght > 0 && htmlContent.Length > lenght ? htmlContent.Substring(0, lenght) + "..." : htmlContent;

        }
    }
    #endregion

    #region RssReader
    public class RssReader
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        private static string blogURL = "https://dev.by/rss";
        public static IEnumerable<Rss> GetRssFeed(string RSS)
        {
            switch (RSS)
            {
                case "Dev":
                    blogURL = "https://dev.by/rss";
                    break;
                case "EventsDev":
                    blogURL = "https://events.dev.by/rss";
                    break;
                case "DZoneweb":
                    blogURL = "http://feeds.dzone.com/webdev";
                    break;
                case "DZoneagile":
                    blogURL = "http://feeds.dzone.com/agile";
                    break;
                case "Codeproject":
                    blogURL = "http://www.codeproject.com/WebServices/ArticleRSS.aspx";
                    break;
                case "CodeprojectDotnet":
                    blogURL = "http://www.codeproject.com/WebServices/ArticleRSS.aspx?cat=5";
                    break;
                case "CodeprojectAspnet":
                    blogURL = "http://www.codeproject.com/WebServices/ArticleRSS.aspx?cat=4";
                    break;
                case "CodeprojectCsharp":
                    blogURL = "http://www.codeproject.com/WebServices/ArticleRSS.aspx?cat=3";
                    break;
                case "habrahabr":
                    blogURL = "https://habrahabr.ru/rss/feed/posts/52561a1f341aed2649a3121af8009a18/";
                    break;
                case "Hanselman":
                    blogURL = "http://feeds.hanselman.com/scotthanselman";
                    break;
                case "asp.net":
                    blogURL = "http://forums.asp.net/f/rss/1146";
                    break;
                case "StephenWalther":
                    blogURL = "http://feeds.feedburner.com/StephenWalther?format=xml";
                    break;
                case "Dotnetkick":
                    blogURL = "https://dotnetkicks.com/feeds/rss";
                    break;
                case "ScottGu":
                    blogURL = "https://weblogs.asp.net/scottgu/rss?containerid=13";
                    break;
                case "sergeyteplyakov":
                    blogURL = "http://feeds.feedburner.com/blogspot/Znar?format=xml";
                    break;
                default:
                    break;
            }
            try
            {
                XDocument feedXml = XDocument.Load(blogURL);
                var feeds = from feed in feedXml.Descendants("item")
                            select new Rss
                            {
                                Title = feed.Element("title").Value,
                                Link = feed.Element("link").Value,
                                Description = Regex.Replace(feed.Element("description").Value, "<.*?>", string.Empty),
                                PubDate = feed.Element("pubDate").Value
                            };
                return (feeds);
            }

            catch (Exception ex)
            {
                logger.Error("Faild in RssRader IEnumerable<Rss> GetRssFeed: {0}", ex.Message);
            }

            return null;
        }

        public static IEnumerable<Rss> GetRssDNK()
        {
            var blogURL = "https://dotnetkicks.com/feeds/rss";
            try
            {
                XDocument feedXml = XDocument.Load(blogURL);
                XNamespace ns = XNamespace.Get("http://www.w3.org/2005/Atom");

                var feeds = from feed in feedXml.Descendants("item")
                            select new Rss
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
    #endregion
}