using System;
using System.Text;
using System.Web.Mvc;
using IhorsSlaves.Models;

namespace IhorsSlaves.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a"); //Робить тег <a>
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag);
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}