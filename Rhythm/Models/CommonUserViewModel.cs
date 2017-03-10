using Rhythm.Areas.ChiefAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models
{
    public class CommonUserViewModel
    {
        public ChiefUserViewModel UserViewModel { get; set; }
        public PortfolioViewModel PortfolioViewModel { get; set; }
    }
}