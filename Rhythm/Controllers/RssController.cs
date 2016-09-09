using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class RssController : DefaultController
    {
        public int PageSize = 8;
        public RssController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "RSS";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "WEB";
            return View();
        }


        #region Devby
        public ActionResult Devby(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("Devby");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "Dev.by";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Belarus";

            ViewBag.Site = "Dev.by";
            ViewBag.News = "News";
            return View("RSS", model);
        }
        #endregion

        #region EventsDevby
        public ActionResult EventsDevby(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("Devby");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };
            ViewBag.Title = "Events Dev.by";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Belarus";

            ViewBag.Site = "Events.Dev.by";
            ViewBag.News = "Events";
            return View("RSS", model);
        }
        #endregion

        #region DZoneweb
        public ActionResult DZoneweb(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("DZoneweb");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "DZone WEB";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "WEB";

            ViewBag.Site = "DZone";
            ViewBag.News = "News WEB";
            return View("RSS", model);
        }
        #endregion

        #region DZoneagile
        public ActionResult DZoneagile(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("DZoneagile");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "DZone Agile";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "AGILE";

            ViewBag.Site = "DZone";
            ViewBag.News = "News Agile";
            return View("RSS", model);
        }
        #endregion

        #region Codeproject
        public ActionResult Codeproject(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("Codeproject");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "Codeproject";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Article";

            ViewBag.Site = "Codeproject";
            ViewBag.News = "News All";
            return View("RSS", model);
        }
        #endregion

        #region CodeprojectCsharp
        public ActionResult CodeprojectCsharp(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("CodeprojectCsharp");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "Codeproject C#";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "C#";

            ViewBag.Site = "Codeproject";
            ViewBag.News = "News C#";
            return View("RSS", model);
        }
        #endregion

        #region CodeprojectAspnet
        public ActionResult CodeprojectAspnet(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("CodeprojectAspnet");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "Codeproject ASP.NET";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "MVC";

            ViewBag.Site = "Codeproject";
            ViewBag.News = "News ASP.NET";
            return View("RSS", model);
        }
        #endregion

        #region CodeprojectDotnet
        public ActionResult CodeprojectDotnet(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("CodeprojectDotnet");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "Codeproject .NET";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = ".NET";

            ViewBag.Site = "Codeproject";
            ViewBag.News = "News .NET";
            return View("RSS", model);
        }
        #endregion

        #region Habrahabr
        public ActionResult Habrahabr(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("habrahabr");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "Habrahabr";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "HUB";

            ViewBag.Site = "Hub";
            ViewBag.News = "News";
            return View("RSS", model);
        }
        #endregion

        #region Hanselman
        public ActionResult Hanselman(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("Hanselman");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "Hanselman Blog";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Blog";

            ViewBag.Site = "Hanselman";
            ViewBag.News = "News";
            return View("RSS", model);
        }
        #endregion

        #region ScottGu
        public ActionResult ScottGu(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("ScottGu");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "ScottGu's Blog";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Blog";

            ViewBag.Site = "ScottGu's";
            ViewBag.News = "News";
            return View("RSS", model);
        }
        #endregion

        #region AspDotNetQuestion
        public ActionResult AspDotNetQuestion(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("StephenWalther");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "Forum asp.net mvc";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Forum";

            ViewBag.Site = "Forum asp.net mvc";
            ViewBag.News = "News";
            return View("RSS", model);
        }
        #endregion

        #region StephenWalther
        public ActionResult StephenWalther(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("StephenWalther");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "StephenWalther Blog";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Blog";

            ViewBag.Site = "StephenWalther";
            ViewBag.News = "News";
            return View("RSS", model);
        }
        #endregion

        #region PrideParrot
        public ActionResult PrideParrot(string src, int page = 1)
        {
            var n = RssReader.GetRssFeed("PrideParrot");
            RssListViewModel model = new RssListViewModel
            {
                Source = src,

                RssReaders = n.OrderBy(m => m.PubDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArray()
                .Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = n.Count()
                }
            };

            ViewBag.Title = "Pride Parrot Blog";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Blog";

            ViewBag.Site = "PrideParrot";
            ViewBag.News = "News";
            return View("RSS", model);
        }
        #endregion
    }
}