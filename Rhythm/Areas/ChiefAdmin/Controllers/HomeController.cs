﻿using Rhythm.BL.Interfaces;
using Rhythm.Mappers.ChiefAdmin;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class HomeController : DefaultController
    {
        private TagAdminMapper _tagMapper;
        private CategoryAdminMapper _categoryMapper;
        private PostAdminMapper _postMapper;
        private CommentAdminMapper _commentMapper;
        private ContentAdminMapper _contentMapper;

        public HomeController(IPostProvider postProvider, ICategoryProvider categoryProvider, ITagProvider tagProvider,
            ICommentProvider commentProvider, TagAdminMapper tagMapper, CategoryAdminMapper categoryMapper,
            PostAdminMapper postMapper, CommentAdminMapper commentMapper, ContentAdminMapper contentMapper)
        {
            _postProvider = postProvider;
            _categoryProvider = categoryProvider;
            _tagProvider = tagProvider;
            _commentProvider = commentProvider;
            _tagMapper = tagMapper;
            _categoryMapper = categoryMapper;
            _postMapper = postMapper;
            _commentMapper = commentMapper;
            _contentMapper = contentMapper;
        }

        public async Task<ViewResult> Index()
        {
            var categories = await _categoryProvider.GetCategoriesAsync();
            var categoriesViewModel = _categoryMapper.ToCategoriesViewModel(categories);

            var tags = await _tagProvider.GetTagsAsync();
            var tagsViewModel = _tagMapper.ToTagsViewModel(tags);

            var posts = await _postProvider.GetPostsAsync();
            var postsViewModel = _postMapper.ToPostsViewModel(posts);

            var comments = await _commentProvider.GetCommentsAsync();
            var commentsViewModel = _commentMapper.ToCommentsViewModel(comments);

            var contentViewModel = _contentMapper.ToContentViewModel(categoriesViewModel, tagsViewModel, postsViewModel, commentsViewModel);

            return View(contentViewModel);
        }

        public async Task<ViewResult> listCategories()
        {
            var categories = await _categoryProvider.GetCategoriesAsync();
            var categoriesViewModel = _categoryMapper.ToCategoriesViewModel(categories);

            return View(categoriesViewModel);
        }
        public async Task<ViewResult> listTags()
        {
            var tags = await _tagProvider.GetTagsAsync();
            var tagsViewModel = _tagMapper.ToTagsViewModel(tags);

            return View(tagsViewModel);
        }
        public async Task<ViewResult> listPosts()
        {
            var posts = await _postProvider.GetPostsAsync();
            var postsViewModel = _postMapper.ToPostsViewModel(posts);

            return View(postsViewModel);
        }
        public async Task<ViewResult> listComments()
        {
            var comments = await _commentProvider.GetCommentsAsync();
            var commentsViewModel = _commentMapper.ToCommentsViewModel(comments);

            return View(commentsViewModel);
        }

        public async Task<FileContentResult> GetImage(int id)
        {
            var post = await _postProvider.GetPostAsync(id);

            if (post.ImagePath != null)
            {
                var dataByte = System.IO.File.ReadAllBytes(post.ImagePath);

                return File(dataByte, "image/png");
            }

            return null;
        }
    }
}