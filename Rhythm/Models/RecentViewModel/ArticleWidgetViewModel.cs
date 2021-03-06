﻿namespace Rhythm.Models.RecentViewModel
{
    public class ArticleWidgetViewModel
    {
        private string articleContent;
        public string ArticleContent
        {
            get
            {
                return articleContent.Length > 200 ? articleContent.Substring(0, 200) + "..." : articleContent;
            }
            set
            {
                articleContent = value;
            }
        }
        public string Title { get; set; }
        public int Id { get; set; }
        public string ImagePath { get; set; }
    }
}
