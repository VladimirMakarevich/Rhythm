using Rhythm.BL.Interfaces;
using System.Web.Mvc;

namespace Rhythm.Controllers
{
    public abstract class DefaultController : Controller
    {
        internal IPortfolioProvider _portfolioProvider { get; set; }
        internal IUserProvider _userProvider { get; set; }
        internal ICategoryProvider _categoryProvider { get; set; }
        internal ICommentProvider _commentProvider { get; set; }
        internal IPostProvider _postProvider { get; set; }
        internal IRssProvider _rssProvider { get; set; }
        internal ITagProvider _tagProvider { get; set; }
        internal IArchiveProvider _archiveProvider { get; set; }
        internal IProjectProvider _projectProvider { get; set; }
    }
}