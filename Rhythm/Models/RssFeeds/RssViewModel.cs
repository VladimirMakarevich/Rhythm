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
            get { return GetPlainText(description, 300); }
            set { description = value; }
        }
        private string GetPlainText(string htmlContent, int lenght = 0)
        {
            return htmlContent;

        }
    }
}