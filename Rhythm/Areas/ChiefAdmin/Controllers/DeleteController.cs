using NLog;
using Rhythm.BL.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class DeleteController : DefaultController
    {
        public DeleteController(IPostProvider postProvider, ICategoryProvider categoryProvider, ITagProvider tagProvider)
        {
            _postProvider = postProvider;
            _categoryProvider = categoryProvider;
            _tagProvider = tagProvider;

        }


        public async Task<ActionResult> Post(int id)
        {
            var postModel = await _postProvider.GetPostAsync(id);

            await _repository.DeletePostAsync(postModel);

            return RedirectToAction("listPosts", "Home");
        }


        public async Task<ActionResult> Tag(int? id)
        {
            try
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
                string src = await _repository.DeleteTagAsync(tagModel);
                if (src != null)
                    logger.Error(src);
            }
            catch (Exception ex)
            {
                logger.Error("Faild in ChiefAdmin/DeleteController/ActionResult Tag: {0}", ex.Message);
            }
            return RedirectToAction("listTags", "Home");
        }

        public async Task<ActionResult> Category(int? id)
        {
            try
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
                string src = await _repository.DeleteCategoryAsync(categoryModel);
                if (src != null)
                    logger.Error(src);
            }
            catch (Exception ex)
            {
                logger.Error("Faild in ChiefAdmin/DeleteController/ActionResult Category: {0}", ex.Message);
            }
            return RedirectToAction("listCategories", "Home");
        }

        public async Task<ActionResult> Comment(int? id)
        {
            try
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
                string src = await _repository.DeleteCommentAsync(commentModel);
                if (src != null)
                    logger.Error(src);
            }
            catch (Exception ex)
            {
                logger.Error("Faild in ChiefAdmin/DeleteController/ActionResult Comment: {0}", ex.Message);
            }
            return RedirectToAction("listComments", "Home");
        }
    }
}