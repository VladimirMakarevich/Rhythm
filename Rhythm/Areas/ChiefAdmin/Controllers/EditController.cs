using AutoMapper;
using NLog;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult Post()
        {
            //TODO: Must modefied!!!!!
            CategoryDropDownList Categories = new CategoryDropDownList
            {
                Category = repository.Category
                    .OrderBy(c => c.ID)
                    .ToList()
            };

            TagDropDownList Tags = new TagDropDownList
            {
                Tag = repository.Tag
                .OrderBy(c => c.ID)
                .ToList()
            };

            ViewBag.Category = new SelectList(Categories.Category, "ID", "Name", 1);
            ViewBag.Tag = new SelectList(Tags.Tag, "ID", "Name", 1);
            return View();
        }

        [HttpPost]
        public ActionResult Post(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Tag> listTag = new List<Tag>();
                    foreach (var item in post.intTag)
                    {
                        var tag = repository.Tag.SingleOrDefault(m => m.ID == item);
                        listTag.Add(tag);
                    }
                    var category = repository.Category.SingleOrDefault(m => m.ID == post.Category);

                    //byte[] image = new byte[post.ImageData.ContentLength];
                    //post.ImageData.InputStream.Read(image, 0, image.Length);
                    post.Tags = listTag;
                    post.Category1 = category;


                    //Post p = new Post
                    //{
                    //    NameSenderPost = post.NameSenderPost,
                    //    Title = post.Title,
                    //    ShortDescription = post.ShortDescription,
                    //    DescriptionPost = post.DescriptionPost,
                    //    UrlSlug = post.UrlSlug,
                    //    Published = post.Published,
                    //    Category = post.Category,
                    //    ImageData = image,
                    //    ImageMime = post.ImageMime,
                    //    Tags = post.Tags,
                    //    Category1 = post.Category1

                    //};

                    IMapper model = MappingConfig.MapperConfigPost.CreateMapper();
                    Post context = model.Map<Post>(post);

                    string src = repository.AddPost(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/DeleteController/ActionResult Post: ", ex.Message);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Tag()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Tag(TagViewModel tagModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper model = MappingConfig.MapperConfigTag.CreateMapper();
                    Tag context = model.Map<Tag>(tagModel);


                    string src = repository.AddTag(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/EditController/ActionResult Tag: ", ex.Message);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Category()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Category(CategoryViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper model = MappingConfig.MapperConfigCategory.CreateMapper();
                    Category context = model.Map<Category>(categoryModel);

                    string src = repository.AddCategory(context);
                    if (src != null)
                        logger.Error(src);
                }
                catch (Exception ex)
                {
                    logger.Error("Faild in ChiefAdmin/EditController/ActionResult Category: ", ex.Message);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}