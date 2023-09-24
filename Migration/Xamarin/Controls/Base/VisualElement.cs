using System.Xml.Linq;

namespace Migration.Xamarin.Controls.Base
{
    internal abstract class VisualElement : Element
    {
       internal static Flutter.Types.Color? GetBackgroundColor(IEnumerable<XAttribute> attr)
        {
            Flutter.Types.Color? backgroundColor = null;

            var value = attr.FirstOrDefault(x => x.Name.LocalName == "BackgroundColor")?.Value;

            if (value != null)
            {
                backgroundColor = new Flutter.Types.Color(value);
            }

            return backgroundColor;
        }

        internal static double? GetHeightRequest(IEnumerable<XAttribute> attr)
        {
            var value = attr.FirstOrDefault(x => x.Name.LocalName == "HeightRequest")?.Value;

            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return double.Parse(value);            
        }

        internal static double? GetWidthRequest(IEnumerable<XAttribute> attr)
        {
            var value = attr.FirstOrDefault(x => x.Name.LocalName == "WidthRequest")?.Value;

            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return double.Parse(value);
        }
    }
}
