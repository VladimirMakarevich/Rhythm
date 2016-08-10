using Rhythm.Domain.Model;
using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Rhythm.HtmlHelpers
{
    public static class TagWidgetHelpers
    {
        public static MvcHtmlString TagView(this HtmlHelper html, Tag tag)
        {
            return html.ActionLink(tag.Name, "Tag", "Blog", new { tag = tag.UrlSlug }, new { title = String.Format("See all posts in {0}", tag.Name ) } );
        }
    }
}