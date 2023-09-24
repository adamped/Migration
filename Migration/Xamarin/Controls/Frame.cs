using Migration.Flutter.Widgets;
using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls
{
    internal class Frame : ChildElement
    {
        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            var child = BuildChild(processor, element.FirstNode as XElement);

            Flutter.Types.Color? backgroundColor = null;

            var value = element.Attributes().FirstOrDefault(x => x.Name.LocalName == "BackgroundColor")?.Value;

            if (value != null)
            {
                backgroundColor = new Flutter.Types.Color(value);
            }

            return new Container(child, backgroundColor).BuildWrapperChain(element);
        }
    }
}
