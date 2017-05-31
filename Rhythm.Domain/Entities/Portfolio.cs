using System;
using System.Collections.Generic;

namespace Rhythm.Domain.Entities
{
    public class Portfolio
    {
        public Portfolio()
        {
            this.ChiefUsers = new HashSet<ChiefUser>();
        }

        public int PortfolioID { get; set; }
        public string NamePortfolio { get; set; }
        public string Summary { get; set; }
        public string Skills { get; set; }
        public string WorkExp { get; set; }
        public string MyProjects { get; set; }
        public string Education { get; set; }
        public string AdditionalInfo { get; set; }

        public virtual ICollection<ChiefUser> ChiefUsers { get; set; }
    }
}
