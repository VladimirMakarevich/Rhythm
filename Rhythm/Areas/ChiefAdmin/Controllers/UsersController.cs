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
    public class UsersController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        private DogCodingEntities db = new DogCodingEntities();

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            ViewBag.PortfolioID = new SelectList(db.Portfolios, "PortfolioID", "Summary");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ChiefUserID,PortfolioID,FirstName,LastName,MiddleName,Birth,Email,HomeAddress,Skype,Mobile,Github,Linkedin")] ChiefUser chiefUser)
        {
            if (ModelState.IsValid)
            {
                db.ChiefUsers.Add(chiefUser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PortfolioID = new SelectList(db.Portfolios, "PortfolioID", "Summary", chiefUser.PortfolioID);
            return View(chiefUser);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiefUser chiefUser = await db.ChiefUsers.FindAsync(id);
            if (chiefUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.PortfolioID = new SelectList(db.Portfolios, "PortfolioID", "Summary", chiefUser.PortfolioID);
            return View(chiefUser);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ChiefUserID,PortfolioID,FirstName,LastName,MiddleName,Birth,Email,HomeAddress,Skype,Mobile,Github,Linkedin")] ChiefUser chiefUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiefUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PortfolioID = new SelectList(db.Portfolios, "PortfolioID", "Summary", chiefUser.PortfolioID);
            return View(chiefUser);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiefUser chiefUser = await db.ChiefUsers.FindAsync(id);
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
            ChiefUser chiefUser = await db.ChiefUsers.FindAsync(id);
            db.ChiefUsers.Remove(chiefUser);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
