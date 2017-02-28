using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Rhythm.Domain.Model;
using Rhythm.Domain.Abstract;
using NLog;
using System.Linq;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class UsersController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        private DogCodingEntities db = new DogCodingEntities();

        public UsersController(IUserRepository userRepository, IPortfolioRepository portfolioRepository)
        {
            _userRepository = userRepository;
            _portfolioRepository = portfolioRepository;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _userRepository.GetListChiefUsersAsync());
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var chiefUser = await _userRepository.GetUserAsync(id);
            if (chiefUser == null)
            {
                return HttpNotFound();
            }
            return View(chiefUser);
        }


        public ActionResult Create()
        {
            DropDownListUser();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ChiefUserID,PortfolioID,FirstName,LastName,MiddleName,Birth,Email,HomeAddress,Skype,Mobile,Github,Linkedin")] ChiefUser chiefUser)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.CreateUserAsync(chiefUser);
                return RedirectToAction("Index");
            }

            DropDownListUser(chiefUser.PortfolioID);
            return View(chiefUser);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var chiefUser = await _userRepository.GetUserAsync(id);
            if (chiefUser == null)
            {
                return HttpNotFound();
            }
            DropDownListUser(chiefUser.PortfolioID);
            return View(chiefUser);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ChiefUserID,PortfolioID,FirstName,LastName,MiddleName,Birth,Email,HomeAddress,Skype,Mobile,Github,Linkedin")] ChiefUser chiefUser)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.EditChangesUser(chiefUser);
                return RedirectToAction("Index");
            }
            DropDownListUser(chiefUser.PortfolioID);
            return View(chiefUser);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var chiefUser = await _userRepository.GetUserAsync(id);
            if (chiefUser == null)
            {
                return HttpNotFound();
            }
            return View(chiefUser);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var chiefUser = await _userRepository.GetUserAsync(id);
            await _userRepository.DeleteUserAsync(chiefUser);
            return RedirectToAction("Index");
        }

        #region drop
        private void DropDownListUser(object selectedItem = null)
        {
            var query = from m in _portfolioRepository.GetPortfolio
                            orderby m.PortfolioID
                            select m;
            ViewBag.PortfolioID = new SelectList(query, "PortfolioID", "Summary", selectedItem);
        }
        #endregion
    }
}
