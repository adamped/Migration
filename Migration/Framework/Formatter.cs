namespace Migration.Framework
{
    internal abstract class Formatter
    {
        internal abstract string BuildOutput(string name, string widgetBuild, string functions, string models, string stateProperties, string localStyles);

        protected internal virtual string BuildImports(string widgetText)
        {
            var list = new List<string>();

            if (widgetText.Contains("LayoutGrid"))
            {
                list.Add("import 'package:flutter_layout_grid/flutter_layout_grid.dart';");
            }

            return string.Join("\n", list);
        }
    }
}
