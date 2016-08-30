using System.Web.Mvc;
using Rhythm.Areas.ChiefAdmin.Models;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    /// <summary>
    /// TODO: Ограничить доступ к определнным областям приложения. 
    /// Как проверять аутенцификацию пользователя при запросах к ограниченным областям, представлениям.
    /// </summary>
    [Authorize]
    public class LoginController : DefaultController
    {
        public LoginController()
        {

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(model.UserName, model.Password, model.isPersistent);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState["Password"].Errors.Add("Password not exist!");
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Home");
        }

        //private readonly IAuthoProvider authoProvider;
        //public LoginController(IAuthoProvider authoProvider)
        //{
        //    this.authoProvider = authoProvider;
        //}

        //[AllowAnonymous]
        //public ActionResult Login(string returnUrl)
        //{
        //    if (authoProvider.IsLoggedIn)
        //        return Redirect(returnUrl);

        //    ViewBag.ReturnUrl = returnUrl;

        //    return View();
        //}

        //[HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        //public ActionResult Login(LoginModel model, string returnUrl)
        //{
        //    if (ModelState.IsValid && authoProvider.Login(model.UserName, model.Password))
        //        return RedirectToRoute(returnUrl);

        //    ModelState.AddModelError("", "The user name or password provided is incorrect!");

        //    return View(model);
        //}



        //public ActionResult Logout()
        //{
        //    authoProvider.Logout();

        //    return RedirectToAction("Login", "Login");
        //}

        //private ActionResult RedirectToUrl(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index","Home");
        //    }
        //}
    }
}