using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls
{
    internal sealed class Unknown : Element
    {
        string _name;

        public Unknown(string name)
        {
            _name = name;
        }

        internal override Widget Build(WidgetProcessor processor, XElement element)
        {
            return new Flutter.Widgets.Unknown(_name).BuildWrapperChain(element);
        }
    }
}
