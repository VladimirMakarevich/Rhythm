using System.Web.Mvc;
using System.Web.Routing;
using Rhythm.infrastructure;
using System.Web.Optimization;
using NLog.Common;
using NLog;

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

            string nlogPath = Server.MapPath("nlog-web.log");
            InternalLogger.LogFile = nlogPath;
            InternalLogger.LogLevel = NLog.LogLevel.Trace;

            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MappingConfig.RegisterMapping();

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
