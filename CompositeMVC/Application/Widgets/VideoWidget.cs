using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CompositeMVC.Application.Widgets
{
    [WidgetDefinition("videowidget", "Video Widget")]
    public class VideoWidget : IWidget
    {
        public string Title { get { return "Featured Video"; } }
        public IDictionary<string, string> Settings { get; set; }

        public IHtmlString Render(HtmlHelper html)
        {
            return html.Partial("Video", this);
        }
    }
}