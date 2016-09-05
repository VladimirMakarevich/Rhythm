using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{

    public class UpdateController : DefaultController
    {
        public UpdateController(IRepository repository)
        {
            this.repository = repository;
        }


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
            return View(context);
        }


        [HttpPost]
        public ActionResult Post(PostViewModel post)
        {
            return RedirectToAction("Index", "Home");
        }

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
        public ActionResult Tag(TagViewModel tagModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper model = MappingConfig.MapperConfigTag.CreateMapper();
                    Tag context = model.Map<Tag>(tagModel);

                    repository.ChangeTag(context);
                }
                catch (Exception)
                {
                    //TODO: NLog
                }
            }
            return RedirectToAction("listTags", "Home");
        }

        //public ActionResult allCategory()
        //{
        //    var listCat = repository.Category.OrderBy(c => c.ID).ToList();
        //    return View(listCat);
        //}

        //public ActionResult Category()
        //{
        //    var listCat = repository.Category.OrderBy(c => c.ID).ToList();
        //    return View(listCat);
        //}

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
        public ActionResult Category(CategoryViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper model = MappingConfig.MapperConfigCategory.CreateMapper();
                    Category context = model.Map<Category>(categoryModel);

                    repository.ChangeCategory(context);
                }
                catch (Exception)
                {
                    //TODO: NLog
                }
            }
            return RedirectToAction("listCategories", "Home");
        }

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
        public ActionResult Comment(CommentViewModel commentModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    IMapper model = MappingConfig.MapperConfigComment.CreateMapper();
                    Comment context = model.Map<Comment>(commentModel);

                    repository.ChangeComment(context);
                }
                catch (Exception)
                {
                    //TODO: NLog
                }
            }
            return RedirectToAction("listComments", "Home");
        }
    }
}