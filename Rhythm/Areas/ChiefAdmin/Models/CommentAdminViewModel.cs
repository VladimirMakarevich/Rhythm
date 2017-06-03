using System;
using System.ComponentModel.DataAnnotations;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class CommentAdminViewModel
    {

        public int Id { get; set; }
        public int PostId { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string NameUserSender { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string EmailUserSender { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public bool DescriptionComment { get; set; }
        public string CommentMessage { get; set; }
        public DateTime PostedOn { get; set; }
    }
}