using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using CompositeMVC.Models;

namespace CompositeMVC.Application.Widgets
{
    [WidgetDefinition("postswidget", "Posts Widget")]
    public class PostsWidget : IWidget
    {
        public string Title { get { return "Latest Posts"; } }
        public IDictionary<string, string> Settings { get; set; }

        public IEnumerable<Post> Posts { get; set; }

        public IHtmlString Render(HtmlHelper html)
        {
            return html.Partial("Posts", this);
        }
    }

    public class PostsWidgetBuilder : IWidgetBuilder<PostsWidget>
    {
        public PostsWidget BuildWidget(IDictionary<string, string> settings)
        {
            var widget = new PostsWidget
            {
                Settings = settings,
                Posts = new List<Post>
                {
                    new Post { Title = "Post 1", Summary = "Post 1 Summary" },
                    new Post { Title = "Post 2", Summary = "Post 2 Summary" },
                    new Post { Title = "Post 3", Summary = "Post 3 Summary" }
                }
            };

            return widget;
        }
    }

}