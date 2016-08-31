using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User email is required!")]
        [Display(Name = "User email (*)")]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password (*)")]
        public string Password { get; set; }
        public bool isPersistent { get; set; }
    }
}