﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class LibraryController : DefaultController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}