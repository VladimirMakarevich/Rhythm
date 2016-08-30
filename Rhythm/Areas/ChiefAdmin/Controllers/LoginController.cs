using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rhythm.Models;
using System.Web.Security;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Authenticated;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class LoginController : DefaultController
    {
        private readonly IAuthoProvider authoProvider;
        public LoginController(IAuthoProvider authoProvider)
        {
            this.authoProvider = authoProvider;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (authoProvider.IsLoggedIn)
                return Redirect(returnUrl);

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && authoProvider.Login(model.UserName, model.Password))
                return RedirectToRoute(returnUrl);

            ModelState.AddModelError("", "The user name or password provided is incorrect!");

            return View(model);
        }

        public ActionResult Manage()
        {
            return View();
        }



        public ActionResult Logout()
        {
            authoProvider.Logout();

            return RedirectToAction("Login", "Login");
        }

        private ActionResult RedirectToUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Home");
            }
        }
    }
}