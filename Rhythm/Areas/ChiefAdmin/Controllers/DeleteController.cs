using Rhythm.BL.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{
    [Authorize]
    public class DeleteController : DefaultController
    {
        public DeleteController(IPostProvider postProvider, ICategoryProvider categoryProvider, ITagProvider tagProvider,
            ICommentProvider commentProvider)
        {
            _postProvider = postProvider;
            _categoryProvider = categoryProvider;
            _tagProvider = tagProvider;
            _commentProvider = commentProvider;

        }


        public async Task<ActionResult> Post(int id)
        {
            var post = await _postProvider.GetPostAsync(id);

            await _postProvider.DeletePostAsync(post);

            return RedirectToAction("listPosts", "Home");
        }


        public async Task<ActionResult> Tag(int id)
        {
            var tag = await _tagProvider.GetTagAsync(id);

            await _tagProvider.DeleteTagAsync(tag);

            return RedirectToAction("listTags", "Home");
        }

        public async Task<ActionResult> Category(int id)
        {
            var category = await _categoryProvider.GetCategoryAsync(id);

            await _categoryProvider.DeleteCategoryAsync(category);

            return RedirectToAction("listCategories", "Home");
        }

        public async Task<ActionResult> Comment(int id)
        {
            var comment = await _commentProvider.GetCommentAsync(id);

            await _commentProvider.DeleteCommentAsync(comment);

            return RedirectToAction("listComments", "Home");
        }

        public async Task<ActionResult> Image(int id)
        {
            var post = await _postProvider.GetPostAsync(id);

            if ((System.IO.File.Exists(post.ImagePath)))
            {
                System.IO.File.Delete(post.ImagePath);
                await _postProvider.RemoveImageByPostAsync(post);
            }

            return RedirectToAction("Image", "Update", new { id = id });
        }
    }
}