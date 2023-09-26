using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls
{
    internal class ListView : ItemsView
    {
        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            var attr = element.Attributes();

            return new Flutter.Widgets.ListView(GetDataSource(attr), GetDataTemplate(processor, element));
        }
    }
}
