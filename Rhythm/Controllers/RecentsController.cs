using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using Rhythm.BL.Interfaces;
using Rhythm.Mappers;
using Rhythm.BL.Provider;

namespace Rhythm.Controllers
{
    public class RecentsController : DefaultController
    {
        private PostMapper _postMapper;
        private CategoryMapper _categoryMapper;
        private CommentMapper _commentMapper;
        private TagMapper _tagMapper;
        private RecentContentMapper _recentContentMapper;

        public RecentsController(ICategoryProvider categoryProvider, ICommentProvider commentProvider,
            IPostProvider postProvider, ITagProvider tagProvider, TagMapper tagMapper, 
            CommentMapper commentMapper, CategoryMapper categoryMapper,
            PostMapper postMapper, RecentContentMapper recentContentMapper)
        {
            _categoryProvider = categoryProvider;
            _commentProvider = commentProvider;
            _postProvider = postProvider;
            _tagProvider = tagProvider;
            _postMapper = postMapper;
            _categoryMapper = categoryMapper;
            _commentMapper = commentMapper;
            _tagMapper = tagMapper;
            _recentContentMapper = recentContentMapper;
        }

        //public async Task<ActionResult> RecentContent()
        //{
        //    var category = await _categoryProvider.GetCategoriesAsync();
        //    var categoriesRecentViewModel = _categoryMapper.ToCategoriesRecentViewModel(category);

        //    var tag = await _tagProvider.GetTagsAsync();
        //    var tagsRecentViewModel = _tagMapper.ToTagsRecentViewModel(tag);

        //    var posts = await _postProvider.GetPostsAsync();
        //    var postRecentViewModel = _postMapper.ToPostsRecentViewModel(posts);

        //    var comments = await _commentProvider.GetFiveCommentsListAsync();
        //    var commentsRecentViewModel = _commentMapper.ToCommetRecentViewModel(comments, posts);

        //    var post = await _postProvider.GetPostWidgetAsync();
        //    var articleWidget = _postMapper.ToArticleWidget(post);

        //    var recentContentViewModel = _recentContentMapper.ToRecentContentViewModel(categoriesRecentViewModel,
        //        tagsRecentViewModel, postRecentViewModel, commentsRecentViewModel, articleWidget);


        //    return PartialView("_SideBar", recentContentViewModel);
        //}

        [ChildActionOnly]
        public ActionResult RecentCategories()
        {
            var category = _categoryProvider.GetCategories();
            var categoriesRecentViewModel = _categoryMapper.ToCategoriesRecentViewModel(category);

            return PartialView("RecentCategories", categoriesRecentViewModel);
        }

        [ChildActionOnly]
        public ActionResult RecentTags()
        {
            var tag = _tagProvider.GetTags();
            var tagsRecentViewModel = _tagMapper.ToTagsRecentViewModel(tag);

            return PartialView("RecentTags", tagsRecentViewModel);
        }


        [ChildActionOnly]
        public ActionResult RecentPosts()
        {
            var posts = _postProvider.GetPosts();
            var postRecentViewModel = _postMapper.ToPostsRecentViewModel(posts);

            return PartialView("RecentPosts", postRecentViewModel);
        }

        [ChildActionOnly]
        public ActionResult RecentComments()
        {
            var comments = _commentProvider.GetFiveCommentsList();
            var posts = _postProvider.GetPosts();
            var commentsRecentViewModel = _commentMapper.ToCommetRecentViewModel(comments, posts);

            return PartialView("RecentComments", commentsRecentViewModel);
        }

        [ChildActionOnly]
        public ActionResult RecentArticleWidgets()
        {
            var post = _postProvider.GetPostWidget();
            var articleWidget = _postMapper.ToArticleWidget(post);

            return PartialView("RecentArticleWidgets", articleWidget);
        }

        [ChildActionOnly]
        public ActionResult RecentArchives()
        {
            var posts = _postProvider.GetPosts();
            ArchiveProvider archive = new ArchiveProvider(posts.ToList());

            return PartialView(archive);
        }
    }
}