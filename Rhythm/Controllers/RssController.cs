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
        // GET: Rss
        public ActionResult Devby()
        {
            ViewBag.Title = "Dev.by";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Belarus";

            ViewBag.Site = "Dev.by";
            ViewBag.News = "News";
            return View("RSS", RssReader.GetRssFeed("Dev"));
        }


        public ActionResult EventsDevby()
        {
            ViewBag.Title = "Events Dev.by";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Belarus";

            ViewBag.Site = "Events.Dev.by";
            ViewBag.News = "Events";
            return View("RSS", RssReader.GetRssFeed("EventsDev"));
        }

        public ActionResult DZoneweb()
        {
            ViewBag.Title = "DZone WEB";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "WEB";

            ViewBag.Site = "DZone";
            ViewBag.News = "News WEB";
            return View("RSS", RssReader.GetRssFeed("DZoneweb"));
        }

        public ActionResult DZoneagile()
        {
            ViewBag.Title = "DZone Agile";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "AGILE";

            ViewBag.Site = "DZone";
            ViewBag.News = "News Agile";
            return View("RSS", RssReader.GetRssFeed("DZoneagile"));
        }

        public ActionResult Codeproject()
        {
            ViewBag.Title = "Codeproject";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Article";

            ViewBag.Site = "Codeproject";
            ViewBag.News = "News All";
            return View("RSS", RssReader.GetRssFeed("Codeproject"));
        }

        public ActionResult CodeprojectCsharp()
        {

            ViewBag.Title = "Codeproject C#";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "C#";

            ViewBag.Site = "Codeproject";
            ViewBag.News = "News C#";
            return View("RSS", RssReader.GetRssFeed("CodeprojectCsharp"));
        }

        public ActionResult CodeprojectAspnet()
        {
            ViewBag.Title = "Codeproject ASP.NET";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "MVC";

            ViewBag.Site = "Codeproject";
            ViewBag.News = "News ASP.NET";
            return View("RSS", RssReader.GetRssFeed("CodeprojectAspnet"));
        }

        public ActionResult CodeprojectDotnet()
        {
            ViewBag.Title = "Codeproject .NET";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = ".NET";

            ViewBag.Site = "Codeproject";
            ViewBag.News = "News .NET";
            return View("RSS", RssReader.GetRssFeed("CodeprojectDotnet"));
        }

        public ActionResult Habrahabr()
        {
            ViewBag.Title = "Habrahabr";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "HUB";

            ViewBag.Site = "Hub";
            ViewBag.News = "News";
            return View("RSS", RssReader.GetRssFeed("habrahabr"));
        }

        public ActionResult Hanselman()
        {
            ViewBag.Title = "Hanselman Blog";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Blog";

            ViewBag.Site = "Hanselman";
            ViewBag.News = "News";
            return View("RSS", RssReader.GetRssFeed("Hanselman"));
        }

        public ActionResult ScottGu()
        {
            ViewBag.Title = "ScottGu's Blog";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Blog";

            ViewBag.Site = "ScottGu's";
            ViewBag.News = "News";
            return View("RSS", RssReader.GetRssFeed("ScottGu"));
        }

        public ActionResult AspDotNetQuestion()
        {
            ViewBag.Title = "Forum asp.net mvc";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Forum";

            ViewBag.Site = "Forum asp.net mvc";
            ViewBag.News = "News";
            return View("RSS", RssReader.GetRssFeed("asp.net")); 
        }

        public ActionResult StephenWalther()
        {
            ViewBag.Title = "StephenWalther Blog";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Blog";

            ViewBag.Site = "StephenWalther";
            ViewBag.News = "News";
            return View("RSS", RssReader.GetRssFeed("StephenWalther"));
        }

        public ActionResult PrideParrot()
        {
            ViewBag.Title = "Pride Parrot Blog";
            ViewBag.WordFirst = "NEWS";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Blog";

            ViewBag.Site = "PrideParrot";
            ViewBag.News = "News";
            return View("RSS", RssReader.GetRssFeed("PrideParrot"));
        }
    }
}