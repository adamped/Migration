using Migration.Flutter.Widgets;
using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls
{
    internal sealed class Grid : MultiChildElement
    {
        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            var rowDefinitions = element.Attributes().FirstOrDefault(x => x.Name.LocalName == "RowDefinitions")?.Value;
            var columnDefinitions = element.Attributes().FirstOrDefault(x => x.Name.LocalName == "ColumnDefinitions")?.Value;

            var children = BuildChildren(processor, element.Nodes());

            return new LayoutGrid(children, ProcessDefinitions(rowDefinitions), ProcessDefinitions(columnDefinitions)).BuildWrapperChain(element);
        }

        static List<string> ProcessDefinitions(string? definitions)
        {
            if (definitions == null)
            {
                return new();
            }

            return definitions.Split(new char[] { ',' }).ToList();
        }
    }
}
