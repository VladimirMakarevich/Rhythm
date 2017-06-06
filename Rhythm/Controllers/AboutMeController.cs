using Rhythm.BL.Interfaces;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Mappers;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class AboutMeController : DefaultController
    {
        private AboutMeMapper _aboutMeMapper;

        public AboutMeController(IUserProvider userProvider, IPortfolioProvider portfolioProvider, AboutMeMapper aboutMeMapper)
        {
            _userProvider = userProvider;
            _portfolioProvider = portfolioProvider;
            _aboutMeMapper = aboutMeMapper;
        }

        public async Task<ActionResult> Index()
        {
            var user = await _userProvider.GetChiefUsersAsync();

            if (user.Count() == 0)
            {
                return View();
            }

            var portfolio = await _portfolioProvider.GetPortfolioByUserAsync(user.FirstOrDefault().Id);
            var userViewModel = _aboutMeMapper.ToChiefUserViewModel(user.FirstOrDefault(), portfolio);

            return View(userViewModel);
        }
    }
}