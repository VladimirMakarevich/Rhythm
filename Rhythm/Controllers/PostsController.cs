using NLog;
using Rhythm.BL.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.Mappers;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public class PostsController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        private PostMapper _postMapper;

        public PostsController(IPostProvider postProvider, PostMapper postMapper)
        {
            _postProvider = postProvider;
            _postMapper = postMapper;
        }

        public async Task<ViewResult> Index(int page = 1)
        {
            var post = await _postProvider.GetPostsAsync();
            var postListViewModel = _postMapper.ToPostListViewModel(post, page);

            return View(postListViewModel);
        }

        public async Task<ActionResult> Post(int id, bool? flag)
        {
            var posts = await _postProvider.GetPostsAsync();
            int count = posts.Where(p => p.Published == true).Max(m => m.Id);

            var post = await _postProvider.GetPostWithConditionAsync(id, flag);

            var postSingleViewModel = _postMapper.ToPostSingleViewModel(post, count);

            return View(postSingleViewModel);
        }

        public async Task<FileContentResult> GetImage(int id)
        {
            var post = await _postProvider.GetPostAsync(id);

            if (post.ImagePath != null)
            {
                var dataByte = System.IO.File.ReadAllBytes(post.ImagePath);

                return File(dataByte, "image/png");
            }

            return null;
        }
    }
}