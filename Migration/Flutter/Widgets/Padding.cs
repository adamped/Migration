using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal class Padding : ChildWidget
    {
        readonly double _left;
        readonly double _right;
        readonly double _top;
        readonly double _bottom;
        public Padding(Widget child, double left, double top, double right, double bottom) : base(child)
        {
            _left = left;
            _right = right;
            _top = top;
            _bottom = bottom;
        }

        internal override string Build()
        {
            var padding = string.Empty;

            if (_left == _right && _right == _top && _top == _bottom)
            {
                padding = $"const EdgeInsets.all({_left})";
            }
            else
            {
                padding = $"const EdgeInsets.fromLTRB({_left}, {_top}, {_right}, {_bottom})";
            }

            return $"Padding(padding: {padding}, child: {Child.Build()},\n),";
        }
    }
}
