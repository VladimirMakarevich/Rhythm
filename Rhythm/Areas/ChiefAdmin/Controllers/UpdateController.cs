using AutoMapper;
using NLog;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class UpdateController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        public UpdateController(IRepository repository)
        {
            this._repository = repository;
        }

        #region post
        public ActionResult Post(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postModel = _repository.Post.SingleOrDefault(c => c.ID == id);
            if (postModel == null)
            {
                return HttpNotFound();
            }

            IMapper model = MappingConfig.MapperConfigPost.CreateMapper();
            PostAdminViewModel context = model.Map<PostAdminViewModel>(postModel);

            DropDownListCategory(context.Category);
            TagData(context);

            return View(context);
        }

        private void TagData(PostAdminViewModel post)
        {
            var allTag = _repository.Tag;
            var postTag = new HashSet<int>(post.Tags.Select(c => c.ID));
            var viewModel = new List<TagAdminViewModel>();
            foreach (var tag in allTag)
            {
                viewModel.Add(new TagAdminViewModel
                {
                    ID = tag.ID,
                    Name = tag.Name,
                    Assigned = postTag.Contains(tag.ID)
                });
            }
            ViewBag.Tag = viewModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Post(PostAdminViewModel post, int[] selectedTag)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Tag> listTag = new List<Tag>();
                    foreach (var item in selectedTag)
                    {
                        var tag = _repository.Tag.SingleOrDefault(m => m.ID == item);
                        listTag.Add(tag);
                    }
                    var category = _repository.Category.SingleOrDefault(m => m.ID == post.Category);

                    post.Tags = listTag;
                    post.Category1 = category;

                    IMapper model = MappingConfig.MapperConfigPost.CreateMapper();
                    Post context = model.Map<Post>(post);

                    string src = await _repository.ChangePostAsync(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/UpdateController/ActionResult Post: {0}", ex.Message);
                }
            }
            return RedirectToAction("listPosts", "Home");
        }
        #endregion

        #region image
        public ActionResult Image(int id)
        {
            var post = _repository.Post.FirstOrDefault(m => m.ID == id);
            ImageAdminViewModel model = new ImageViewModel
            {
                PostID = id,
                ImageDataByte = post.ImageData,
                ImageMime = post.ImageMime
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Image(ImageAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    byte[] image = new byte[model.ImageData.ContentLength];
                    model.ImageData.InputStream.Read(image, 0, image.Length);
                    var post = _repository.Post.SingleOrDefault(m => m.ID == model.PostID);
                    post.ImageData = image;
                    post.ImageMime = model.ImageMime;

                    string src = await _repository.ChangePostAsync(post);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/UpdateController/ActionResult Post: {0}", ex.Message);
                }
            }
            return RedirectToAction("listPosts", "Home");
        }

        #endregion

        #region tag
        public ActionResult Tag(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tagModel = _repository.Tag.SingleOrDefault(c => c.ID == id);
            if (tagModel == null)
            {
                return HttpNotFound();
            }

            IMapper model = MappingConfig.MapperConfigTag.CreateMapper();
            TagAdminViewModel context = model.Map<TagAdminViewModel>(tagModel);

            return View(context);
        }

        [HttpPost]
        public async Task<ActionResult> Tag(TagAdminViewModel tagModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper model = MappingConfig.MapperConfigTag.CreateMapper();
                    Tag context = model.Map<Tag>(tagModel);

                    string src = await _repository.ChangeTagAsync(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/UpdateController/ActionResult Tag: {0}", ex.Message);
                }
            }
            return RedirectToAction("listTags", "Home");
        }
        #endregion

        #region category
        public ActionResult Category(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoryModel = _repository.Category.SingleOrDefault(c => c.ID == id);
            if (categoryModel == null)
            {
                return HttpNotFound();
            }
            IMapper model = MappingConfig.MapperConfigCategory.CreateMapper();
            CategoryAdminViewModel context = model.Map<CategoryAdminViewModel>(categoryModel);

            return View(context);
        }

        [HttpPost]
        public async Task<ActionResult> Category(CategoryAdminViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper model = MappingConfig.MapperConfigCategory.CreateMapper();
                    Category context = model.Map<Category>(categoryModel);

                    string src = await _repository.ChangeCategoryAsync(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/UpdateController/ActionResult Category: {0}", ex.Message);
                }
            }
            return RedirectToAction("listCategories", "Home");
        }
        #endregion

        #region comment
        public ActionResult Comment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var commentModel = _repository.Comment.SingleOrDefault(c => c.ID == id);
            if (commentModel == null)
            {
                return HttpNotFound();
            }
            IMapper model = MappingConfig.MapperConfigComment.CreateMapper();
            CommentAdminViewModel context = model.Map<CommentAdminViewModel>(commentModel);

            return View(context);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(CommentAdminViewModel commentModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    IMapper model = MappingConfig.MapperConfigComment.CreateMapper();
                    Comment context = model.Map<Comment>(commentModel);

                    string src = await _repository.ChangeCommentAsync(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/UpadateController/ActionResult Comment: {0}", ex.Message);
                }
            }
            return RedirectToAction("listComments", "Home");
        }
        #endregion

        #region drop
        private void DropDownListCategory(object selectedItem = null)
        {
            var Query = from m in _repository.Category
                        orderby m.ID
                        select m;
            ViewBag.Category = new SelectList(Query, "ID", "Name", selectedItem);
        }
        #endregion
    }
}