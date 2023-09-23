using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal class GridPlacement : ChildWidget
    {
        readonly string _rowStart;
        readonly string _columnStart;

        public GridPlacement(Widget child, string rowStart, string columnStart) : base(child)
        {
            _rowStart = rowStart;
            _columnStart = columnStart;
        }

        internal override string Build()
        {
            return $"GridPlacement(columnStart: {_columnStart},\nrowStart: {_rowStart},\nchild:{Child.Build()},\n),";
        }
    }
}
