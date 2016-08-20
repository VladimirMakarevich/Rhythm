using Rhythm.Domain.Abstract;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.Title = "Dev.by";
            ViewBag.Text = "";
            ViewBag.WordFirst = "dev.by";
            ViewBag.WordSecond = "IT";
            ViewBag.WordThird = "Belarus";
        }
        // GET: Rss
        public ActionResult RssFeed()
        {

            ViewBag.Site = "Dev.by";
            ViewBag.News = "News";

            return View(RssReader.GetRssFeedDevBy());
        }

    }
}
