using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string NameSenderPost { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string DescriptionPost { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime Modified { get; set; }
        public byte[] ImageData { get; set; }
        public string ImagePath { get; set; }
        public string ImageMime { get; set; }
        public int CountComments { get; set; }
    }
}