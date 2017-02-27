using Rhythm.Domain.Concrete;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {
        private RecentArticleWidget articleWidget;
        private Post repositoryArticle;

        public RecentArticleWidget GetArticleWidget()
        {
            int countArticle;
            var allPosts = context.Posts.OrderBy(m => m.ID).ToList();
            var count = context.Posts.Max(p => p.ID);
            Random r = new Random();

            do
            {
                countArticle = r.Next(1, count + 1);
                repositoryArticle = allPosts.SingleOrDefault(p => p.ID == countArticle && p.Published == true);

            }
            while (repositoryArticle == null);

            articleWidget = new RecentArticleWidget()
            {
                ArticleContent = repositoryArticle.ShortDescription,
                Title = repositoryArticle.Title,
                ID = repositoryArticle.ID,
                ImageData = repositoryArticle.ImageData
            };
            return articleWidget;
        }
    }
}
