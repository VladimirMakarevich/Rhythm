using System;

namespace Rhythm.Models
{
    public class ListView
    {
        public int TotalPosts { get; set; }
        public int PostsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalPosts / PostsPerPage); }
        }
    }
}