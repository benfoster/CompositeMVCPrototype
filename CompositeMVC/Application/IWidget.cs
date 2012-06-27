using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace CompositeMVC.Application
{
    public interface IWidget
    {
        string Title { get; }
        IDictionary<string, string> Settings { get; set; }
        IHtmlString Render(HtmlHelper html);
    }
}