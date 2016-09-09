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
            this.repository = repository;
        }
        #region post
        public ActionResult Post(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postModel = repository.Post.SingleOrDefault(c => c.ID == id);
            if (postModel == null)
            {
                return HttpNotFound();
            }

            IMapper model = MappingConfig.MapperConfigPost.CreateMapper();
            PostViewModel context = model.Map<PostViewModel>(postModel);

            DropDownListCategory(context.Category);
            TagData(context);

            return View(context);
        }

        private void TagData(PostViewModel post)
        {
            var allTag = repository.Tag;
            var postTag = new HashSet<int>(post.Tags.Select(c => c.ID));
            var viewModel = new List<TagViewModel>();
            foreach (var tag in allTag)
            {
                viewModel.Add(new TagViewModel
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
        public async Task<ActionResult> Post(PostViewModel post, int[] selectedTag)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Tag> listTag = new List<Tag>();
                    foreach (var item in selectedTag)
                    {
                        var tag = repository.Tag.SingleOrDefault(m => m.ID == item);
                        listTag.Add(tag);
                    }
                    var category = repository.Category.SingleOrDefault(m => m.ID == post.Category);

                    post.Tags = listTag;
                    post.Category1 = category;

                    IMapper model = MappingConfig.MapperConfigPost.CreateMapper();
                    Post context = model.Map<Post>(post);

                    string src = await repository.ChangePostAsync(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/UpdateController/ActionResult Post: ", ex.Message);
                }
            }
            return RedirectToAction("listPosts", "Home");
        }
        #endregion

        #region image
        public ActionResult Image(int id)
        {
            ImageViewModel model = new ImageViewModel
            {
                PostID = id
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Image(ImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    byte[] image = new byte[model.ImageData.ContentLength];
                    model.ImageData.InputStream.Read(image, 0, image.Length);
                    var post = repository.Post.SingleOrDefault(m => m.ID == model.PostID);
                    post.ImageData = image;
                    post.ImageMime = model.ImageMime;

                    string src = await repository.ChangePostAsync(post);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/UpdateController/ActionResult Post: ", ex.Message);
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
            var tagModel = repository.Tag.SingleOrDefault(c => c.ID == id);
            if (tagModel == null)
            {
                return HttpNotFound();
            }

            IMapper model = MappingConfig.MapperConfigTag.CreateMapper();
            TagViewModel context = model.Map<TagViewModel>(tagModel);

            return View(context);
        }

        [HttpPost]
        public async Task<ActionResult> Tag(TagViewModel tagModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper model = MappingConfig.MapperConfigTag.CreateMapper();
                    Tag context = model.Map<Tag>(tagModel);

                    string src = await repository.ChangeTagAsync(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/UpdateController/ActionResult Tag: ", ex.Message);
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
            var categoryModel = repository.Category.SingleOrDefault(c => c.ID == id);
            if (categoryModel == null)
            {
                return HttpNotFound();
            }
            IMapper model = MappingConfig.MapperConfigCategory.CreateMapper();
            CategoryViewModel context = model.Map<CategoryViewModel>(categoryModel);

            return View(context);
        }

        [HttpPost]
        public async Task<ActionResult> Category(CategoryViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper model = MappingConfig.MapperConfigCategory.CreateMapper();
                    Category context = model.Map<Category>(categoryModel);

                    string src = await repository.ChangeCategoryAsync(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/UpdateController/ActionResult Category: ", ex.Message);
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
            var commentModel = repository.Comment.SingleOrDefault(c => c.ID == id);
            if (commentModel == null)
            {
                return HttpNotFound();
            }
            IMapper model = MappingConfig.MapperConfigComment.CreateMapper();
            CommentViewModel context = model.Map<CommentViewModel>(commentModel);

            return View(context);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(CommentViewModel commentModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    IMapper model = MappingConfig.MapperConfigComment.CreateMapper();
                    Comment context = model.Map<Comment>(commentModel);

                    string src = await repository.ChangeCommentAsync(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/UpadateController/ActionResult Comment: ", ex.Message);
                }
            }
            return RedirectToAction("listComments", "Home");
        }
        #endregion

        #region drop
        private void DropDownListCategory(object selectedItem = null)
        {
            var Query = from m in repository.Category
                        orderby m.ID
                        select m;
            ViewBag.Category = new SelectList(Query, "ID", "Name", selectedItem);
        }
        #endregion
    }
}