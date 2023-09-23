using Migration.Flutter.Widgets;
using Migration.Flutter.Widgets.Base;
using System.Xml.Linq;

namespace Migration.Xamarin
{
    internal static class AttachedProperties
    {
        /// <summary>
        /// Build Widget's for wrapping from attached properties
        /// </summary>
        internal static Widget BuildWrapperChain(this Widget child, XElement element)
        {
            var attributes = element.Attributes();

            if (attributes.Count() == 0)
            {
                return child;
            }

            var padding = attributes.Check("Padding");

            if (padding.HasValue())
            {
                child = Padding(child, padding);
            }

            return child;
        }        


        internal static Widget Padding(Widget child, string padding)
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

        internal static string Check(this IEnumerable<XAttribute> attributes, string name)
        {
            return attributes.FirstOrDefault(x => x.Name.LocalName == name)?.Value ?? "";
        }

        internal static bool HasValue(this string value)
            => value != "";
    }
}
