using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal class Text : Widget
    {
        readonly string _text;
        readonly string? _style;
        public Text(string text, string? style)
        {
            _text = text;
            _style = style;
        }

        internal override string Build()
        {
            var properties = "";
            if (!string.IsNullOrEmpty(_style)) { 
                properties += $"style: {_style}, ";
            }

            return $"Text({_text},{properties}),";
        }
    }
}
