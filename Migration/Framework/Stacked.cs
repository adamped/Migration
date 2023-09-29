namespace Migration.Framework
{
    internal sealed class Stacked : Formatter
    {
        internal override string BuildOutput(string name, string widgetBuild, string functions, string models, string stateProperties, string localStyles)
        {
            return string.Format(template, name, widgetBuild, functions, models, stateProperties, BuildImports(widgetBuild), localStyles);
        }

        protected internal override string BuildImports(string widgetText)
        {
            var imports = base.BuildImports(widgetText);

            imports += "import 'package:stacked/stacked.dart';\n";

            return imports;
        }

        const string template = """
            import 'package:flutter/material.dart';
            {5}
            
            {6}

            class {0} extends StackedView<{0}ViewModel> {{
              const {0}({{Key? key}}) : super(key: key);

              @override              
              Widget builder(
                BuildContext context,
                {0}ViewModel viewModel,
                Widget? child,
              ) {{
                return Scaffold(
                  body: {1}
                );
              }}

              @override
              {0}ViewModel viewModelBuilder(BuildContext context) => {0}ViewModel();
            }}

            {3}

            class {0}ViewModel extends BaseViewModel {{
              {4}

              {2}
            }}
            """;
    }
}
