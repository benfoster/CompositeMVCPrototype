using System.Collections.Generic;

namespace CompositeMVC.Application
{
    public class PageModel
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }

        public List<IWidget> Widgets { get; set; }

        public PageModel()
        {
            Widgets = new List<IWidget>();
        }
    }
}