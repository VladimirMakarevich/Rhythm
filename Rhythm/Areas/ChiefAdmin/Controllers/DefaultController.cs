
using Ninject;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public abstract class DefaultController : Controller
    {
        // GET: ChiefAdmin/Default
        [Inject]
        public IRepository repository { get; set; }

    }
}