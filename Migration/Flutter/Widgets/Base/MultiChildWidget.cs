namespace Migration.Flutter.Widgets.Base
{
    internal abstract class MultiChildWidget : Widget
    {
        public List<Widget> Children { get; init; }

        public MultiChildWidget(List<Widget> childWidgets)
        {
            Children = childWidgets;
        }
    }
}
