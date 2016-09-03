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


        public ICollection<PostTag> TagCollection(List<int> item)
        {
            var tagList = new List<PostTag>();

            foreach (var i in item)
            {
                var q = repository.Tag.FirstOrDefault(t => t.PostTags == null);
                var tt = repository.Post.FirstOrDefault(p => p.PostTags == null);

                //tagList.Add();
            }
            //if (tags.Length > 0)
            //{
            //    post.Tags = new List<Tag>();

            //    foreach (var tag in tags)
            //    {
            //        post.Tags.Add(_blogRepository.Tag(int.Parse(tag.Trim())));
            //    }
            //}
            return tagList;
        }

        [HttpPost]
        public ActionResult Post(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tagList = TagCollection(post.Tag);

                    byte[] image = new byte[post.imageData.ContentLength];
                    post.imageData.InputStream.Read(image, 0, image.Length);

                    Post p = new Post
                    {
                        NameSenderPost = post.NameSenderPost,
                        Title = post.Title,
                        ShortDescription = post.ShortDescription,
                        DescriptionPost = post.DescriptionPost,
                        UrlSlug = post.UrlSlug,
                        Published = post.Published,
                        Category = post.model,
                        ImageData = image,
                        ImageMime = post.ImageMime,
                        //PostTags = 


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