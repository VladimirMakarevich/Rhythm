using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using Rhythm.Areas.ChiefAdmin.Models;
using System;
using Rhythm.Mappers.ChiefAdmin;
using Rhythm.BL.Interfaces;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class UsersController : DefaultController
    {
        private UserAdminMapper _userMapper;
        private PortfolioAdminMapper _portfolioMapper;

        public UsersController(IUserProvider userProvider, IPortfolioProvider portfolioProvider, UserAdminMapper userMapper,
            PortfolioAdminMapper portfolioMapper)
        {
            _userProvider = userProvider;
            _portfolioProvider = portfolioProvider;
            _userMapper = userMapper;
            _portfolioMapper = portfolioMapper;
        }

        public async Task<ActionResult> Index()
        {
            var users = await _userProvider.GetChiefUsersAsync();
            var usersListViewModel = _userMapper.ToListUsersViewModel(users);

            return View(usersListViewModel);
        }


        public async Task<ActionResult> Details(int id)
        {
            var chiefUser = await _userProvider.GetUserAsync(id);
            var userViewModel = _userMapper.ToUserViewModel(chiefUser);

            return View(userViewModel);
        }


        public async Task<ActionResult> Create()
        {
            await DropDownListPortfolioAsync();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ChiefUserAdminViewModel chiefUserViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var chiefUser = _userMapper.ToChiefUser(chiefUserViewModel);
                    await _userProvider.CreateUserAsync(chiefUser);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            await DropDownListPortfolioAsync(chiefUserViewModel.PortfolioId);

            return View(chiefUserViewModel);
        }


        public async Task<ActionResult> Edit(int id)
        {

            var chiefUser = await _userProvider.GetUserAsync(id);
            var userViewModel = _userMapper.ToUserViewModel(chiefUser);

            await DropDownListPortfolioAsync(userViewModel.PortfolioId);

            return View(userViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ChiefUserAdminViewModel chiefUserViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var chiefUser = _userMapper.ToChiefUser(chiefUserViewModel);
                    await _userProvider.EditUser(chiefUser);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            await DropDownListPortfolioAsync(chiefUserViewModel.PortfolioId);

            return View(chiefUserViewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var chiefUser = await _userProvider.GetUserAsync(id);
            var userViewModel = _userMapper.ToUserViewModel(chiefUser);

            await DropDownListPortfolioAsync(userViewModel.PortfolioId);

            return View(userViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userProvider.DeleteUserAsync(id);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return RedirectToAction("Index");
        }

        #region drop
        private async Task DropDownListPortfolioAsync(object selectedItem = null)
        {
            var query = from m in await _portfolioProvider.GetPortfoliosAsync()
                        orderby m.PortfolioId
                        select m;

            ViewBag.PortfolioId = new SelectList(query, "PortfolioID", "NamePortfolio", selectedItem);
        }
        #endregion
    }
}
