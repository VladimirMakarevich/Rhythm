using System.Web.Mvc;
using NLog;
using System.Threading.Tasks;
using Rhythm.BL.Interfaces;
using Rhythm.Mappers;

namespace Rhythm.Controllers
{
    public class HomeController : DefaultController
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        private PostMapper _postMapper;

        public HomeController(IPostProvider postProvider, PostMapper postMapper)
        {
            _postProvider = postProvider;
            _postMapper = postMapper;
        }

        public async Task<ViewResult> Index(int page = 1)
        {
            var post = await _postProvider.GetPostsAsync();
            var postListViewModel = _postMapper.ToHomePostListViewModel(post, page);

            return View(postListViewModel);
        }
    }
}