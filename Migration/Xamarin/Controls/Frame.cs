using Migration.Flutter.Widgets;
using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls
{
    internal class Frame : ContentView
    {
        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            var child = BuildChild(processor, element.FirstNode as XElement);

            var attr = element.Attributes();

            return new Container(child, GetBackgroundColor(attr)).BuildWrapperChain(element);
        }
    }
}
