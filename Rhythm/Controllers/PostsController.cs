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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Post(PostViewModel commentViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            Comment model = new Comment
        //            {
        //                PostID = commentViewModel.Post.ID,
        //                NameUserSender = commentViewModel.Comment.NameUserSender,
        //                EmailUserSender = commentViewModel.Comment.EmailUserSender,
        //                Comment1 = commentViewModel.Comment.Comment1,
        //                DescriptionComment = commentViewModel.Comment.DescriptionComment,
        //                Post = repository.Post.FirstOrDefault(p => p.ID == commentViewModel.Post.ID),
        //                PostedOn = DateTime.Now
        //            };

        //            string src = await repository.AddCommentAsync(model);
        //            if (src != null)
        //                logger.Error(src);

        //            ModelState.Clear();
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.Clear();
        //            logger.Error("Faild in PostController ActionResult Post [HttpPost]: {0}", ex.Message);
        //        }
        //    }
        //    ModelState.Clear();
        //    PostViewModel post = new PostViewModel
        //    {
        //        Post = repository.Post.FirstOrDefault(p => p.ID == commentViewModel.Post.ID)
        //    };

        //    return View(post);
        //}

        public async Task<FileContentResult> GetImage(int id)
        {
            Post post = await _postProvider.GetPostAsync(id);

            return File(post.ImageData, "image/png");
        }
    }
}