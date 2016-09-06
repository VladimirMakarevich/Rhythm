﻿using Ninject.Infrastructure.Language;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{

    public class HomeController : DefaultController
    {
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            Content content = new Content
            {
                Posts = repository.Post
                .OrderBy(p => p.ID)
                .Take(15).ToArray().Reverse(),

                Categories = repository.Category
                .OrderBy(c => c.ID).ToList(),

                Tags = repository.Tag
                .OrderBy(t => t.ID).ToList(),

                Comments = repository.Comment
                .OrderBy(co => co.ID)
                .Take(15).ToArray().Reverse()

            };

            return View(content);
        }

        public ViewResult listCategories()
        {
            var model = repository.Category.OrderBy(c => c.ID).ToList();
            return View(model);
        }
        public ViewResult listTags()
        {
            var model = repository.Tag.OrderBy(c => c.ID).ToList();

            return View(model);
        }
        public ViewResult listPosts()
        {
            var model = repository.Post.OrderBy(c => c.ID).ToList();
            return View(model);
        }
        public ViewResult listComments()
        {
            var model = repository.Comment.OrderBy(c => c.ID).ToList();
            return View(model);
        }
    }
}