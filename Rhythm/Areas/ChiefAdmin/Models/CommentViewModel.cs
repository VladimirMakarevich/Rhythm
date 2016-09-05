using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class CommentViewModel
    {

        public int ID { get; set; }
        public int PostID { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string NameUserSender { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string EmailUserSender { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public bool DescriptionComment { get; set; }
        public string Comment1 { get; set; }
        public DateTime PostedOn { get; set; }
    }
}