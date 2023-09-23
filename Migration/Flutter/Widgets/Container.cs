using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal class Container : ChildWidget
    {
        public Container(Widget child) : base(child)
        {
        }

        internal override string Build()
        {
            return $"Container(child: {Child.Build()}),";
        }
    }
}
