using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.BL.Interfaces;
using Rhythm.Mappers.ChiefAdmin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class UpdateController : DefaultController
    {
        private TagAdminMapper _tagMapper;
        private CategoryAdminMapper _categoryMapper;
        private PostAdminMapper _postMapper;
        private CommentAdminMapper _commentMapper;

        public UpdateController(IPostProvider postProvider, ICategoryProvider categoryProvider, ITagProvider tagProvider,
            ICommentProvider commentProvider, TagAdminMapper tagMapper, CategoryAdminMapper categoryMapper,
            PostAdminMapper postMapper, CommentAdminMapper commentMapper)
        {
            _postProvider = postProvider;
            _categoryProvider = categoryProvider;
            _tagProvider = tagProvider;
            _commentProvider = commentProvider;
            _tagMapper = tagMapper;
            _categoryMapper = categoryMapper;
            _postMapper = postMapper;
            _commentMapper = commentMapper;
        }

        #region post
        public async Task<ActionResult> Post(int id)
        {
            var post = await _postProvider.GetPostAsync(id);

            var postViewModel = _postMapper.ToPostViewModel(post);

            await DropDownListCategory(postViewModel.Category);
            await TagData(postViewModel);

            return View(postViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Post(PostAdminViewModel postViewModel, int[] selectedTag)
        {
            //var listTag = new List<Tag>();
            //foreach (var item in selectedTag)
            //{
            //    var tag = _repository.Tag.SingleOrDefault(m => m.ID == item);
            //    listTag.Add(tag);
            //}
            //var category = _repository.Category.SingleOrDefault(m => m.ID == postViewModel.Category);

            //postViewModel.Tags = listTag;
            //postViewModel.Category = category;

            //IMapper model = MappingConfig.MapperConfigPost.CreateMapper();
            //Post context = model.Map<Post>(post);

            //await _repository.ChangePostAsync(context);


            var tags = await _tagProvider.GetTagsByIdAsync(selectedTag);
            var categories = await _categoryProvider.GetCategoriesAsync();

            var category = categories.SingleOrDefault(m => m.Id == postViewModel.CategoryId);

            var post = _postMapper.ToPost(postViewModel, tags.ToList(), category);

            await _postProvider.ChangePostAsync(post);

            return RedirectToAction("listPosts", "Home");
        }
        #endregion

        #region image
        public async Task<ActionResult> Image(int id)
        {
            var post = await _postProvider.GetPostAsync(id);
            var imageViewModel = _postMapper.ToImageViewModel(post);

            return View(imageViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Image(ImageAdminViewModel imageViewModel)
        {
            var post = await _postProvider.GetPostAsync(imageViewModel.Id);
            var filePath = SaveFileData(imageViewModel);
            var postEdited = _postMapper.FromImagePathToPost(filePath, imageViewModel.ImageMime, post);

            await _postProvider.ChangePostAsync(postEdited);

            return RedirectToAction("listPosts", "Home");
        }

        #endregion

        #region tag
        public async Task<ActionResult> Tag(int id)
        {
            var tag = await _tagProvider.GetTagAsync(id);
            var tagViewModel = _tagMapper.ToTagViewModel(tag);

            return View(tagViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Tag(TagAdminViewModel tagViewModel)
        {
            var tag = _tagMapper.ToTag(tagViewModel);
            await _tagProvider.ChangeTagAsync(tag);

            return RedirectToAction("listTags", "Home");
        }
        #endregion

        #region category
        public async Task<ActionResult> Category(int id)
        {
            var category = await _categoryProvider.GetCategoryAsync(id);
            var categoryVeiwModel = _categoryMapper.ToCategoryViewModel(category);

            return View(categoryVeiwModel);
        }

        [HttpPost]
        public async Task<ActionResult> Category(CategoryAdminViewModel categoryViewModel)
        {
            var category = _categoryMapper.ToCategory(categoryViewModel);
            await _categoryProvider.ChangeCategoryAsync(category);

            return RedirectToAction("listCategories", "Home");
        }
        #endregion

        #region comment
        public async Task<ActionResult> Comment(int id)
        {
            var comment = await _commentProvider.GetCommentAsync(id);
            var commentViewModel = _commentMapper.ToCommentViewModel(comment);

            return View(commentViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(CommentAdminViewModel commentViewModel)
        {
            var comment = _commentMapper.ToComment(commentViewModel);
            await _commentProvider.ChangeCommentAsync(comment);

            return RedirectToAction("listComments", "Home");
        }
        #endregion

        #region drop
        private void TagDatas(PostAdminViewModel post)
        {

        }
        private async Task TagData(PostAdminViewModel post)
        {
            var tags = await _tagProvider.GetTagsAsync();
            var postTag = new HashSet<int>(post.Tags.Select(c => c.Id));

            var tagsViewModel = _tagMapper.ToTagsViewModelByPostTag(tags, postTag);

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

        #region saveData
        private string SaveFileData(ImageAdminViewModel imageViewModel)
        {
            var fileHashName = imageViewModel.FileBase.GetHashCode().ToString();
            var fileFullName = $"{fileHashName}_{imageViewModel.FileBase.FileName}";
            var filePath = Server.MapPath("~/Content/images/" + fileFullName);

            imageViewModel.FileBase.SaveAs(filePath);

            return filePath;
        }
        #endregion
    }
}