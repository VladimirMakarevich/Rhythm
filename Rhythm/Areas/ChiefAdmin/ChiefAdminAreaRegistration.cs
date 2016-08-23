using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin
{
    public class ChiefAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ChiefAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ChiefAdmin",
                "ChiefAdmin/{controller}/{action}/{id}",
                new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}