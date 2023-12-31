﻿using Migration.Flutter;
using Migration.Xamarin.Entity;

namespace Migration
{
    internal static class Services
    {
        /// <summary>
        /// Global location for adding models for a page
        /// I don't like having a globally modified state but waiting on a better approach
        /// rather than polluting the widget build tree passing it up and down
        /// </summary>
        internal static List<string> Models { get; } = new();
        internal static List<string> StateProperties { get; } = new();
        internal static List<string> Functions { get; } = new();
        internal static List<string> LocalStyles { get; } = new();

        internal static void Clear()
        {
            Models.Clear();
            StateProperties.Clear();
            Functions.Clear();
            LocalStyles.Clear();
        }

        internal static void AddModelClass(string className, Dictionary<string, string> properties)
        {
            var model = """
                class {0} {{
                    {1}
                    {0}({2});
                }}
                """;

            var finalProperties = string.Empty;
            var parameters = string.Empty;

            foreach(var property in properties)
            {
                finalProperties += $"final {property.Value} {property.Key.PropertyNameToDart()};\n";
                parameters += $"this.{property.Key.PropertyNameToDart()}";
            }

            Models.Add(string.Format(model, className, finalProperties, parameters));
        }

        internal static void AddStateProperty(string propertyName, string type, string constructor)
        {
            var model = """
                final {0} {1} = {2};

                """;

            StateProperties.Add(string.Format(model, type, propertyName, constructor));
        }

        internal static void AddFunction(string functionName, bool hasParameter)
        {
            if (string.IsNullOrEmpty(functionName))
                return;

            var model = """
                void {0}({1}) {{

                }}
                """;

            string parameter = "";

            if (hasParameter)
            {
                parameter = $"String parameter";
            }

            Functions.Add(string.Format(model, functionName, parameter));
        }

        internal static void AddLocalStyle(Style style)
        {
            LocalStyles.Add(style.ToDart());
        }
    }
}
