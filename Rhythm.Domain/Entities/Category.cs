using System;
using System.Collections.Generic;

namespace Rhythm.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string DescriptionCategory { get; set; }
        public int CountCategory { get; set; }


        public virtual ICollection<Post> Posts { get; set; }
    }
}
