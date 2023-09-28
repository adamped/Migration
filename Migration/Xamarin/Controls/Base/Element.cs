using Migration.Flutter.Widgets.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls.Base
{
    internal abstract class Element
    {
        internal abstract Widget Build(WidgetProcessor processor, XElement element);

        internal static string? GetStyle(IEnumerable<XAttribute> attr)
        {
            var value = attr.FirstOrDefault(x => x.Name.LocalName == "Style")?.Value;

            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return value.GetBinding().PropertyNameToDart();
        }

    }
}
