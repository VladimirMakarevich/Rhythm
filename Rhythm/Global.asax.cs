using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NLog;
using Rhythm.infrastructure;
using System.Web.Optimization;

namespace Rhythm
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            //logger.Info("Application Start");
            //logger.Debug("Application Debug");
            //logger.Error("Application Error");
            //logger.Trace("Application Trace");

            //var adminArea = new ChiefAdminAreaRegistration();
            //var adminAreaContext = new AreaRegistrationContext(adminArea.AreaName, RouteTable.Routes);
            //adminArea.RegisterArea(adminAreaContext);

            AreaRegistration.RegisterAllAreas();


            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
