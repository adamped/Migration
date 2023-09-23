using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter
{
    internal sealed class Outputter
    {
        public static void Output(string path, string name, Widget widgetTree)
        {
            var output = widgetTree.Build();

            File.WriteAllText(Path.Combine(path, $"{name.ToSnakeCase()}.dart"), BuildOutput(name, output, ""));

            Console.WriteLine($"Converted: {name}");
        }

        static string BuildOutput(string name, string widgetBuild, string functions)
        {
            return string.Format(template, name, widgetBuild, functions);
        }

        const string template = """
            import 'package:flutter/material.dart';
            import 'package:flutter_layout_grid/flutter_layout_grid.dart';

            class {0} extends StatefulWidget {{
              {0}({{Key? key}}) : super(key: key);

              @override
              {0}State createState() => {0}State();
            }}

            class {0}State extends State<{0}> {{              

              @override
              Widget build(BuildContext context) {{
                return Scaffold(
                    body:{1}
                );

                {2}
            }}

            """;
    }
}
