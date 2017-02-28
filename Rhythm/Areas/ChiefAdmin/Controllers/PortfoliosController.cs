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

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class PortfoliosController : DefaultController
    {
        private DogCodingEntities db = new DogCodingEntities();

        // GET: ChiefAdmin/Portfolios
        public async Task<ActionResult> Index()
        {
            return View(await db.Portfolios.ToListAsync());
        }

        // GET: ChiefAdmin/Portfolios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio portfolio = await db.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        // GET: ChiefAdmin/Portfolios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiefAdmin/Portfolios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PortfolioID,Summary,Skills,WorkExp,MyProjects,Education,AdditionalInfo")] Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                db.Portfolios.Add(portfolio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(portfolio);
        }

        // GET: ChiefAdmin/Portfolios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio portfolio = await db.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        // POST: ChiefAdmin/Portfolios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PortfolioID,Summary,Skills,WorkExp,MyProjects,Education,AdditionalInfo")] Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(portfolio);
        }

        // GET: ChiefAdmin/Portfolios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio portfolio = await db.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        // POST: ChiefAdmin/Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Portfolio portfolio = await db.Portfolios.FindAsync(id);
            db.Portfolios.Remove(portfolio);
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
