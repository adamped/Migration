using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Controls.Base;
using System.Reflection;
using System.Xml.Linq;

namespace Migration.Xamarin
{
    internal delegate Widget WidgetProcessor(XElement element);

    internal class Main
    {
        readonly Dictionary<string, Element> elements = new();

        internal Main()
        {
            RegisterXamarin();
        }

        public Widget Process(XElement element)
        {
            if (elements.ContainsKey(element.Name.LocalName))
            {
                return elements[element.Name.LocalName].Build(Process, element);
            }
            else
            {
                // If it hits here, the Element hasn't been accounted for. Add in the Xamarin/MAUI control and associated widget.
                return new Controls.Unknown(element.Name.LocalName).Build(Process, element);
            }            
        }

        void RegisterXamarin()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var classesInNamespace = assembly.GetTypes()
                .Where(type => type.IsClass 
                            && !type.IsNested 
                            && !type.IsAbstract 
                            && (type.Namespace == "Migration.Xamarin.Controls" || type.Namespace == "Migration.Maui.Controls")
                            && type.Name != "Unknown");

            foreach (var type in classesInNamespace)
            {
                var element = Activator.CreateInstance(type) as Element;

                if (element == null)
                {
                    throw new NullReferenceException("Element can not be null");
                }

                elements.Add(type.Name, element);
            }
        }

    }
}
