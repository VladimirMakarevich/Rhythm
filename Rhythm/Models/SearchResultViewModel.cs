namespace Rhythm.Models
{
    public class SearchResultViewModel
    {
        public PostListViewModel PostListViewModel { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public HeaderViewModel HeaderViewModel { get; set; }
    }
}