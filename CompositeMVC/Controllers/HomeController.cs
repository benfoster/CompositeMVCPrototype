using System.Collections.Generic;
using System.Web.Mvc;
using CompositeMVC.Models;

namespace CompositeMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var widgets = new List<SimpleWidgetDefinition>
            {
                new SimpleWidgetDefinition("Latest Posts", "home", "latestposts"),
                new SimpleWidgetDefinition("Featured Video", "home", "featuredvideo"),
                new SimpleWidgetDefinition("Latest Tweets", "home", "tweets")
            };

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(widgets);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult LatestPosts()
        {
            var posts = new List<Post>
            {
                new Post { Title = "Post 1", Summary = "Post 1 Summary" },
                new Post { Title = "Post 2", Summary = "Post 2 Summary" },
                new Post { Title = "Post 3", Summary = "Post 3 Summary" }
            };

            return PartialView(posts);
        }

        public ActionResult FeaturedVideo()
        {
            var featured = new Video
            {
                Title = "Brad Wilson - Microsoft's Modern Web Stack",
                Url = "http://vimeo.com/43603472"
            };

            return PartialView(featured);
        }

        public ActionResult Tweets()
        {
            var settings = new TwitterSettings { Handle = "benfosterdev" };
            return PartialView(settings);
        }
    }
}
