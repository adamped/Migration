using Migration.Flutter.Widgets.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls.Base
{
    internal abstract class MultiChildElement : Layout // aka Layout<T>
    {
        internal List<Widget> BuildChildren(WidgetProcessor processor, IEnumerable<XNode> nodes)
        {
            var children = new List<Widget>();

            foreach (XElement node in nodes)
            {
                children.Add(processor(node));
            }

            return children;
        }
    }
}
