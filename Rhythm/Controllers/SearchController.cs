using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class SearchController : DefaultController
    {
        public int PageSize = 8;
        public SearchController(IRepository repository)
        {
            ViewBag.Text = "";
            ViewBag.WordFirst = "C#";
            ViewBag.WordSecond = "ASP.NET MVC";
            ViewBag.WordThird = "WEB";
            this.repository = repository;
        }
        // GET: Search
        //public ActionResult Search(Category item)
        //{
        //    //item = new Category();
        //    var search = repository.Post.Where(i => i.Category == item.ID).ToList();
        //    return PartialView("Search", search);
        //}

        public ViewResult SearchByCategory(Category item, int page = 1)
        {
            ViewBag.Title = "Search by categories";
            PostListViewModel search = new PostListViewModel
            {
                Posts = repository.Post
                .Where(i => i.Category == item.ID)
                .OrderBy(p => p.PostedOn)
                .ToList(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = repository.Post.Count()
                }
            };
            ViewBag.Text = String.Format(@"A list of posts by category ""{0}""", item.Name);

            return View("Search", search);
        }

        public ViewResult SearchByTag(Tag item, int page = 1)
        {
            ViewBag.Title = "Search by tags";

            var posts = repository.Post.Where(p => p.PostTags.Any(t => t.Tag.ID.Equals(item.ID))).ToList();
            var postIds = posts.Select(p => p.ID).ToList();

            PostListViewModel search = new PostListViewModel
            {
                Posts = repository.Post
                .Where(p => postIds.Contains(p.ID))
                .OrderBy(p => p.PostedOn)
                .ToList(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = repository.Post.Count()
                }
            };
            ViewBag.Text = String.Format(@"A list of posts by tag ""{0}""", item.Name);

            return View("Search", search);
        }

        public ViewResult Search(string item, int page = 1)
        {
            ViewBag.Title = "Search Result";

            var posts = repository.Post.Where(p => p.Title.Contains(item) || p.ShortDescription.Contains(item) || p.Category1.Name.Contains(item) || p.PostTags.Any(t => t.Tag.Name.Contains(item)));
            var postIds = posts.Select(p => p.ID).ToList();

            PostListViewModel search = new PostListViewModel
            {
                Posts = repository.Post
                .Where(p => postIds.Contains(p.ID))
                .OrderBy(p => p.PostedOn)
                .ToList(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = repository.Post.Count()
                }
            };

            if (item == null)
            {
                ViewBag.Text = String.Format(@"Your search - ""{0}"" - did not match any documents.", item);
            }
            else
            {
                ViewBag.Text = String.Format(@"List of posts found for search text ""{0}""", item);
            }
            return View("Search", search);
        }
    }
}