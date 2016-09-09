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
        public int ID { get; set; }
        public byte[] ImageData { get; set; }
    }
}
