using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models.RssFeeds
{
    public static class GetRss
    {
        private static string blogURL = "https://dev.by/rss";
        public static string GetRssFeed(string RSS)
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
            return blogURL;
        }
    }
}