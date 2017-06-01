using System;
using System.Collections.Generic;

namespace Rhythm.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string NameUserSender { get; set; }
        public string EmailUserSender { get; set; }
        public bool DescriptionComment { get; set; }
        public string CommentMessage { get; set; }
        public System.DateTime PostedOn { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }

        public virtual Post Post { get; set; }
    }
}
