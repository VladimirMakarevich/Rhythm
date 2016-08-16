using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhythm.Domain.Concrete
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

        public bool DisqusComment { get; set; }

    }
}
