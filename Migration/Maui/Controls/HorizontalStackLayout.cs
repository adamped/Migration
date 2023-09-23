using Migration.Flutter.Widgets;
using Migration.Flutter.Widgets.Base;
using Migration.Xamarin;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Maui.Controls
{
    internal class HorizontalStackLayout : MultiChildElement
    {
        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            var children = BuildChildren(processor, element.Nodes());

            return new Row(children).BuildWrapperChain(element);
        }
    }
}
