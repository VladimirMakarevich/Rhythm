using AutoMapper;
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

    public class EditController : DefaultController
    {
        public EditController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Post()
        {
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

                    byte[] image = new byte[post.ImageData.ContentLength];
                    post.ImageData.InputStream.Read(image, 0, image.Length);

                    Post p = new Post
                    {
                        NameSenderPost = post.NameSenderPost,
                        Title = post.Title,
                        ShortDescription = post.ShortDescription,
                        DescriptionPost = post.DescriptionPost,
                        UrlSlug = post.UrlSlug,
                        Published = post.Published,
                        Category = post.Category,
                        ImageData = image,
                        ImageMime = post.ImageMime,
                        Tags = listTag,
                        Category1 = category

                    };
                    repository.AddPost(p);
                }
                catch (Exception)
                {
                    //TODO: NLog
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
                    //var model = (Tag)modelMapperTag.Map(tagModel, typeof(TagViewModel), typeof(Tag));
                    IMapper model = MappingConfig.MapperConfigTag.CreateMapper();
                    Tag context = model.Map<Tag>(tagModel);


                    repository.AddTag(context);
                }
                catch (Exception)
                {
                    //TODOL Nlog
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
                    //var model = (Category)modelMapperCategory.Map(categoryModel, typeof(CategoryViewModel), typeof(Category));
                    IMapper model = MappingConfig.MapperConfigCategory.CreateMapper();
                    Category context = model.Map<Category>(categoryModel);


                    repository.AddCategory(context);
                }
                catch (Exception)
                {
                    //TODOL Nlog
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}