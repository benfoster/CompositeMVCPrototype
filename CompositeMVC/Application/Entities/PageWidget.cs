using System.Collections.Generic;
namespace CompositeMVC.Application.Entities
{
    public class PageWidget
    {
        public string WidgetDefinitionId { get; set; }
        public IDictionary<string, string> Settings { get; set; }
    }
}