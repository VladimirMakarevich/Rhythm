using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class PortfolioViewModel
    {
        public int PortfolioID { get; set; }
        public string NamePortfolio { get; set; }
        public string Summary { get; set; }
        public string Skills { get; set; }
        public string WorkExp { get; set; }
        public string MyProjects { get; set; }
        public string Education { get; set; }
        public string AdditionalInfo { get; set; }
        //public virtual ICollection<int> ChiefUsers { get; set; }
    }
}