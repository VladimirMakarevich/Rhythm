using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class CategoryViewModel
    {
        //TODO: ADD ID
        public int ID { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string DescriptionCategory { get; set; }
    }
}