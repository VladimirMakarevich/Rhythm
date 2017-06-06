using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.BL.Interfaces;
using Rhythm.Mappers.ChiefAdmin;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class EditController : DefaultController
    {
        private TagAdminMapper _tagMapper;
        private CategoryAdminMapper _categoryMapper;
        private PostAdminMapper _postMapper;

        public EditController(IPostProvider postProvider, ICategoryProvider categoryProvider, ITagProvider tagProvider,
            ICommentProvider commentProvider, TagAdminMapper tagMapper, CategoryAdminMapper categoryMapper,
            PostAdminMapper postMapper)
        {
            _postProvider = postProvider;
            _categoryProvider = categoryProvider;
            _tagProvider = tagProvider;
            _commentProvider = commentProvider;
            _tagMapper = tagMapper;
            _categoryMapper = categoryMapper;
            _postMapper = postMapper;

        }

        #region post
        public async Task<ActionResult> Post()
        {
            await DropDownListCategory();
            await TagData();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Post(PostAdminViewModel postViewModel, int[] selectedTag)
        {
            var tags = await _tagProvider.GetTagsByIdAsync(selectedTag);
            var categories = await _categoryProvider.GetCategoriesAsync();

            var category = categories.FirstOrDefault(m => m.Id == postViewModel.CategoryId);

            var post = _postMapper.ToPost(postViewModel, tags, category);

            var toPost = await _postProvider.AddPostAsync(post);
            await _postProvider.AddReferencedToPost(toPost, selectedTag, postViewModel.CategoryId);

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region tag
        public ActionResult Tag()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Tag(TagAdminViewModel tagViewModel)
        {
            var tag = _tagMapper.ToTag(tagViewModel);

            await _tagProvider.AddTagAsync(tag);

            return RedirectToAction("Index", "Home");
        }
        #endregion  Tag

        #region category
        public ActionResult Category()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Category(CategoryAdminViewModel categoryViewModel)
        {
            var category = _categoryMapper.ToCategory(categoryViewModel);

            await _categoryProvider.AddCategoryAsync(category);

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region drop
        private async Task TagData()
        {
            var tags = await _tagProvider.GetTagsAsync();
            var tagsViewModel = _tagMapper.ToTagsViewModel(tags);

            ViewBag.Tag = tagsViewModel;
        }

        private async Task DropDownListCategory(object selectedItem = null)
        {
            var categories = from m in await _categoryProvider.GetCategoriesAsync()
                             orderby m.Id
                             select m;
            var categoriesViewModel = _categoryMapper.ToCategoriesViewModel(categories);

            ViewBag.Category = new SelectList(categoriesViewModel, "Id", "Name", selectedItem);
        }
        #endregion
    }
}