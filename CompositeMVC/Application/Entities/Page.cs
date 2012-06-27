using System;
using System.Collections.Generic;

namespace CompositeMVC.Application.Entities
{
    public class Page
    {
        private readonly IList<PageWidget> widgets = new List<PageWidget>();
        
        public string Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }

        public void AddWidget(PageWidget widget)
        {
            if (widget == null)
                throw new ArgumentNullException("widget");

            widgets.Add(widget);
        }

        public IEnumerable<PageWidget> Widgets
        {
            get { return widgets; }
        }

        // TODO add methods for changing the order of widgets in the list
    }
}