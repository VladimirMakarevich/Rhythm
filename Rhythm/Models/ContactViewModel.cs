using System.ComponentModel.DataAnnotations;

namespace Rhythm.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "the Name fields are required")]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }
        [Required(ErrorMessage = "the Email fields are required")]
        [EmailAddress(ErrorMessage = "the email field is not a valid e - mail addres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "the Message fields are required")]
        public string Message { get; set; }
        [IsValidBool]
        public bool AreLikeDogs { get; set; }
        public HeaderViewModel Header { get; set; }
        public ContactsResultViewModel ResultMessage { get; set; }
    }
}

