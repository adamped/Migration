using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal class ListView : Widget
    {
        readonly WidgetModel _dataTemplate;
        readonly string _dataSourceName;
        public ListView(string dataSourceName, WidgetModel dataTemplate)
        {
            _dataSourceName = dataSourceName;
            _dataTemplate = dataTemplate;
        }

        internal override string Build()
        {
            var listview = """
                Expanded(
                    child: ListView.builder(
                            scrollDirection: Axis.vertical,
                            shrinkWrap: true,                           
                            itemCount: {0}.length,
                            itemBuilder: (context, index) {{
                                var item = {0}[index];
                                return {1};
                            }},
                    ),
                 ),
                """;

            var template = _dataTemplate.Widget.Build().TrimEnd(',');

            Services.AddModelClass(_dataSourceName, _dataTemplate.Model.Properties);
            Services.AddStateProperty(_dataSourceName.PropertyNameToDart(), $"List<{_dataSourceName}>", $"<{_dataSourceName}>[]");

            return string.Format(listview, _dataSourceName.PropertyNameToDart(), template);
        }
    }
}
