using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Interfaces
{
    public interface IProjectProvider
    {
        Task<List<Project>> GetListProjectsAsync();
        Task<Project> GetProjectAsync(int id);
        Task<Project> GetProjectByPortfolioAsync(int portfolioId);
        Task CreateProjectAsync(Project project, int portfolioId);
        Task EditProjectAsync(Project project, int portfolioId);
        Task DeleteProjectAsync(int id);
    }
}
