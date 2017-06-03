using Rhythm.BL.Interfaces;
using Rhythm.Mappers;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class SearchController : DefaultController
    {
        private SearchResultMapper _searchResultMapper;
        public SearchController(IPostProvider postProvider, SearchResultMapper searchResultMapper)
        {
            _postProvider = postProvider;
            _searchResultMapper = searchResultMapper;
    }

        public async Task<ViewResult> Category(int id, int page = 1)
        {
            var posts = await _postProvider.GetPostsByCategoryAsync(id);
            var category = await _categoryProvider.GetCategoryAsync(id);

            var categorySearchResultViewModel = _searchResultMapper.ToCategoryResultViewModel(posts, page, category.Name);

            return View("Index", categorySearchResultViewModel);
        }

        public async Task<ViewResult> Tag(int id, int page = 1)
        {
            var posts = await _postProvider.GetPostsByTagAsync(id);
            var category = await _categoryProvider.GetCategoryAsync(id);

            var tagSearchResultViewModel = _searchResultMapper.ToCategoryResultViewModel(posts, page, category.Name);

            return View("Index", tagSearchResultViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ViewResult> Index(string searchText, int page = 1)
        {
            var posts = await _postProvider.GetPostsByTextAsync(searchText);
            SearchResultViewModel searchResultViewModel;

            if (posts == null)
            {
                searchResultViewModel = _searchResultMapper.ToSearchResultViewModel(posts, page, searchText);

                return View("Index", searchResultViewModel);
            }

            searchResultViewModel = _searchResultMapper.ToSearchResultViewModel(posts, page, searchText);

            return View("Index", searchResultViewModel);
        }

        //public ViewResult Archive(string Year, string Month, int page = 1)
        //{
        //    int year = Int32.Parse(Year);
        //    int month = Int32.Parse(Month);

        //    ViewBag.Title = "Archive result";
        //    var posts = repository.Post.Where(m => m.PostedOn.Month == month && m.PostedOn.Year == year).Select(p => p.ID).ToList();

        //    PostListViewModel source = new PostListViewModel
        //    {
        //        Posts = repository.Post
        //            .Where(p => posts.Contains(p.ID))
        //            .OrderBy(p => p.ID)
        //            .Skip((page - 1) * PageSize)
        //            .Take(PageSize).ToArray().Reverse(),

        //        PagingView = new ListView
        //        {
        //            CurrentPage = page,
        //            PostsPerPage = PageSize,
        //            TotalPosts = repository.Post.Count()
        //        }
        //    };

        //    if (Year == null && Month == null)
        //    {
        //        ViewBag.Text = String.Format(@"Your search - ""{0}, {1}"" - did not match any documents.", Year, Month);
        //    }
        //    else
        //    {
        //        ViewBag.Text = String.Format(@"List of posts found for search archive year - ""{0}"", month - ""{1}""", Year, Month);
        //    }

        //    return View("Index", source);
        //}
    }
}