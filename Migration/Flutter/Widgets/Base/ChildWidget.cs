namespace Migration.Flutter.Widgets.Base
{
    internal abstract class ChildWidget : Widget
    {
        public Widget Child { get; init; }

        internal ChildWidget(Widget child)
        {
            Child = child;
        }

    }
}
