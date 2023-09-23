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
    }
}
