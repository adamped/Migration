using Migration.Flutter.Widgets.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls.Base
{
    internal abstract class Element
    {
        internal abstract Widget Build(WidgetProcessor processor, XElement element);

    }
}
