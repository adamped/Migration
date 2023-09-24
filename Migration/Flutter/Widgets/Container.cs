using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal class Container : ChildWidget
    {
        readonly Types.Color? _backgroundColor;
        public Container(Widget child, Types.Color? backgroundColor) : base(child)
        {
            _backgroundColor = backgroundColor;
        }

        internal override string Build()
        {
            return $"Container({Properties()}child: {Child.Build()}),";
        }

        string Properties()
        {
            var properties = string.Empty;

            if (_backgroundColor != null)
            {
                properties += $"color:{_backgroundColor},";
            }

            return properties;
        }
    }
}
