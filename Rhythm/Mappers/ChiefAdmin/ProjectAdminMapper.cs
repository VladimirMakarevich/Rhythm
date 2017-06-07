using System.Collections.Generic;
using System.Linq;
using Rhythm.Domain.Entities;
using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class ProjectAdminMapper
    {
        private IMapper _mapper;

        public ProjectAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Project ToProject(ProjectAdminViewModel projectViewModel)
        {
            var project = _mapper.Map<ProjectAdminViewModel, Project>(projectViewModel);

            return project;
        }

        public ProjectAdminViewModel ToProjectViewModel(Project project)
        {
            return _mapper.Map<Project, ProjectAdminViewModel>(project);
        }

        public List<ProjectAdminViewModel> ToProjectsViewModel(List<Project> project)
        {
            return project.Select(ToProjectViewModel).ToList();
        }
    }
}