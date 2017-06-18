using Rhythm.BL.Interfaces;
using Rhythm.Domain.Entities;
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
        public SearchController(IPostProvider postProvider, SearchResultMapper searchResultMapper, ICategoryProvider categoryProvider, ITagProvider tagProvider)
        {
            _postProvider = postProvider;
            _categoryProvider = categoryProvider;
            _tagProvider = tagProvider;
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
            var tag = await _tagProvider.GetTagAsync(id);

            var tagSearchResultViewModel = _searchResultMapper.ToTagResultViewModel(posts, page, tag.Name);

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

        public async Task<ViewResult> Archive(string yearModel, string monthModel, int page = 1)
        {
            int year;
            Int32.TryParse(yearModel, out year);
            int month;
            Int32.TryParse(monthModel, out month);

            var posts = await _postProvider.GetPostsByArchiveAsync(year, month);

            var archiveSearchResultViewModel = _searchResultMapper.ToArchiveResultViewModel(posts, page, yearModel, monthModel);

            //ViewBag.Title = "Archive result";
            //if (Year == null && Month == null)
            //{
            //    ViewBag.Text = String.Format(@"Your search - ""{0}, {1}"" - did not match any documents.", Year, Month);
            //}
            //else
            //{
            //    ViewBag.Text = String.Format(@"List of posts found for search archive year - ""{0}"", month - ""{1}""", Year, Month);
            //}

            return View("Index", archiveSearchResultViewModel);
        }
    }
}