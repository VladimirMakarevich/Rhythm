﻿using Rhythm.Domain.Model;

namespace Rhythm.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public CommentViewModel Comment { get; set; }
    }
}