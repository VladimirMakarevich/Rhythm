using System;
using System.Collections.Generic;

namespace Rhythm.Domain.Entities
{
    public class Tag
    {
        public Tag()
        {
            this.PostTagMaps = new HashSet<PostTagMap>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string DescriptionTag { get; set; }

        public virtual ICollection<PostTagMap> PostTagMaps { get; set; }
    }
}
