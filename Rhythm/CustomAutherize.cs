using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm
{
    public class CustomAutherizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // если пользователь не принадлежит роли admin, то он перенаправляется на Home/About
            bool auth = filterContext.HttpContext.User.Identity.IsAuthenticated;
            if (!auth)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                { "controller", "Home" }, { "action", "Index" }
                });
            }
        }
    }
}