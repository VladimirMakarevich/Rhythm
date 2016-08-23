using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rhythm.Models
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Name { get; set; }
        [Required(ErrorMessage = "the fields are required")]
        [EmailAddress(ErrorMessage = "the Email field is not a valid e - mail addres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "the fields are required")]
        public string Message { get; set; }
    }
}

