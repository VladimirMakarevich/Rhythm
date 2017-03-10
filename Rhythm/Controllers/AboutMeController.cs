using Rhythm.Domain.Abstract;
using Rhythm.Mappers;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class AboutMeController : DefaultController
    {
        private AboutMeMapper _aboutMeMapper;
        public AboutMeController(IUserRepository userRepository, IPortfolioRepository portfolioRepository, AboutMeMapper aboutMeMapper)
        {
            this.userRepository = userRepository;
            this.portfolioRepository = portfolioRepository;
            _aboutMeMapper = aboutMeMapper;
        }

        public ActionResult Index()
        {
            var user = userRepository.GetUser.FirstOrDefault();
            var portfolio = portfolioRepository.GetPortfolio(user.PortfolioID);
            var userVewModel = _aboutMeMapper.ToCommonUserViewModel(user, portfolio);

            return View(userVewModel);
        }
    }
}