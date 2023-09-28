using Migration.Xamarin.Entity;

namespace Migration.Flutter
{
    internal static class StyleBuild
    {
        internal static string ToDart(this Style style)
        {
            var output = """
                final {0} {1} = {2}({3});
                """;

            var type = ConvertTargetType(style.TargetType);

            return string.Format(output, type,
                                         style.Key.PropertyNameToDart(),
                                         type,
                                         string.Join(',', BuildProperties(style.Setters).ToArray()));
        }


        static string ConvertTargetType(string type)
        {
            return type switch
            {
                "Label" => "TextStyle",
                _ => type,
            };
        }

        static List<string> BuildProperties(Dictionary<string, string> setters)
        {
            var properties = new List<string>();

            foreach (var setter in setters)
            {
                var name = ConvertPropertyName(setter.Key);
                var value = ConvertPropertyValue(setter.Key, setter.Value);

                properties.Add($"{name}: {value}");
            }

            return properties;
        }

        static string ConvertPropertyName(string name)
        {
            return name switch
            {
                "TextColor" => "color",
                _ => name
            };
        }

        static string ConvertPropertyValue(string name, string value)
        {
            return name switch
            {
                "TextColor" => ConvertColor(value),
                _ => value
            };
        }

        static string ConvertColor(string color)
        {
            // TODO: For HEX conversion
            return $"Colors.{color.PropertyNameToDart()}";
        }


    }
}
