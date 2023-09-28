using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Migration
{
    internal static class Extensions
    {
        internal static string? GetAttribute(this IEnumerable<XAttribute> attributes, string name)
        {
            return attributes.FirstOrDefault(a => a.Name == name)?.Value;
        }

        internal static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string snakeCase = Regex.Replace(input, @"(\p{Lu})", "_$1").TrimStart('_');

            return snakeCase.ToLower();
        }

        internal static bool HasBinding(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            return input.Contains("{Binding");
        }

        internal static string GetBinding(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // TODO: Binding syntax can be far more complex than this
            // Maybe I could look at the Binding Parse in XF and pull from there?
            input = input.Replace("{Binding", "")
                         .Replace("{StaticResource", "")
                         .Replace("{DynamicResource", "")
                         .Replace("}", "");

            return input.Trim();
        }

        /// <summary>
        /// Will extract all property name bound in the text
        /// </summary>
        internal static Dictionary<string, string> GetProperties(this string text)
        {
            string pattern = @"\{Binding (\w+)\}";

            var matches = Regex.Matches(text, pattern);

            Dictionary<string, string> extractedNames = new Dictionary<string, string>();

            foreach (Match match in matches)
            {
                if (match.Groups.Count > 1)
                {
                    string name = match.Groups[1].Value;
                    extractedNames.Add(name, "String"); // Just making everything a string right now. Without going to the ViewModel could look at what the property expects and assume it will be that.
                }
            }

            return extractedNames;
        }

        internal static string PropertyNameToDart(this string name)
        {
            if (!string.IsNullOrEmpty(name) && char.IsUpper(name[0]))
            {
                char[] charArray = name.ToCharArray();
                charArray[0] = char.ToLower(charArray[0]);
                return new string(charArray);
            }

            return name;
        }

        internal static string PathToDart(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var folders = input.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> snakeCaseFolders = new();
            foreach (string folder in folders)
            {
                string snakeCaseFolder = Regex.Replace(folder, @"(\p{Lu})", "_$1").TrimStart('_').ToLower();
                snakeCaseFolders.Add(snakeCaseFolder);
            }

            return string.Join("\\", snakeCaseFolders);
        }

        const string refMarker = "<Ref>"; // Used to mark that the text is actually a reference to local variable

        internal static void ReplaceBindingNameWithItemName(this XElement element, string instance)
        {
            foreach (var node in element.DescendantsAndSelf())
            {
                foreach (var attribute in node.Attributes())
                {
                    if (attribute.Value.HasBinding())
                    {
                        var property = attribute.Value.GetBinding();

                        attribute.Value = $"{refMarker}{instance}.{property.PropertyNameToDart()}";
                    }
                }
            }
        }

        internal static string FormatStringValue(this string value)
        {
            if (value.StartsWith(refMarker))
                return value.Substring(refMarker.Length);

            return $"'{value}'";
        }
    }
}
