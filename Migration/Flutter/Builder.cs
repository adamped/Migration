using Migration.Flutter.Widgets.Base;
using Migration.Xamarin;
using Migration.Xamarin.Entity;
using System.Xml.Linq;

namespace Migration.Flutter
{
    internal sealed class Builder
    {
        static readonly Main main = new();

        public static Widget Build(XDocument xaml)
        {
            var elements = xaml.Elements();

            var content = elements.First(x => x.Name.LocalName.StartsWith("ContentPage"));

            var contentChildren = content.Elements();

            var visualContent = contentChildren.First(x => x.Name.LocalName != "ContentPage.Resources");

            var resources = contentChildren.FirstOrDefault(x => x.Name.LocalName == "ContentPage.Resources");

            var resourceDictionary = resources?.Elements().FirstOrDefault(x => x.Name.LocalName == "ResourceDictionary");

            if (resourceDictionary != null)
            {
                BuildLocalStyles(resourceDictionary);
            }

            if (content != null)
            {
                return main.Process(visualContent);
            }

            throw new Exception($"Unable to get node on page '{xaml?.Root?.Name}'");

        }

        static void BuildLocalStyles(XElement styles)
        {
            foreach (var style in styles.Elements())
            {
                var setters = style.Elements().Where(x => x.Name.LocalName == "Setter").ToList();

                var list = new Dictionary<string, string>();

                foreach (var item in setters)
                {
                    var property = item.Attributes().First(x => x.Name == "Property").Value;
                    var value = item.Attributes().First(x => x.Name == "Value").Value;

                    list.Add(property, value);
                }

                var key = style.Attributes().FirstOrDefault(x => x.Name.LocalName == "Key")?.Value ?? "";
                var targetType = style.Attributes().First(x => x.Name.LocalName == "TargetType").Value;

                Services.AddLocalStyle(new Style(key, targetType, list));
            }
        }
    }
}
