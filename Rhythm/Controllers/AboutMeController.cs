using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class AboutMeController : DefaultController
    {
        public AboutMeController(IUserRepository userRepository, IPortfolioRepository portfolioRepository)
        {
            this.userRepository = userRepository;
            this.portfolioRepository = portfolioRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}