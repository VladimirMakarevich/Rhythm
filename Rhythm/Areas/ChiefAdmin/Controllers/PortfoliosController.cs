using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rhythm.Domain.Model;
using Rhythm.Domain.Abstract;
using NLog;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class PortfoliosController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        //private DogCodingEntities db = new DogCodingEntities();
        public PortfoliosController(IUserRepository userRepository, IPortfolioRepository portfolioRepository)
        {
            _userRepository = userRepository;
            _portfolioRepository = portfolioRepository;
        }
        public async Task<ActionResult> Index()
        {

            return View(await _portfolioRepository.GetPortfolio.ToListAsync());
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var portfolio = await _portfolioRepository.GetPortfolioAsync(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PortfolioID,Summary,Skills,WorkExp,MyProjects,Education,AdditionalInfo")] Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                await _portfolioRepository.CreatePortfolioAsync(portfolio);
                return RedirectToAction("Index");
            }

            return View(portfolio);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var portfolio = await _portfolioRepository.GetPortfolioAsync(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PortfolioID,Summary,Skills,WorkExp,MyProjects,Education,AdditionalInfo")] Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                await _portfolioRepository.EditPortfolioAsync(portfolio);
                return RedirectToAction("Index");
            }
            return View(portfolio);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var portfolio = await _portfolioRepository.GetPortfolioAsync(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _portfolioRepository.DeletePortfolioAsync(id);
            return RedirectToAction("Index");
        }
    }
}
