using Migration.Flutter.Widgets;
using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls
{
    internal sealed class Label : Element
    {
        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            var attributes = element.Attributes();

            var text = attributes.GetAttribute("Text") ?? "";

            return new Text(text).BuildWrapperChain(element);
        }
    }
}
