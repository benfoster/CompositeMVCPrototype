
using System.Collections.Generic;
namespace CompositeMVC.Application
{
    public interface IWidgetBuilder<TWidget> where TWidget : IWidget
    {
        TWidget BuildWidget(IDictionary<string, string> settings);
    }
}