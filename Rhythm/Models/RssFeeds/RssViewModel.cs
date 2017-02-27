using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models.RssFeeds
{
    public class RssViewModel
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
}