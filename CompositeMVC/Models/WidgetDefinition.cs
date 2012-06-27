
namespace CompositeMVC.Models
{
    public class SimpleWidgetDefinition
    {
        public SimpleWidgetDefinition(string name, string controller, string action, object routeValues = null)
        {
            Name = name;
            Controller = controller;
            Action = action;
            RouteValues = routeValues;            
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public object RouteValues { get; set; }
    }
}