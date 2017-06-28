using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.Domain.Context;
using System;

namespace Rhythm.Domain.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        DogCodingContext _db;

        public ProjectRepository(DogCodingContext db)
        {
            _db = db;
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _db.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectAsync(int id)
        {
            return await _db.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project> GetProjectByPortfolioAsync(int portfolioId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateProjectAsync(Project project)
        {
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();
        }

        public async Task EditProjectAsync(Project project)
        {
            _db.Entry(project).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Project project)
        {
            _db.Projects.Remove(project);
            await _db.SaveChangesAsync();
        }
    }
}
