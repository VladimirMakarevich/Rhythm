using Rhythm.Areas.ChiefAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models
{
    public class CommonUserViewModel
    {
        public ChiefUserAdminViewModel UserViewModel { get; set; }
        public PortfolioAdminViewModel PortfolioViewModel { get; set; }
    }
}