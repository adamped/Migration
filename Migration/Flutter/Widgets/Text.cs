using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal class Text : Widget
    {
        readonly string _text;
        public Text(string text)
        {
            _text = text;
        }

        internal override string Build()
        {
            return $"Text('{_text}'),";
        }
    }
}
