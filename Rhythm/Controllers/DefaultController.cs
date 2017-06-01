using Rhythm.BL.Interfaces;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public abstract class DefaultController : Controller
    {
        public IPortfolioProvider _portfolioProvider { get; set; }
        public IUserProvider _userProvider { get; set; }
        public ICategoryProvider _categoryProvider { get; set; }
        public ICommentProvider _commentProvider { get; set; }
        public IPostProvider _postProvider { get; set; }
        public IRssProvider _rssProvider { get; set; }
        public ITagProvider _tagProvider { get; set; }
        public IArchiveProvider _archiveProvider { get; set; }
    }
}