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
using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Areas.ChiefAdmin.Mappers;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class PortfoliosController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        private PortfolioMapper _portfolioMapper;

        public PortfoliosController(IUserRepository userRepository, IPortfolioRepository portfolioRepository, PortfolioMapper portfolioMapper)
        {
            _userRepository = userRepository;
            _portfolioRepository = portfolioRepository;
            _portfolioMapper = portfolioMapper;
        }
        public async Task<ActionResult> Index()
        {
            var portfolio = await _portfolioRepository.GetPortfolio.ToListAsync();
            var portfolioListViewModel = _portfolioMapper.ToListPortfolioViewModel(portfolio);

            return View(portfolioListViewModel);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var portfolio = await _portfolioRepository.GetPortfolioAsync(id);
            var portfolioViewModel = _portfolioMapper.ToPortfolioViewModel(portfolio);
            if (portfolioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(portfolioViewModel);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(PortfolioViewModel portfolioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var portfolio = _portfolioMapper.ToPortfolio(portfolioViewModel);
                    await _portfolioRepository.CreatePortfolioAsync(portfolio);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    logger.Error("Failed message - {0}, source - {1}, inner exception - {2}", ex.Message, ex.Source, ex.InnerException);
                }
            }
            return View(portfolioViewModel);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var portfolio = await _portfolioRepository.GetPortfolioAsync(id);
            var portfolioViewModel = _portfolioMapper.ToPortfolioViewModel(portfolio);
            if (portfolioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(portfolioViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(PortfolioViewModel portfolioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var portfolio = _portfolioMapper.ToPortfolio(portfolioViewModel);
                    await _portfolioRepository.EditPortfolioAsync(portfolio);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    logger.Error("Failed message - {0}, source - {1}, inner exception - {2}", ex.Message, ex.Source, ex.InnerException);
                }
            }
            return View(portfolioViewModel);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var portfolio = await _portfolioRepository.GetPortfolioAsync(id);
            var portfolioViewModel = _portfolioMapper.ToPortfolioViewModel(portfolio);
            if (portfolioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(portfolioViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var portfolio = _portfolioMapper.ToPortfolio(portfolioViewModel);
                    await _portfolioRepository.DeletePortfolioAsync(id);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    logger.Error("Failed message - {0}, source - {1}, inner exception - {2}", ex.Message, ex.Source, ex.InnerException);
                }
            }
            return RedirectToAction("Index");
            //await _portfolioRepository.DeletePortfolioAsync(id);
            //return RedirectToAction("Index");
        }
    }
}
