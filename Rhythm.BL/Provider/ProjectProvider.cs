using Rhythm.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rhythm.Domain.Entities;
using Rhythm.Domain.UnitOfWork;

namespace Rhythm.BL.Provider
{
    public class ProjectProvider : IProjectProvider
    {
        private IUnitOfWork _uow;

        public ProjectProvider(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task CreateProjectAsync(Project project)
        {
            await _uow.Project.CreateProjectAsync(project);
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _uow.Project.GetProjectAsync(id);

            await _uow.Project.DeleteProjectAsync(project);
        }

        public async Task EditProjectAsync(Project project)
        {
            await _uow.Project.EditProjectAsync(project);
        }

        public async Task<List<Project>> GetListProjectsAsync()
        {
            return await _uow.Project.GetProjectsAsync();
        }

        public async Task<Project> GetProjectAsync(int id)
        {
            return await _uow.Project.GetProjectAsync(id);
        }

        public async Task<Project> GetProjectByPortfolioAsync(int portfolioId)
        {
            throw new NotImplementedException();
        }
    }
}
