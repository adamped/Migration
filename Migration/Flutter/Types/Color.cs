namespace Migration.Flutter.Types
{
    internal sealed class Color
    {
        readonly string _hex;
        public Color(string hex)
        {
            // TODO: What if named or styled
            _hex = hex;
        }

        public override string ToString()
        {
            return $"Color(0xFF{ _hex.TrimStart('#')})";
        }
    }
}
