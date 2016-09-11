using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Authentication;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class LoginController : DefaultController
    {
        public IAuthenticationManager SignInManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public DogUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<DogUserManager>();
            }
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel login, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            AppUser result = await UserManager.FindAsync(login.Email, login.Password);
            if (result == null)
            {
                ModelState.AddModelError("", "Email or password not exist");
            }
            else
            {
                ClaimsIdentity claim = await UserManager.CreateIdentityAsync(result,
                    DefaultAuthenticationTypes.ApplicationCookie);
                SignInManager.SignOut();
                SignInManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true
                }, claim);
                if (String.IsNullOrEmpty(returnUrl))
                    return RedirectToAction("Index", "Home");
            }
            return Redirect(returnUrl);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = register.Email, Email = register.Email };
                var result = await UserManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            return View(register);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            SignInManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}