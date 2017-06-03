using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class PostAdminViewModel
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
        [Required(ErrorMessage = "the field are required!")]
        public int CategoryId { get; set; }
        public CategoryAdminViewModel Category { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMime { get; set; }

        public int ID { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime Modified { get; set; }
        public int CountComments { get; set; }
        public ICollection<CommentAdminViewModel> Comments { get; set; }
        public ICollection<TagAdminViewModel> Tags { get; set; }
    }
}