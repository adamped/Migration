namespace Migration.Framework
{
    internal sealed class Default : Formatter
    {
        internal override string BuildOutput(string name, string widgetBuild, string functions, string models, string stateProperties, string localStyles)
        {
            return string.Format(template, name, widgetBuild, functions, models, stateProperties, BuildImports(widgetBuild), localStyles);
        }

        const string template = """
            import 'package:flutter/material.dart';
            {5}

            {6}

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
