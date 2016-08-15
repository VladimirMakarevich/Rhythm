using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Rhythm
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Posts",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Posts", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Articles",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Articles", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Library",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Library", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Portfolio",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Portfolio", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AboutMe",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AboutMe", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contacts",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Contacts", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
