using System;

namespace Rhythm.BL.Models
{
    public class RecentComment
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

        public int ID { get; set; }

    }
}
