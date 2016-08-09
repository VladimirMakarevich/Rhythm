using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class DefaultController : Controller
    {
        public IRepository repository { get; set; }
    }
}