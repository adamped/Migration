using Migration.Flutter.Widgets.Base;
using System.Xml.Linq;

namespace Migration.Flutter.Widgets
{
    internal sealed class GestureDetector : ChildWidget
    {
        readonly string _function;
        readonly string _parameter;
        public GestureDetector(Widget child, string function, string parameter) : base(child)
        {
            _function = function;
            _parameter = parameter; 
        }

        internal override string Build()
        {
            Services.AddFunction(_function, !string.IsNullOrEmpty(_parameter));

            var arg = "";

            if (!string.IsNullOrEmpty(_parameter))
            {
                arg = $"'{_parameter}'";
            }

            var onTap = $"() => {_function}({arg})";

            return $"GestureDetector(onTap: {onTap}, child: {Child.Build()}),";
        }
    }
}
