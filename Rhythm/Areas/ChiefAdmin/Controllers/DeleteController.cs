using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{

    public class DeleteController : DefaultController
    {
        public DeleteController(IRepository repository)
        {
            this.repository = repository;
        }


        public ActionResult Post(int? id)
        {
            try
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
                repository.DeletePost(postModel);
            }
            catch (Exception)
            {
                //TODO: NLog
            }
            return RedirectToAction("listPosts", "Home");
        }


        public ActionResult Tag(int? id)
        {
            try
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
                repository.DeleteTag(tagModel);
            }
            catch (Exception)
            {
                //TODO: NLog
            }
            return RedirectToAction("listTags", "Home");
        }

        public ActionResult Category(int? id)
        {
            try
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
                repository.DeleteCategory(categoryModel);
            }
            catch (Exception)
            {
                //TODO: NLog
            }
            return RedirectToAction("listCategories", "Home");
        }

        public ActionResult Comment(int? id)
        {
            try
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
                repository.DeleteComment(commentModel);
            }
            catch (Exception)
            {
                //TODO: NLog
            }
            return RedirectToAction("listComments", "Home");
        }
    }
}