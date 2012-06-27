using System.Collections.Generic;

namespace CompositeMVC.Application
{
    public interface IWidgetCatalog
    {
        IEnumerable<WidgetDefinition> GetWidgets();
    }
}