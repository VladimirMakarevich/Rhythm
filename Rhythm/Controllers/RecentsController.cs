using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using Rhythm.BL.Interfaces;
using Rhythm.Mappers;

namespace Rhythm.Controllers
{
    public class RecentsController : DefaultController
    {
        private PostMapper _postMapper;
        private CategoryMapper _categoryMapper;
        private CommentMapper _commentMapper;
        private TagMapper _tagMapper;

        public RecentsController(ICategoryProvider categoryProvider, ICommentProvider commentProvider,
            IPostProvider postProvider, ITagProvider tagProvider, IArchiveProvider archiveProvider,
            TagMapper tagMapper, CommentMapper commentMapper, CategoryMapper categoryMapper,
            PostMapper postMapper)
        {
            _categoryProvider = categoryProvider;
            _commentProvider = commentProvider;
            _postProvider = postProvider;
            _tagProvider = tagProvider;
            _archiveProvider = archiveProvider;
            _postMapper = postMapper;
            _categoryMapper = categoryMapper;
            _commentMapper = commentMapper;
            _tagMapper = tagMapper;
        }

        [ChildActionOnly]
        public async Task<ActionResult> RecentCategories()
        {
            var category = await _categoryProvider.GetCategoryAsync();
            var categoriesRecentViewModel = _categoryMapper.ToCategoriesRecentViewModel(category);

            return PartialView("RecentCategories", categoriesRecentViewModel);
        }

        [ChildActionOnly]
        public async Task<ActionResult> RecentTags()
        {
            var tag = await _tagProvider.GetTagsAsync();
            var tagsRecentViewModel = _tagMapper.ToTagsRecentViewModel(tag);

            return PartialView("RecentTags", tagsRecentViewModel);
        }


        [ChildActionOnly]
        public async Task<ActionResult> RecentPosts()
        {
            var posts = await _postProvider.GetPostsAsync();
            var postRecentViewModel = _postMapper.ToPostsRecentViewModel(posts);

            return PartialView("RecentPosts", postRecentViewModel);
        }

        [ChildActionOnly]
        public async Task<ActionResult> RecentComments()
        {
            var comments = await _commentProvider.GetFiveCommentsListAsync();
            var commentsRecentViewModel = _commentMapper.ToCommetRecentViewModel(comments);

            return PartialView("RecentComments", commentsRecentViewModel);
        }

        [ChildActionOnly]
        public async Task<ActionResult> RecentArticleWidgets()
        {
            var articleWidget = await _postProvider.GetArticleWidgetAsync();

            //if (articleWidget != null)
            //{
            return PartialView("RecentArticleWidgets", articleWidget);
            //}
            //return View();
        }

        [ChildActionOnly]
        public ActionResult RecentArchives()
        {
            // TODO: get archive
            _archiveProvider.AddArchives();
            //new ArchiveCollection(GetPost());
            return PartialView();
        }
    }
}