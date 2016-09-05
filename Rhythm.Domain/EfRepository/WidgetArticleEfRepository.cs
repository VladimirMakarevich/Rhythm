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
        private RecentArticleWidget articleWidget;

        public RecentArticleWidget GetArticleWidget()
        {
            int countArticle;
            Random r = new Random();
            try
            {
                var count = context.Posts.OrderBy(p => p.ID).ToArray();

                if (count != null)
                {
                    countArticle = r.Next(1, count.Length);
                }
                else
                {
                    return articleWidget;
                }

                var repositoryArticle = context.Posts.SingleOrDefault(p => p.ID == countArticle);

                articleWidget = new RecentArticleWidget()
                {
                    ArticleContent = repositoryArticle.ShortDescription,
                    Title = repositoryArticle.Title,
                    ID = repositoryArticle.ID,
                    ImageData = repositoryArticle.ImageData
                };
            }
            catch (Exception)
            {
                //NLog
            }


            return articleWidget;
        }
    }
}
