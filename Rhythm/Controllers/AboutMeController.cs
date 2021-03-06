﻿using Rhythm.BL.Interfaces;
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
            var portfolio = await _portfolioProvider.GetPortfolioByUserAsync(user.FirstOrDefault().Id);

            var userViewModel = _aboutMeMapper.ToChiefUserViewModel(user.FirstOrDefault(), portfolio);

            return View(userViewModel);
        }

        public async Task<FileContentResult> GetImage(int id)
        {
            var chiefUser = await _userProvider.GetUserAsync(id);

            if (chiefUser.ImagePath != null)
            {
                var dataByte = System.IO.File.ReadAllBytes(chiefUser.ImagePath);

                return File(dataByte, "image/png");
            }

            return null;
        }
    }
}