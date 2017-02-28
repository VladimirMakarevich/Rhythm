using System.ComponentModel.DataAnnotations;

namespace Rhythm.Models
{
    public class CommentViewModel
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        [Required(ErrorMessage = "all the fields are required")]
        public string NameUserSender { get; set; }
        [Required(ErrorMessage = "all the fields are required")]
        [EmailAddress(ErrorMessage = "the Email field is not a valid e - mail addres")]
        public string EmailUserSender { get; set; }
        [Required(ErrorMessage = "all the fields are required")]
        [IsValidBool]
        public bool DescriptionComment { get; set; }
        [Required(ErrorMessage = "all the fields are required")]
        public string Comment1 { get; set; }
    }
}