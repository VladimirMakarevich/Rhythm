﻿using Rhythm.Domain.Abstract;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rhythm.Domain.Model;

namespace Rhythm.Controllers
{
    public class HomeController : DefaultController
    {
        public int PageSize = 8;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(int page = 1)
        {
            PostListViewModel model = new PostListViewModel
            {
                Posts = repository.Post
                .OrderBy(p => p.ID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = repository.Post.Count()
                }
            };

            return View(model);
        }

        public ActionResult SinglePost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = repository.Post.FirstOrDefault(p => p.ID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public ActionResult Tag(int tag = 8)
        {
            WidgetListViewModel model = new WidgetListViewModel
            {
                Tags = repository.Tag
                .OrderBy(t => t.Name)
                .Take(tag)
            };

            return View(model);
        }
    }
}