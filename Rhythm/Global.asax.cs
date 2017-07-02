using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using NLog.Common;
using NLog;
using System;
using System.Web;
using Rhythm.Controllers;
using Rhythm.Infrastructure;
using System.Globalization;
using System.Timers;
using System.Net;

namespace Rhythm
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            string nlogPath = Server.MapPath("nlog-web.log");
            InternalLogger.LogFile = nlogPath;
            InternalLogger.LogLevel = NLog.LogLevel.Trace;

            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            Timer();
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    var httpContext = ((MvcApplication)sender).Context;
        //    var ex = Server.GetLastError();
        //    var status = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;

        //    // Is Ajax request? return json
        //    if (httpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //    {
        //        httpContext.ClearError();
        //        httpContext.Response.Clear();
        //        httpContext.Response.StatusCode = status;
        //        httpContext.Response.TrySkipIisCustomErrors = true;
        //        httpContext.Response.ContentType = "application/json";
        //        httpContext.Response.Write("{ success: false, message: \"Error occured in server.\" }");
        //        httpContext.Response.End();
        //    }
        //    else
        //    {
        //        var currentController = " ";
        //        var currentAction = " ";
        //        var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

        //        if (currentRouteData != null)
        //        {
        //            if (currentRouteData.Values["controller"] != null &&
        //            !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
        //            {
        //                currentController = currentRouteData.Values["controller"].ToString();
        //            }

        //            if (currentRouteData.Values["action"] != null &&
        //            !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
        //            {
        //                currentAction = currentRouteData.Values["action"].ToString();
        //            }
        //        }

        //        var controller = new ErrorController();
        //        var routeData = new RouteData();

        //        httpContext.ClearError();
        //        httpContext.Response.Clear();
        //        httpContext.Response.StatusCode = status;
        //        httpContext.Response.TrySkipIisCustomErrors = true;

        //        routeData.Values["controller"] = "Error";
        //        routeData.Values["action"] = status == 404 ? "NotFound" : "Index";

        //        controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
        //        ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        //    }
        //}

        private void Timer()
        {
            Timer timer = new System.Timers.Timer(30000) { AutoReset = true };
            timer.Elapsed += (object source, ElapsedEventArgs eea) =>
            {
                timer.Stop();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://dogcoding.azurewebsites.net/");
                request.GetResponse();
                timer.Start();
            };
            timer.Start();
        }
    }
}
