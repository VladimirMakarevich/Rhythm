using System.ComponentModel.DataAnnotations;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class PortfolioAdminViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Portfolio")]
        public string NamePortfolio { get; set; }
        public string Objective { get; set; }
        public string Summary { get; set; }
        public string Skills { get; set; }
        [Display(Name = "English Proficiency")]
        public string EnglishProficiency { get; set; }
        [Display(Name = "Work Experience")]
        public string WorkExp { get; set; }
        public string Education { get; set; }
        [Display(Name = "Application Systems")]
        public string ApplicationSystems { get; set; }
        [Display(Name = "Additional Information")]
        public string AdditionalInfo { get; set; }
        public int ChiefUserId { get; set; }
        public ChiefUserAdminViewModel ChiefUser { get; set; }
    }
}