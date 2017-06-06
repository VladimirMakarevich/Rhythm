using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rhythm.Domain.Entities
{
    public class Portfolio
    {
        public Portfolio()
        {
            this.Projects = new HashSet<Project>();
        }

        [Key]
        [ForeignKey("ChiefUser")]
        public int Id { get; set; }
        public string NamePortfolio { get; set; }
        public string Objective { get; set; }
        public string Summary { get; set; }
        public string Skills { get; set; }
        public string EnglishProficiency { get; set; }
        public string WorkExp { get; set; }
        public string Education { get; set; }
        public string ApplicationSystems { get; set; }
        public string AdditionalInfo { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ChiefUser ChiefUser { get; set; }
    }
}
