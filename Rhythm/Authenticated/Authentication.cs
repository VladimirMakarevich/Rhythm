using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Rhythm.Domain.Model;
using Rhythm.Domain.Abstract;
using Ninject;
using System.Web.Security;

namespace Rhythm.Authenticated
{
    public class Authentication : IAuthentication
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private const string cookieName = "__AUTH_COOKIE";
        public HttpContext HttpContext { get; set; }
        [Inject]
        public IRepository Repository { get; set; }
        private IPrincipal currentUser;

        public IPrincipal CurrentUser
        {
            get
            {
                if(currentUser == null)
                {
                    try
                    {
                        HttpCookie authCookie = HttpContext.Request.Cookies.Get(cookieName);
                        if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            currentUser = new UserProvider(ticket.Name, Repository);
                        }
                        else
                        {
                            currentUser = new UserProvider(null, null);
                        }
                    }
                    catch (Exception ex)
                    {

                        logger.Error("Failed authentication: " + ex.Message);
                        currentUser = new UserProvider(null, null);
                    }
                }

                return currentUser;
            }
        }

        //public DogUser Login(string login)
        //{
        //    DogUser retUser = Repository.User.FirstOrDefault(p => string.Compare(p.EmailUser, login, true) == 0);
        //    if (retUser != null)
        //    {
        //        CreateCookie(login);
        //    }
        //    return retUser;
        //}

        //private void CreateCookie(string login)
        //{
        //    throw new NotImplementedException();
        //}

        public DogUser Login(string login, string password, bool isPersistent)
        {
            DogUser retUser = Repository.Login(login, password);
            if (retUser != null)
            {
                CreateCookie(login, isPersistent);
            }
            return retUser;
        }

        private void CreateCookie(string login, bool isPersistent)
        {
            //Create ticket
            var ticket = new FormsAuthenticationTicket(
                1,
                login,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                isPersistent,
                string.Empty,
                FormsAuthentication.FormsCookiePath);

            //Encrypt the ticket
            var encTicket = FormsAuthentication.Encrypt(ticket);

            //Create cookie
            var AuthCookie = new HttpCookie(cookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            //HttpContext.Response.Cookies.Set(AuthCookie);
            //HttpContext.Request.Cookies.Set(AuthCookie);
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[cookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }
    }
}