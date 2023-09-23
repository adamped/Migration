using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls
{
    internal class Image : Element
    {
        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            var attributes = element.Attributes();

            var source = attributes.GetAttribute("Source") ?? "";

            return new Flutter.Widgets.Image(source);
        }
    }
}
