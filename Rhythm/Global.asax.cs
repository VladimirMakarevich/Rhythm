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
            logger.Info("Applicetion Start.");

            string nlogPath = Server.MapPath("nlog-web.log");
            InternalLogger.LogFile = nlogPath;
            InternalLogger.LogLevel = NLog.LogLevel.Trace;

            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MappingConfig.RegisterMapping();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalFilters.Filters.Add(new WatchConfig());


            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
