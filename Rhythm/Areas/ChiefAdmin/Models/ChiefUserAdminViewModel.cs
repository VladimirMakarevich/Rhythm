using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class ChiefUserAdminViewModel
    {
        public int Id { get; set; }
        [Display(Name="Portfolio")]
        public int PortfolioId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Birth")]
        public string Birth { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Address")]
        public string HomeAddress { get; set; }
        [Display(Name = "Skype")]
        public string Skype { get; set; }
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        [Display(Name = "GitHub")]
        public string Github { get; set; }
        [Display(Name = "LinkedIn")]
        public string Linkedin { get; set; }

        public List<PortfolioAdminViewModel> PortfolioViewModel { get; set; }
    }
}