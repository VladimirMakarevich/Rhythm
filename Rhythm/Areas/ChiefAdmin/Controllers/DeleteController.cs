using AutoMapper;
using NLog;
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
    [Authorize]
    public class DeleteController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
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
                string src = repository.DeletePost(postModel);
                if (src != null)
                    logger.Error(src);
            }
            catch (Exception ex)
            {
                logger.Error("Faild in ChiefAdmin/DeleteController/ActionResult Post: ", ex.Message);

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
                string src = repository.DeleteTag(tagModel);
                if (src != null)
                    logger.Error(src);
            }
            catch (Exception ex)
            {
                logger.Error("Faild in ChiefAdmin/DeleteController/ActionResult Tag: ", ex.Message);

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
                string src = repository.DeleteCategory(categoryModel);
                if (src != null)
                    logger.Error(src);
            }
            catch (Exception ex)
            {
                logger.Error("Faild in ChiefAdmin/DeleteController/ActionResult Category: ", ex.Message);

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
                string src = repository.DeleteComment(commentModel);
                if (src != null)
                    logger.Error(src);
            }
            catch (Exception ex)
            {
                logger.Error("Faild in ChiefAdmin/DeleteController/ActionResult Comment: ", ex.Message);

            }
            return RedirectToAction("listComments", "Home");
        }
    }
}