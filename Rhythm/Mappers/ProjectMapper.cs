using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Rhythm.Domain.Entities;
using Rhythm.Models;

namespace Rhythm.Mappers
{
    public class ProjectMapper
    {
        private IMapper _mapper;

        public ProjectMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ProjectViewModel> ToProjectsViewModel(List<Project> projects)
        {
            return projects.Select(ToProjectViewModel).ToList();
        }

        public ProjectViewModel ToProjectViewModel(Project project)
        {
            return _mapper.Map<Project, ProjectViewModel>(project);
        }
    }
}