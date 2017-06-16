using Rhythm.Areas.ChiefAdmin.Models;

namespace Rhythm.Models
{
    public class CommonUserViewModel
    {
        public ChiefUserAdminViewModel UserViewModel { get; set; }
        public PortfolioAdminViewModel PortfolioViewModel { get; set; }
        public HeaderViewModel HeaderViewModel { get; set; }
    }
}