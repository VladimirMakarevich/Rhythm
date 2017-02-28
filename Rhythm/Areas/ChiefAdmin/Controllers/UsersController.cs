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

        public UsersController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: ChiefAdmin/Users
        public async Task<ActionResult> Index()
        {
            var chiefUsers = db.ChiefUsers.Include(c => c.Portfolio);
            return View(await chiefUsers.ToListAsync());
        }

        // GET: ChiefAdmin/Users/Details/5
        public async Task<ActionResult> Details(int? id)
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

        // GET: ChiefAdmin/Users/Create
        public ActionResult Create()
        {
            ViewBag.PortfolioID = new SelectList(db.Portfolios, "PortfolioID", "Summary");
            return View();
        }

        // POST: ChiefAdmin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: ChiefAdmin/Users/Edit/5
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

        // POST: ChiefAdmin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: ChiefAdmin/Users/Delete/5
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

        // POST: ChiefAdmin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ChiefUser chiefUser = await db.ChiefUsers.FindAsync(id);
            db.ChiefUsers.Remove(chiefUser);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
