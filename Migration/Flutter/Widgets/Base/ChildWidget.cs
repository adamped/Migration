namespace Migration.Flutter.Widgets.Base
{
    internal abstract class ChildWidget : Widget
    {
        public Widget Child { get; private set; }

        internal ChildWidget(Widget child)
        {
            Child = child;
        }

        /// <summary>
        /// When you need to wrap the Child Widget in another widget
        /// </summary>
        /// <param name="widget"></param>
        internal void InjectWrapper(ChildWidget widget)
        {
            Child = widget;
        }
    }
}
