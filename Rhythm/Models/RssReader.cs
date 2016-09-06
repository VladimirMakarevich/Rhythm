﻿using NLog;
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
                case "PrideParrot":
                    blogURL = "http://feeds.feedburner.com/prideparrot?format=xml";
                    break;
                case "ScottGu":
                    blogURL = "https://weblogs.asp.net/scottgu/rss?containerid=13";
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
                //HttpServerUtilityBase.HtmlDecode
                return (feeds);
            }
            catch (Exception ex)
            {
                logger.Error("Faild in RssRader IEnumerable<Rss> GetRssFeed: ", ex.Message);
            }

            return null;
        }

        //"^.{1,180}\b(?<!\s)"

        //private string GetPlainText(string htmlContent, int lenght = 0)
        //{
        //    string htmlTag = "<.*?>";
        //    string plainText = Regex.Replace(htmlContent, htmlTag, string.Empty);
        //    return lenght > 0 && plainText.Length > lenght ? plainText.Substring(0, lenght) : plainText;

        //}
    }
}