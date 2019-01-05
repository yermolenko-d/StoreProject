using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Store.MVC.Models;

namespace Store.MVC.HtmlHelpers
{
    public static class PageSwitch
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                                   PageInfo pageInfo,
                                                   Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i < pageInfo.TotalPages; i++)
            {
                //create tag
                TagBuilder tag = new TagBuilder("a");
                //add attributes
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                //making button selected
                if (i == pageInfo.CurrentPage)
                {
                    tag.AddCssClass("Selected");
                    tag.AddCssClass("btn-primary");
                }
                //добавляет сss class 
                tag.AddCssClass("btn btn-default");
                //присоединяет элементы в тэг
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}