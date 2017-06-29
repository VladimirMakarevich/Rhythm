namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class ProjectAdminViewModel
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public string NameProject { get; set; }
        public string Framework { get; set; }
        public string Database { get; set; }
        public string IDE { get; set; }
        public string StackTechnologies { get; set; }
        public string Url { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}