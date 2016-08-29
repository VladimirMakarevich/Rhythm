using Rhythm.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {
        public RecentArticleWidget GetArticleWidget()
        {
            Random r = new Random();
            var count = context.Posts.OrderBy(p => p.ID).ToArray();
            var countArticle = r.Next(1, count.Length);

            var repositoryArticle = context.Posts.Single(p => p.ID == countArticle);

            var articleWidget = new RecentArticleWidget()
            {
                ArticleContent = repositoryArticle.ShortDescription,
                Title = repositoryArticle.Title,
                ID = repositoryArticle.ID
            };

            return articleWidget;
        }
    }
}
