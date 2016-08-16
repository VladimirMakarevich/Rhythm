using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhythm.Domain.Concrete
{
    public class RecentArticleWidget
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
    }
}
