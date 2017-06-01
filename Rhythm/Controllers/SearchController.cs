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
            this.repository = repository;
        }

        public ViewResult Category(Category item, int page = 1)
        {
            ViewBag.Title = "Search by categories";
            PostListViewModel search = new PostListViewModel
            {
                Posts = repository.Post
                .Where(i => i.Category == item.ID)
                    .OrderBy(p => p.ID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize).ToArray().Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = repository.Post.Count()
                }
            };
            ViewBag.Text = String.Format(@"A list of posts by model ""{0}""", item.Name);

            return View("Index", search);
        }

        public ViewResult Tag(Tag item, int page = 1)
        {
            ViewBag.Title = "Search by tags";

            var posts = repository.Post.Where(p => p.Tags.Any(t => t.ID.Equals(item.ID))).ToList();
            var postIds = posts.Select(p => p.ID).ToList();

            PostListViewModel search = new PostListViewModel
            {
                Posts = repository.Post
                .Where(p => postIds.Contains(p.ID))
                    .OrderBy(p => p.ID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize).ToArray().Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = repository.Post.Count()
                }
            };
            ViewBag.Text = String.Format(@"A list of posts by tag ""{0}""", item.Name);

            return View("Index", search);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ViewResult Index(string item, int page = 1)
        {
            ViewBag.Title = "Search Result";

            var posts = repository.Post.Where(p => p.Title.Contains(item) ||
            p.ShortDescription.Contains(item) ||
            p.Category1.Name.Contains(item) ||
            p.Tags.Any(t => t.Name.Contains(item)))
                .Select(p => p.ID).ToList();

            if (posts == null)
            {
                ViewBag.Text = String.Format(@"Your search - ""{0}"" - did not match any documents.", item);
                return View();
            }
            else
            {
                ViewBag.Text = String.Format(@"List of posts found for search text ""{0}""", item);
            }

            PostListViewModel search = new PostListViewModel
            {
                Posts = repository.Post
                    .Where(p => posts.Contains(p.ID) && p.Published == true)
                    .OrderBy(p => p.ID)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = repository.Post.Count()
                }
            };

            return View("Index", search);
        }

        public ViewResult Archive(string Year, string Month, int page = 1)
        {
            int year = Int32.Parse(Year);
            int month = Int32.Parse(Month);

            ViewBag.Title = "Archive result";
            var posts = repository.Post.Where(m => m.PostedOn.Month == month && m.PostedOn.Year == year).Select(p => p.ID).ToList();

            PostListViewModel source = new PostListViewModel
            {
                Posts = repository.Post
                    .Where(p => posts.Contains(p.ID))
                    .OrderBy(p => p.ID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize).ToArray().Reverse(),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = repository.Post.Count()
                }
            };

            if (Year == null && Month == null)
            {
                ViewBag.Text = String.Format(@"Your search - ""{0}, {1}"" - did not match any documents.", Year, Month);
            }
            else
            {
                ViewBag.Text = String.Format(@"List of posts found for search archive year - ""{0}"", month - ""{1}""", Year, Month);
            }

            return View("Index", source);
        }
    }
}