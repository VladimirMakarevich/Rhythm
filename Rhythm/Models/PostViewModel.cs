using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public CommentViewModel Comment { get; set; }
    }
}