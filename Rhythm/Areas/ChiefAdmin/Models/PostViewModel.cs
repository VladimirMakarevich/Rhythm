using Ninject;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class PostViewModel
    {
        //public Post Post { get; set; }
        public string NameSenderPost { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string DescriptionPost { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public int model { get; set; }
        public List<int> Tag { get; set; }
        public HttpPostedFileBase imageData { get; set; }
        public string ImageMime { get; set; }
    }
}