using Migration.Flutter.Widgets.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls.Base
{
    internal abstract class ChildElement : Element
    {
        internal Widget BuildChild(WidgetProcessor processor, XElement? node)
        {
            if (node == null)
            {
                return new Flutter.Widgets.Unknown("NULL");
            }

            return processor(node);
        }
    }
}
