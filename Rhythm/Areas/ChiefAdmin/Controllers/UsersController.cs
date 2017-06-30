using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using Rhythm.Areas.ChiefAdmin.Models;
using System;
using Rhythm.Mappers.ChiefAdmin;
using Rhythm.BL.Interfaces;
using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class UsersController : DefaultController
    {
        private UserAdminMapper _userMapper;
        private PortfolioAdminMapper _portfolioMapper;
        private string _imagePath;

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
        public async Task<ActionResult> Create(ChiefUserAdminViewModel chiefUserViewModel)
        {
            if (ModelState.IsValid)
            {
                if (chiefUserViewModel.FileBase != null)
                {
                    _imagePath = SaveFileData(chiefUserViewModel.FileBase);
                }
                var chiefUser = _userMapper.ToChiefUser(chiefUserViewModel, _imagePath);

                await _userProvider.CreateUserAsync(chiefUser, chiefUserViewModel.PortfolioId);

                return RedirectToAction("Index");
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
        public async Task<ActionResult> Edit(ChiefUserAdminViewModel chiefUserViewModel)
        {
            if (ModelState.IsValid)
            {
                if (chiefUserViewModel.FileBase != null)
                {
                    _imagePath = SaveFileData(chiefUserViewModel.FileBase);
                }

                var chiefUser = _userMapper.ToChiefUser(chiefUserViewModel, _imagePath);

                await _userProvider.EditUser(chiefUser, chiefUserViewModel.PortfolioId);

                return RedirectToAction("Index");
            }

            await DropDownListPortfolioAsync(chiefUserViewModel.PortfolioId);

            return View(chiefUserViewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var chiefUser = await _userProvider.GetUserAsync(id);
            var userViewModel = _userMapper.ToUserViewModel(chiefUser);

            return View(userViewModel);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _userProvider.DeleteUserAsync(id);

            return RedirectToAction("Index");
        }

        #region drop
        private async Task DropDownListPortfolioAsync(object selectedItem = null)
        {
            var query = from m in await _portfolioProvider.GetPortfoliosAsync()
                        orderby m.Id
                        select m;

            ViewBag.PortfolioId = new SelectList(query, "Id", "NamePortfolio", selectedItem);
        }
        #endregion

        #region images
        public async Task<FileContentResult> GetImageToUser(int id)
        {
            var chiefUser = await _userProvider.GetUserAsync(id);

            if (chiefUser.ImagePath != null)
            {
                var dataByte = System.IO.File.ReadAllBytes(chiefUser.ImagePath);

                return File(dataByte, "image/png");
            }

            return null;
        }

        private string SaveFileData(HttpPostedFileBase fileData)
        {
            var fileHashName = fileData.GetHashCode().ToString();
            var fileFullName = $"{fileHashName}_{fileData.FileName}";
            var filePath = Server.MapPath("~/Content/images/" + fileFullName);

            fileData.SaveAs(filePath);

            return filePath;
        }
        #endregion
    }
}
