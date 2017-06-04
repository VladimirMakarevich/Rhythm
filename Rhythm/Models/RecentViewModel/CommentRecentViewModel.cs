using System;

namespace Rhythm.Models.RecentViewModel
{
    public class CommentRecentViewModel
    {
        private string commentContent;
        public string CommentContent
        {
            get
            {
                return commentContent.Length > 100 ? commentContent.Substring(0, 100) + "..." : commentContent;
            }
            set
            {
                commentContent = value;
            }
        }

        public DateTime PostAddedDate { get; set; }
        public string NameUserSender { get; set; }

        public int Id { get; set; }

    }
}
