using Rhythm.BL.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.Mappers;
using Rhythm.Models;
using Rhythm.Models.RssFeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class RssController : DefaultController
    {
        private RssMapper _rssMapper;
        private RssCore _rssCore;

        public RssController(IRssProvider rssProvider, RssMapper rssMapper, RssCore rssCore)
        {
            _rssProvider = rssProvider;
            _rssMapper = rssMapper;
            _rssCore = rssCore;
        }

        public async Task<ActionResult> Index(int page = 1)
        {
            var rsses = await _rssProvider.GetRssesAsync();
            var rssesViewModel = _rssMapper.ToRssesViewModel(rsses, page);

            return View(rssesViewModel);
        }

        public async Task<ActionResult> GetRss(int id, int page = 1)
        {
            var rss = await _rssProvider.GetRssAsync(id);
            var rssFeed = CheckType(rss);
            var rssListViewModel = _rssMapper.ToRssListViewModel(rss, rssFeed, page);

            return View(rssListViewModel);
        }

        private List<RssViewModel> CheckType(Rss rss)
        {
            List<RssViewModel> rssFeed;

            switch (rss.Type)
            {
                case TypeRss.Xml:
                    return rssFeed = _rssCore.GetRssFeedXml(rss.Url);
                case TypeRss.Atom:
                    return rssFeed = _rssCore.GetRssFeedAtom(rss.Url);
                case TypeRss.Common:
                    return rssFeed = _rssCore.GetRssFeedCommon(rss.Url);
                default:
                    return rssFeed = _rssCore.GetRssFeedCommon(rss.Url);
            }
        }

        //#region SergeyTeplyakov
        //public ActionResult Sergeyteplyakov(string src, int page = 1)
        //{
        //    var n = RssReader.GetRssFeed("sergeyteplyakov");
        //    RssListViewModel model = new RssListViewModel
        //    {
        //        Source = src,

        //        RssReaders = n.OrderBy(m => m.PubDate)
        //        .AsEnumerable()
        //        .Reverse()
        //        .Skip((page - 1) * PageSize)
        //        .Take(PageSize),

        //        PagingView = new ListView
        //        {
        //            CurrentPage = page,
        //            PostsPerPage = PageSize,
        //            TotalPosts = n.Count()
        //        }
        //    };

        //    ViewBag.Title = "Sergey Teplyakov";
        //    ViewBag.WordFirst = "NEWS";
        //    ViewBag.WordSecond = "IT";
        //    ViewBag.WordThird = "Blog";

        //    ViewBag.Site = "Sergey Teplyakov";
        //    ViewBag.News = "News";
        //    return View("RSS", model);
        //}
        //#endregion
    }
}
