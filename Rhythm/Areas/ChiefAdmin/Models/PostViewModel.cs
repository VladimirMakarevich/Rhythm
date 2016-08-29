using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string PostDescription { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public string Category { get; set; }
        public int MyProperty { get; set; }
        public HttpPostedFileBase ImageData { get; set; }
        public string ImageMime { get; set; }
    }
}