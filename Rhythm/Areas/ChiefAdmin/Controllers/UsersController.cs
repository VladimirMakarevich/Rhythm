using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Rhythm.Domain.Model;
using Rhythm.Domain.Abstract;
using NLog;
using System.Linq;
using Rhythm.Areas.ChiefAdmin.Mappers;
using Rhythm.Areas.ChiefAdmin.Models;
using System;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class UsersController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        private UserMapper _userMapper;
        public UsersController(IUserRepository userRepository, IPortfolioRepository portfolioRepository, UserMapper userMapper)
        {
            _userRepository = userRepository;
            _portfolioRepository = portfolioRepository;
            _userMapper = userMapper;
        }

        public async Task<ActionResult> Index()
        {
            var users = await _userRepository.GetListChiefUsersAsync();
            var usersListViewModel = _userMapper.ToListUsersViewModel(users);

            return View(usersListViewModel);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var chiefUser = await _userRepository.GetUserAsync(id);
            var userViewModel = _userMapper.ToUserViewModel(chiefUser);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }


        public ActionResult Create()
        {
            DropDownListUser();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ChiefUserID,PortfolioID,FirstName,LastName,MiddleName,Birth,Email,HomeAddress,Skype,Mobile,Github,Linkedin")] ChiefUserViewModel chiefUserViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var chiefUser = _userMapper.ToChiefUser(chiefUserViewModel);
                    await _userRepository.CreateUserAsync(chiefUser);
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {
                    logger.Error("Failed message - {0}, source - {1}, inner exception - {2}", ex.Message, ex.Source, ex.InnerException);
                }
            }
            DropDownListUser(chiefUserViewModel.PortfolioID);
            return View(chiefUserViewModel);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var chiefUser = await _userRepository.GetUserAsync(id);
            var userViewModel = _userMapper.ToUserViewModel(chiefUser);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            DropDownListUser(userViewModel.PortfolioID);
            return View(userViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ChiefUserID,PortfolioID,FirstName,LastName,MiddleName,Birth,Email,HomeAddress,Skype,Mobile,Github,Linkedin")] ChiefUserViewModel chiefUserViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var chiefUser = _userMapper.ToChiefUser(chiefUserViewModel);
                    await _userRepository.EditChangesUser(chiefUser);
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {
                    logger.Error("Failed message - {0}, source - {1}, inner exception - {2}", ex.Message, ex.Source, ex.InnerException);
                }
            }
            DropDownListUser(chiefUserViewModel.PortfolioID);
            return View(chiefUserViewModel);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var chiefUser = await _userRepository.GetUserAsync(id);
            var userViewModel = _userMapper.ToUserViewModel(chiefUser);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            DropDownListUser(userViewModel.PortfolioID);
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
                    await _userRepository.DeleteUserAsync(id);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    logger.Error("Failed message - {0}, source - {1}, inner exception - {2}", ex.Message, ex.Source, ex.InnerException);
                }
            }
            return RedirectToAction("Index");
        }

        #region drop
        private void DropDownListUser(object selectedItem = null)
        {
            var query = from m in _portfolioRepository.GetPortfolio
                            orderby m.PortfolioID
                            select m;
            //var q = _portfolioRepository.GetPortfolio.OrderBy(m => m.NamePortfolio).ToList();
            ViewBag.PortfolioID = new SelectList(query, "PortfolioID", "NamePortfolio", selectedItem);
        }
        #endregion
    }
}
