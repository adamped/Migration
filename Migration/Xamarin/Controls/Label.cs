using Migration.Flutter.Widgets;
using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls
{
    internal sealed class Label : View
    {
        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            var attributes = element.Attributes();

            var text = attributes.GetAttribute("Text") ?? "";

            var gestureRecognizers = GetGestureRecognizers(element);

            var child = new Text(text.FormatStringValue()).BuildWrapperChain(element);

            if (gestureRecognizers.Count == 0)
            {
                return child;
            }

            var wrappedChild = child;

            // Create GestureDetectors
            foreach (var gestureRecognizer in gestureRecognizers)
            {
                wrappedChild = new GestureDetector(wrappedChild, gestureRecognizer.Command.GetBinding().PropertyNameToDart(), gestureRecognizer.Parameter);
            }

            return wrappedChild;
        }
    }
}
