using System;
using System.Collections.Generic;

namespace Rhythm.Domain.Entities
{
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string NameSenderPost { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string DescriptionPost { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public System.DateTime PostedOn { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMime { get; set; }
        public int CountComments { get; set; }
        public string ImagePath { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
