using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjectsAsync();
        Task<Project> GetProjectAsync(int id);
        Task<Project> GetProjectByPortfolioAsync(int portfolioId);
        Task CreateProjectAsync(Project project);
        Task EditProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);
    }
}
