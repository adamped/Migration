using Migration.Flutter.Widgets.Base;
using Migration.Xamarin;
using System.Xml.Linq;

namespace Migration.Flutter
{
    internal sealed class Builder
    {
        static readonly Main main = new();

        public static Widget Build(XDocument xaml)
        {
            var node = xaml.Elements().First().FirstNode as XElement;

            if (node != null)
            {
                return main.Process(node);
            }

            throw new Exception($"Unable to get node on page '{xaml?.Root?.Name}'");

        }
    }
}
