using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhythm.BL.Intervaces;
using Rhythm.BL.Models;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Entities;

namespace Rhythm.BL.Provider
{
    public class PostProvider : IPostProvider
    {
        private RecentArticleWidget _articleWidget;
        private IPostRepository _postRepository;
        private Post _post;

        public PostProvider(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<RecentArticleWidget> GetArticleWidgetAsync()
        {
            int countArticle;
            var allPosts = await _postRepository.GetPostsAsync();
            var count = allPosts.Max(p => p.ID);
            Random r = new Random();

            do
            {
                countArticle = r.Next(1, count + 1);
                _post = allPosts.SingleOrDefault(p => p.ID == countArticle && p.Published == true);
            }
            while (_post == null);

            _articleWidget = new RecentArticleWidget()
            {
                ArticleContent = _post.ShortDescription,
                Title = _post.Title,
                ID = _post.ID,
                ImageData = _post.ImageData
            };

            return _articleWidget;
        }
    }
}
