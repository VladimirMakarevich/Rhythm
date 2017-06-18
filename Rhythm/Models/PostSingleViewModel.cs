using Rhythm.Domain.Entities;

namespace Rhythm.Models
{
    public class PostSingleViewModel
    {
        public PostViewModel PostViewModel { get; set; }
        public CommentViewModel CommentViewModel { get; set; }
        public HeaderViewModel HeaderViewModel { get; set; }
        public int CountPosts { get; set; }
    }
}