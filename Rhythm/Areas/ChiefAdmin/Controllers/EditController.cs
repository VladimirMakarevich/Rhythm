using AutoMapper;
using NLog;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class EditController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public EditController(IRepository repository)
        {
            this.repository = repository;
        }

        #region post
        public ActionResult Post()
        {
            DropDownListCategory();
            TagData();
            return View();
        }

        private void TagData()
        {
            var allTag = repository.Tag;
            var viewModel = new List<TagViewModel>();
            foreach (var tag in allTag)
            {
                viewModel.Add(new TagViewModel
                {
                    ID = tag.ID,
                    Name = tag.Name
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
                    //byte[] image = new byte[post.ImageData.ContentLength];
                    //post.ImageData.InputStream.Read(image, 0, image.Length);
                    post.Tags = listTag;
                    post.Category1 = category;

                    IMapper model = MappingConfig.MapperConfigPost.CreateMapper();
                    Post context = model.Map<Post>(post);

                    string src = await repository.AddPostAsync(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/DeleteController/ActionResult Post: {0}", ex.Message);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region tag
        public ActionResult Tag()
        {
            return View();
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


                    string src = await repository.AddTagAsync(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/EditController/ActionResult Tag: {0}", ex.Message);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion  Tag

        #region category
        public ActionResult Category()
        {
            return View();
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

                    string src = await repository.AddCategoryAsync(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/EditController/ActionResult Category: {0}", ex.Message);
                }
            }
            return RedirectToAction("Index", "Home");
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