using Rhythm.Domain.Model;
using System.Collections.Generic;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class Content
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}