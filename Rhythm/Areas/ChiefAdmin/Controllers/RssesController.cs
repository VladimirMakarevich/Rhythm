﻿using System.Threading.Tasks;
using System.Web.Mvc;
using Rhythm.BL.Interfaces;
using Rhythm.Mappers.ChiefAdmin;
using Rhythm.Areas.ChiefAdmin.Models;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    public class RssesController : DefaultController
    {
        private RssAdminMapper _rssMapper;

        public RssesController(IRssProvider rssProvider, RssAdminMapper rssMapper)
        {
            _rssProvider = rssProvider;
            _rssMapper = rssMapper;
        }

        public async Task<ActionResult> Index()
        {
            var rsses = await _rssProvider.GetRssesAsync();
            var rssesViewModel = _rssMapper.ToRssesViewModel(rsses);
            
            return View(rssesViewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            var rsses = await _rssProvider.GetRssAsync(id);
            var rssViewModel = _rssMapper.ToRssViewModel(rsses);

            return View(rssViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RssAdminViewModel rssViewModel)
        {
            if (ModelState.IsValid)
            {
                var rss = _rssMapper.ToRss(rssViewModel);
                await _rssProvider.CreateRssAsync(rss);

                return RedirectToAction("Index");
            }

            return View(rssViewModel);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var rss = await _rssProvider.GetRssAsync(id);
            var rssViewModel = _rssMapper.ToRssViewModel(rss);

            return View(rssViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RssAdminViewModel rssViewModel)
        {
            if (ModelState.IsValid)
            {
                var rss = _rssMapper.ToRss(rssViewModel);
                await _rssProvider.EditRssAsync(rss);

                return RedirectToAction("Index");
            }

            return View(rssViewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var rss = await _rssProvider.GetRssAsync(id);
            var rssViewModel = _rssMapper.ToRssViewModel(rss);

            return View(rssViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _rssProvider.DeleteRssAsync(id);

            return RedirectToAction("Index");
        }
    }
}
