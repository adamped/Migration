using Migration.Flutter.Widgets;
using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls
{
    internal sealed class StackLayout : MultiChildElement
    {
        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            var orientation = element.Attributes().FirstOrDefault(x => x.Name.LocalName == "Orientation")?.Value;

            var children = BuildChildren(processor, element.Nodes());

            if (orientation == "Horizontal")
            {
                return new Row(children).BuildWrapperChain(element);
            }
            else
            {
                // If not present the default is Vertical
                return new Column(children).BuildWrapperChain(element);
            }
        }        
    }
}
