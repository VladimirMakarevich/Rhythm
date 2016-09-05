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
                name: "ChiefAdmin",
                url: "ChiefAdmin/{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "Rhythm.Areas.ChiefAdmin.Controllers" }
                );

            //context.MapRoute(
            //    name: "ChiefAdmin",
            //    url: "ChiefAdmin/{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "Rhythm.Areas.ChiefAdmin.Controllers" }
            //    );

            context.MapRoute(
                name: "View",
                url: "ChiefAdmin/{controller}/{action}/{id}",
                defaults: new { controller = "Edit", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Rhythm.Areas.ChiefAdmin.Controllers" }
                );


            context.MapRoute(
                name: "Add",
                url: "ChiefAdmin/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Rhythm.Areas.ChiefAdmin.Controllers" }
                );


            context.MapRoute(
                name: "Update",
                url: "ChiefAdmin/{controller}/{action}/{id}",
                defaults: new { controller = "Update", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Rhythm.Areas.ChiefAdmin.Controllers" }
                );

        }
    }
}