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
            var command = attributes.GetAttribute("Command") ?? "";
            var commandParameter = attributes.GetAttribute("CommandParameter") ?? "";

            return new TextButton(text, command, commandParameter).BuildWrapperChain(element);
        }
    }
}
