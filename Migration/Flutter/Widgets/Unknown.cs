using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal sealed class Unknown : Widget
    {
        string _name;
        public Unknown(string name)
        {
            _name = name;
        }
        internal override string Build()
        {
            return $"Text('Unknown Element \"{_name}\"'),";
        }
    }
}
