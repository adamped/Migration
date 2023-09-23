using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal sealed class Image : Widget
    {
        readonly string _source;
        public Image(string source)
        {
            _source = source;
        }

        internal override string Build()
        {
            return $"Image.asset('{_source}'),";
        }
    }
}
