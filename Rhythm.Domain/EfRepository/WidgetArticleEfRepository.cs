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
            Random r = new Random();

            var count = context.Posts.Max(p => p.ID);
            List<int> q = new List<int>();
            do
            {
                countArticle = r.Next(1, count);
                if (q.Contains(countArticle) == true)
                {
                    continue;
                }
                else
                {
                    repositoryArticle = context.Posts.SingleOrDefault(p => p.ID == countArticle && p.Published == true);
                    q.Add(countArticle);
                }
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
