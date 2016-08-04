using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NLog;
using Rhythm.infrastructure;

namespace Rhythm
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            logger.Info("Application Start");
            logger.Debug("Application Debug");
            logger.Error("Application Error");
            logger.Trace("Application Trace");

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
