using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rhythm.Models;

namespace Rhythm.Mappers
{
    public class PortfolioMapper
    {
        private IMapper _mapper;

        public PortfolioMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PortfolioViewModel ToPortfolioViewModel(List<ProjectViewModel> projectsViewModel)
        {
            return new PortfolioViewModel { Header = GetHeader(), Projects = projectsViewModel };
        }

        private HeaderViewModel GetHeader()
        {
            return new HeaderViewModel
            {
                Title = "Projects",
                Text = "",
                FirstTagWord = "C#",
                SecondTagWord = "ASP.NET MVC",
                ThirdTagWord = "WEB"
            };
        }
    }
}