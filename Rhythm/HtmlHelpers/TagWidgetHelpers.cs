using Rhythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.HtmlHelpers
{
    public static class TagWidgetHelpers
    {
        public static MvcHtmlString TagView(this HtmlHelper html, TagView TagView, Func<int, string> tagUrl)
        {
            StringBuilder tagResult = new StringBuilder();

            for (int i = 0; i <= TagView.TotalTag; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", tagUrl(i));
                tag.InnerHtml = i.ToString();
                tagResult.Append(tag.ToString());
            }

            return MvcHtmlString.Create(TagView.ToString());
        }
    }
}