using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm
{
    public class FilterConfig 
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    public class WatchConfig : ActionFilterAttribute
    {
        private Stopwatch watch;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            watch = new Stopwatch();
            watch.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            watch.Stop();
            filterContext.HttpContext.Response.Write(String.Format("Action {0}", watch.ElapsedMilliseconds));
            base.OnResultExecuted(filterContext);
        }

    }
}