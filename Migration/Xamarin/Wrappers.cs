using Migration.Flutter.Widgets;
using Migration.Flutter.Widgets.Base;
using System.Xml.Linq;

namespace Migration.Xamarin
{
    internal static class Wrappers
    {
        /// <summary>
        /// Build Widget's for wrapping from attached properties, or attributes that require a Widget to wrap the existing one
        /// </summary>
        internal static Widget BuildWrapperChain(this Widget child, XElement element)
        {
            var attributes = element.Attributes();

            if (attributes.Count() == 0)
            {
                return child;
            }

            // Get shiftable properties
            var map = GetVisualElementProperties(attributes);

            var padding = attributes.Check("Padding");

            if (padding.HasValue() && child is ChildWidget wrappedWidget)
            {
                // Inject Padding around Child
                wrappedWidget.InjectWrapper(Padding(wrappedWidget.Child, padding));

            }
            else if (padding.HasValue())
            {
                // Wrap around Widget, but need to pull attributes up
                Flutter.Types.Color? backgroundColor = null;

                var value = map.GetDefaultValue("BackgroundColor");

                if (value != null) {
                    backgroundColor = new Flutter.Types.Color(value);
                }

                child = new Container(Padding(child, padding), backgroundColor, null, null);

            }

            var margin = attributes.Check("Margin");

            if (margin.HasValue())
            {
                // No margin in Flutter. Wrap it in a Padding for same effect.
                child = Padding(child, margin);
            }

            // GridPlacement should be at the end to ensure it's the last one wrapped
            var gridRow = attributes.Check("Grid.Row");
            var gridCol = attributes.Check("Grid.Column");

            if (gridRow.HasValue() || gridCol.HasValue())
            {
                child = Grid(child, gridRow, gridCol);
            }

            return child;
        }

        internal static Widget Grid(Widget child, string row, string col)
        {
            if (row == "")
            {
                row = "0";
            }

            if (col == "")
            {
                col = "0";
            }

            return new GridPlacement(child, row, col);
        }

        internal static ChildWidget Padding(Widget child, string padding)
        {
            double left;
            double top;
            double right;
            double bottom;

            if (padding.Contains(','))
            {
                var values = padding.Split(',');

                if (values.Length == 2)
                {
                    left = right = double.Parse(values[0]);
                    top = bottom = double.Parse(values[1]);
                }
                else
                {
                    left = double.Parse(values[0]);
                    top = double.Parse(values[1]);
                    right = double.Parse(values[2]);
                    bottom = double.Parse(values[3]);
                }
            }
            else
            {
                left = top = right = bottom = double.Parse(padding);
            }


            return new Padding(child, left, top, right, bottom);
        }

        internal static string? GetDefaultValue(this Dictionary<string, string> map, string key)
        {
            if (map.ContainsKey(key))
            {
                return map[key];
            }

            return null;
        }

        internal static Dictionary<string, string> GetVisualElementProperties(this IEnumerable<XAttribute> attributes)
        {
            var map = new Dictionary<string, string>();

            map.Map(attributes, "BackgroundColor");

            return map;
        }

        static void Map(this Dictionary<string, string> map, IEnumerable<XAttribute> attributes, string name)
        {
            var backgroundColor = attributes.Check(name);
            if (backgroundColor.HasValue())
            {
                map.Add(name, backgroundColor);
            }
        }

        internal static string Check(this IEnumerable<XAttribute> attributes, string name)
        {
            return attributes.FirstOrDefault(x => x.Name.LocalName == name)?.Value ?? "";
        }

        internal static bool HasValue(this string value)
            => value != "";
    }
}
