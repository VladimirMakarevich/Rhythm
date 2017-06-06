namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class PortfolioAdminViewModel
    {
        public int PortfolioId { get; set; }
        public string NamePortfolio { get; set; }
        public string Objective { get; set; }
        public string Summary { get; set; }
        public string Skills { get; set; }
        public string EnglishProficiency { get; set; }
        public string WorkExp { get; set; }
        public string Education { get; set; }
        public string ApplicationSystems { get; set; }
        public string AdditionalInfo { get; set; }
        public int ChiefUserId { get; set; }
        //public virtual ICollection<int> ChiefUsers { get; set; }
    }
}