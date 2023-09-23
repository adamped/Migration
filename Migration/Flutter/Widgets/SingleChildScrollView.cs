using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal sealed class SingleChildScrollView : ChildWidget
    {
        public SingleChildScrollView(Widget child) : base(child)
        {
        }

        internal override string Build()
        {
            return $"SingleChildScrollView(child: {Child.Build()},),";
        }
    }
}
