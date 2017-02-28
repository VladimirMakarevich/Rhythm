﻿
using Ninject;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public abstract class DefaultController : Controller
    {
        [Inject]
        public IRepository _repository { get; set; }
        [Inject]
        public IUserRepository _userRepository { get; set; }
        [Inject]
        public IPortfolioRepository _portfolioRepository { get; set; }

    }
}