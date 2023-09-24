using Migration.Flutter.Widgets;
using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls
{
    internal sealed class ScrollView : ContentView
    {
        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            var child = BuildChild(processor, element.FirstNode as XElement);

            return new SingleChildScrollView(child).BuildWrapperChain(element);
        }
    }
}
