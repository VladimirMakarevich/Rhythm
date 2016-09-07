using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Rhythm.Authentication;
using Rhythm.Domain.Abstract;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public abstract class DefaultController : Controller
    {
        public IRepository repository { get; set; }

    }
}