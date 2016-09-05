using Ninject;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class PostViewModel
    {
        [Required(ErrorMessage = "the field are required!")]
        public string NameSenderPost { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string DescriptionPost { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string UrlSlug { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public bool Published { get; set; }
        public int Category { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public List<int> intTag { get; set; }
        public HttpPostedFileBase ImageData { get; set; }
        public string ImageMime { get; set; }


        public int ID { get; set; }
        public DateTime PostedOn { get; set; }
        public Nullable<DateTime> Modified { get; set; }
        public Nullable<int> CountComments { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}