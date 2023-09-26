using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal class Container : ChildWidget
    {
        readonly Types.Color? _backgroundColor;
        readonly double? _height;
        readonly double? _width;
        public Container(Widget? child, Types.Color? backgroundColor, double? height, double? width) : base(child)
        {
            _backgroundColor = backgroundColor;
            _height = height;
            _width = width;
        }

        internal override string Build()
        {
            var child = string.Empty;

            if (Child != null)
            {
                child = $"child: {Child.Build()}";
            }

            return $"Container({Properties()}{child}),";
        }

        string Properties()
        {
            var properties = string.Empty;

            if (_backgroundColor != null)
            {
                properties += $"color:{_backgroundColor},";
            }

            if (_height != null)
            {
                properties += $"height:{_height},";
            }

            if (_width != null)
            {
                properties += $"width:{_width},";
            }

            return properties;
        }
    }
}
