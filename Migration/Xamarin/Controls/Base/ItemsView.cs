using Migration.Flutter.Widgets.Base;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls.Base
{
    internal abstract class ItemsView : View
    {
        internal static string? GetDataSource(IEnumerable<XAttribute> attr)
        {
            var value = attr.FirstOrDefault(x => x.Name.LocalName == "ItemsSource")?.Value;

            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return value.GetBinding();
        }

        internal static WidgetModel GetDataTemplate(WidgetProcessor processor, XElement element)
        {
            var nodes = element.Elements().ToList();            

            var itemTemplateNode = nodes.FirstOrDefault(x=>x.Name.LocalName == "ListView.ItemTemplate" || x.Name.LocalName == "CollectionView.ItemTemplate");
           
            if (itemTemplateNode == null)
            {
                return new WidgetModel(null, new Flutter.Widgets.Unknown("No ItemTemplate defined"));
            }

            // Should always be available otherwise it's invalid XAML
            var dataTemplateNode = (XElement)itemTemplateNode.FirstNode!;

            var content = (XElement)dataTemplateNode.FirstNode!;

            var modelClass = content.ToString().GetProperties();

            // Loop through content and replace {Binding Name} with item.name
            content.ReplaceBindingNameWithItemName("item");

            var widget = processor(content);

            return new WidgetModel(new Model(modelClass), widget);
        }
    }
}
