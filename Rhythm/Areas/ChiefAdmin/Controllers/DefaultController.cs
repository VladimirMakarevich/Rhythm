using Ninject;
using Rhythm.Authenticated;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public abstract class DefaultController : Controller
    {
        // GET: ChiefAdmin/Default
        [Inject]
        public IRepository repository { get; set; }

        [Inject]
        public IAuthentication Auth { get; set; }
        public DogUser CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }
    }
}