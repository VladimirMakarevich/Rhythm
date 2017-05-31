using Rhythm.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhythm.BL.Intervaces
{
    public interface IPostProvider
    {
        Task<RecentArticleWidget> GetArticleWidgetAsync();
    }
}
