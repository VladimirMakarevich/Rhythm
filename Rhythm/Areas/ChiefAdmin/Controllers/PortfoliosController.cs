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
    [Authorize]
    public class PortfoliosController : DefaultController
    {
        private PortfolioAdminMapper _portfolioMapper;

        public PortfoliosController(PortfolioAdminMapper portfolioMapper, IPortfolioProvider portfolioProvider, IUserProvider userProvider)
        {
            _portfolioMapper = portfolioMapper;
            _portfolioProvider = portfolioProvider;
            _userProvider = userProvider;
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


        public async Task<ActionResult> Create()
        {
            await DropDownListUsersAsync();

            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(PortfolioAdminViewModel portfolioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var portfolio = _portfolioMapper.ToPortfolio(portfolioViewModel);
                    await _portfolioProvider.CreatePortfolioAsync(portfolio);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            await DropDownListUsersAsync(portfolioViewModel.ChiefUserId);

            return View(portfolioViewModel);
        }


        public async Task<ActionResult> Edit(int id)
        {
            var portfolio = await _portfolioProvider.GetPortfolioAsync(id);
            var portfolioViewModel = _portfolioMapper.ToPortfolioViewModel(portfolio);

            await DropDownListUsersAsync(portfolioViewModel.ChiefUserId);

            return View(portfolioViewModel);
        }


        [HttpPost]
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

            await DropDownListUsersAsync(portfolioViewModel.ChiefUserId);

            return View(portfolioViewModel);
        }


        public async Task<ActionResult> Delete(int id)
        {
            var portfolio = await _portfolioProvider.GetPortfolioAsync(id);
            var portfolioViewModel = _portfolioMapper.ToPortfolioViewModel(portfolio);

            await DropDownListUsersAsync(portfolioViewModel.ChiefUserId);

            return View(portfolioViewModel);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _portfolioProvider.DeletePortfolioAsync(id);

            return RedirectToAction("Index");
        }

        #region drop
        private async Task DropDownListUsersAsync(object selectedItem = null)
        {
            var query = from m in await _userProvider.GetChiefUsersAsync()
                        orderby m.Id
                        select m;

            ViewBag.ChiefUserId = new SelectList(query, "Id", "Email", selectedItem);
        }
        #endregion
    }
}
