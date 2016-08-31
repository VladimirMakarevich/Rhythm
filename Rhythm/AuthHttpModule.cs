using Rhythm.Authenticated;
using System;
using System.Web;
using System.Web.Mvc;

namespace Rhythm
{
    public class AuthHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(this.Authenticate);
            //context.AuthorizeRequest += new EventHandler(this.AuthorizeRequest);

        }

        //private void AuthorizeRequest(object sender, EventArgs e)
        //{
        //    HttpApplication app = (HttpApplication)sender;
        //    HttpContext context = app.Context;

        //    var Auth = DependencyResolver.Current.GetService<IAuthentication>();
        //    Auth.HttpContext = context;
        //    context.User = Auth.CurrentUser;
        //}

        private void Authenticate(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;

            var Auth = DependencyResolver.Current.GetService<IAuthentication>();
            Auth.HttpContext = context;
            context.User = Auth.CurrentUser;
        }

        public void Dispose()
        { }
    }
}