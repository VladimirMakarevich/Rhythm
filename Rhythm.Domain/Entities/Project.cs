using System.ComponentModel.DataAnnotations;

namespace Rhythm.Domain.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public int? PortfolioId { get; set; }
        public string NameProject { get; set; }
        public string Framework { get; set; }
        public string Database { get; set; }
        public string IDE { get; set; }
        public string StackTechnologies { get; set; }

        public virtual Portfolio Portfolio { get; set; }
    }
}
