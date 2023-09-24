using Migration.Flutter.Widgets;
using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls
{
    internal sealed class BoxView : View
    {
        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            var attr = element.Attributes();

            return new Container(null, GetColor(attr), GetHeightRequest(attr), GetWidthRequest(attr));
        }

        internal static Flutter.Types.Color? GetColor(IEnumerable<XAttribute> attr)
        {
            Flutter.Types.Color? color = null;

            var value = attr.FirstOrDefault(x => x.Name.LocalName == "Color")?.Value;

            if (value != null)
            {
                color = new Flutter.Types.Color(value);
            }

            return color;
        }
    }
}
