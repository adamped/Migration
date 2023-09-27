using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter
{
    internal sealed class Outputter
    {
        public static void Output(string path, string name, Widget widgetTree, List<string> models, List<string> stateProperties, List<string> functions)
        {
            var output = widgetTree.Build();

            string? directoryPath = Path.GetDirectoryName(path + "\\");

            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(Path.Combine(path, $"{name.ToSnakeCase()}.dart"), BuildOutput(name, output, string.Join('\n', functions.ToArray()), string.Join('\n', models.ToArray()), string.Join('\n', stateProperties.ToArray())));

            Console.WriteLine($"Converted: {name}");
        }

        static string BuildOutput(string name, string widgetBuild, string functions, string models, string stateProperties)
        {
            return string.Format(template, name, widgetBuild, functions, models, stateProperties, BuildImports(widgetBuild));
        }

        static string BuildImports(string widgetText)
        {
            var list = new List<string>();

            if (widgetText.Contains("LayoutGrid"))
            {
                list.Add("import 'package:flutter_layout_grid/flutter_layout_grid.dart';");
            }

            return string.Join("\n", list);
        }

        const string template = """
            import 'package:flutter/material.dart';
            {5}

            class {0} extends StatefulWidget {{
              const {0}({{Key? key}}) : super(key: key);

              @override
              {0}State createState() => {0}State();
            }}

            {3}

            class {0}State extends State<{0}> {{              
              {4}
              @override
              Widget build(BuildContext context) {{
                return Scaffold(
                    body:{1}
                );
              }}            
            
              {2}
            }}

            """;
    }
}
