using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Authenticated
{
    public class AuthHttpModule : IHttpModule
    {
        public void Init (HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(this.Authenticate);

        }

        private void Authenticate(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpContext context = app.Context;

            var Auth = DependencyResolver.Current.GetService<IAuthentication>();
            Auth.HttpContext = context;
            context.User = Auth.CurrentUser;
        }

        public void Dispose()
        { }
    }
}