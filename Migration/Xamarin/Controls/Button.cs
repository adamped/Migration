using Migration.Flutter.Widgets;
using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls
{
    internal class Button : View
    {
        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            var attributes = element.Attributes();

            var text = attributes.GetAttribute("Text") ?? "";

            return new TextButton(text).BuildWrapperChain(element);
        }
    }
}
