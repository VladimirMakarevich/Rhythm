using System.Threading.Tasks;
using System.Web.Mvc;
using Rhythm.BL.Interfaces;
using Rhythm.Mappers.ChiefAdmin;
using Rhythm.Areas.ChiefAdmin.Models;
using System.Linq;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class ProjectsController : DefaultController
    {
        private ProjectAdminMapper _projectMapper;

        public ProjectsController(IProjectProvider projectProvider, IPortfolioProvider portfolioProvider, ProjectAdminMapper projectMapper)
        {
            _projectProvider = projectProvider;
            _portfolioProvider = portfolioProvider;
            _projectMapper = projectMapper;
        }

        public async Task<ActionResult> Index()
        {
            var projects = await _projectProvider.GetListProjectsAsync();
            var projectsViewModel = _projectMapper.ToProjectsViewModel(projects);

            return View(projectsViewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            var project = await _projectProvider.GetProjectAsync(id);
            var projectViewModel = _projectMapper.ToProjectViewModel(project);

            return View(projectViewModel);
        }

        public async Task<ActionResult> Create()
        {
            await DropDownListPortfoliosAsync();

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(ProjectAdminViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                var project = _projectMapper.ToProject(projectViewModel);
                await _projectProvider.CreateProjectAsync(project);

                return RedirectToAction("Index");
            }

            await DropDownListPortfoliosAsync(projectViewModel.PortfolioId);

            return View(projectViewModel);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var project = await _projectProvider.GetProjectAsync(id);
            var projectViewModel = _projectMapper.ToProjectViewModel(project);

            await DropDownListPortfoliosAsync(projectViewModel.PortfolioId);

            return View(projectViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(ProjectAdminViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                var project = _projectMapper.ToProject(projectViewModel);
                await _projectProvider.EditProjectAsync(project);

                return RedirectToAction("Index");
            }

            await DropDownListPortfoliosAsync(projectViewModel.PortfolioId);

            return View(projectViewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var project = await _projectProvider.GetProjectAsync(id);
            var projectViewModel = _projectMapper.ToProjectViewModel(project);

            return View(projectViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _projectProvider.DeleteProjectAsync(id);

            return RedirectToAction("Index");
        }

        #region drop
        private async Task DropDownListPortfoliosAsync(object selectedItem = null)
        {
            var query = from m in await _portfolioProvider.GetPortfoliosAsync()
                        orderby m.Id
                        select m;

            ViewBag.PortfolioId = new SelectList(query, "Id", "NamePortfolio", selectedItem);
        }
        #endregion
    }
}
