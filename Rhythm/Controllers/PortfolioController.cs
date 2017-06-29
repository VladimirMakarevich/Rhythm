using Rhythm.BL.Interfaces;
using Rhythm.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class PortfolioController : DefaultController
    {
        private ProjectMapper _projectMapper;
        private PortfolioMapper _portfolioMapper;

        public PortfolioController(IProjectProvider projectProvider, ProjectMapper projectMapper, PortfolioMapper portfolioMapper)
        {
            _projectProvider = projectProvider;
            _projectMapper = projectMapper;
            _portfolioMapper = portfolioMapper;
        }

        public async Task<ActionResult> Index()
        {
            var projects = await _projectProvider.GetListProjectsAsync();
            var projectsViewModel = _projectMapper.ToProjectsViewModel(projects);
            var portfolioViewModel = _portfolioMapper.ToPortfolioViewModel(projectsViewModel);

            return View(portfolioViewModel);
        }
    }
}