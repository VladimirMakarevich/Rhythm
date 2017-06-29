using Rhythm.BL.Interfaces;
using Rhythm.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class PortfolioController : DefaultController
    {
        private ProjectMapper _projectMapper;
        public PortfolioController(IProjectProvider projectProvider, ProjectMapper projectMapper)
        {
            _projectProvider = projectProvider;
            _projectMapper = projectMapper;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}