﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    /// <summary>
    /// Contains actions to return views for different errors
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Retutn view for generic errors (for ex. Internal Server Error like 500)
        /// </summary>
        /// <returns></returns>

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Return view for 404 errors
        /// </summary>
        /// <returns></returns>

        public ActionResult NotFound()
        {
            return View();
        }
    }
}