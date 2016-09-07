using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class ImageViewModel
    {
        public HttpPostedFileBase ImageData { get; set; }
        public string ImageMime { get; set; }
    }
}