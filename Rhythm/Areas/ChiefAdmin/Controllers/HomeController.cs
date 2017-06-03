using Ninject.Infrastructure.Language;
using NLog;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class HomeController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        public HomeController(IRepository repository)
        {
            this._repository = repository;
        }

        public ViewResult Index()
        {
            ContentAdminViewModel content = new ContentAdminViewModel
            {
                Posts = _repository.Post
                .OrderBy(p => p.ID)
                .Take(15).ToArray().Reverse(),

                Categories = _repository.Category
                .OrderBy(c => c.ID).ToList(),

                Tags = _repository.Tag
                .OrderBy(t => t.ID).ToList(),

                Comments = _repository.Comment
                .OrderBy(co => co.ID)
                .Take(15).ToArray().Reverse()

            };
            if (content == null)
            {
                return null;
            }
            return View(content);
        }

        public ViewResult listCategories()
        {
            var model = _repository.Category.OrderBy(c => c.ID).ToList();
            return View(model);
        }
        public ViewResult listTags()
        {
            var model = _repository.Tag.OrderBy(c => c.ID).ToList();

            return View(model);
        }
        public ViewResult listPosts()
        {
            var model = _repository.Post.OrderBy(c => c.ID).ToList();
            return View(model);
        }
        public ViewResult listComments()
        {
            var model = _repository.Comment.OrderBy(c => c.ID).ToList();
            return View(model);
        }

        public FileContentResult GetImage(int id)
        {
            try
            {
                Post post = _repository.Post.FirstOrDefault(p => p.ID == id);
                if (post != null)
                {
                    return File(post.ImageData, "image/png");
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.Error("We have exceptions, can not get images: {0}", ex.Message);
            }
            return null;
        }
    }
}