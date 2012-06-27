using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CompositeMVC.Application.Widgets
{
    [WidgetDefinition("twitterwidget", "Twitter Widget")]
    public class TwitterWidget : IWidget
    {
        public string Title { get { return "Twitter Widget"; } }
        public IDictionary<string, string> Settings { get; set; }

        public IHtmlString Render(HtmlHelper html)
        {
            return html.Partial("Tweets", this);
        }
    }
}