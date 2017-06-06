using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NLog;
using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Mappers.ChiefAdmin;
using Rhythm.BL.Interfaces;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class PortfoliosController : DefaultController
    {
        private PortfolioAdminMapper _portfolioMapper;

        public PortfoliosController(PortfolioAdminMapper portfolioMapper, IPortfolioProvider portfolioProvider)
        {
            _portfolioMapper = portfolioMapper;
            _portfolioProvider = portfolioProvider;
        }
        public async Task<ActionResult> Index()
        {
            var portfolio = await _portfolioProvider.GetPortfoliosAsync();
            var portfolioListViewModel = _portfolioMapper.ToListPortfolioViewModel(portfolio);

            return View(portfolioListViewModel);
        }


        public async Task<ActionResult> Details(int id)
        {
            var portfolio = await _portfolioProvider.GetPortfolioAsync(id);
            var portfolioViewModel = _portfolioMapper.ToPortfolioViewModel(portfolio);

            return View(portfolioViewModel);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(PortfolioAdminViewModel portfolioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var portfolio = _portfolioMapper.ToPortfolio(portfolioViewModel);
                    portfolio.Id = 1;
                    await _portfolioProvider.CreatePortfolioAsync(portfolio);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return View(portfolioViewModel);
        }


        public async Task<ActionResult> Edit(int id)
        {
            var portfolio = await _portfolioProvider.GetPortfolioAsync(id);
            var portfolioViewModel = _portfolioMapper.ToPortfolioViewModel(portfolio);

            return View(portfolioViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(PortfolioAdminViewModel portfolioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var portfolio = _portfolioMapper.ToPortfolio(portfolioViewModel);
                    await _portfolioProvider.EditPortfolioAsync(portfolio);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return View(portfolioViewModel);
        }


        public async Task<ActionResult> Delete(int id)
        {
            var portfolio = await _portfolioProvider.GetPortfolioAsync(id);
            var portfolioViewModel = _portfolioMapper.ToPortfolioViewModel(portfolio);

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
                    await _portfolioProvider.DeletePortfolioAsync(id);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Index");
        }
    }
}
