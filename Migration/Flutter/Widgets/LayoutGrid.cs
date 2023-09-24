using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal sealed class LayoutGrid : MultiChildWidget
    {
        readonly List<string> rowDefinitions;
        readonly List<string> columnDefinitions;

        public LayoutGrid(List<Widget> children, List<string> rowDefinitions, List<string> columnDefinitions) : base(children)
        {
            if (rowDefinitions.Count == 0)
            {
                rowDefinitions.Add("*");
            }

            if (columnDefinitions.Count == 0)
            {
                columnDefinitions.Add("*");
            }

            this.rowDefinitions = rowDefinitions;
            this.columnDefinitions = columnDefinitions;
        }

        internal override string Build()
        {
            var rowSizes = string.Join(",", rowDefinitions.ConvertAll<string>(ConvertGridSize));
            var columnSizes = string.Join(",", columnDefinitions.ConvertAll<string>(ConvertGridSize));

            var childWidgets = "";

            foreach (var child in Children)
            {  
                childWidgets += $"{child.Build()}\n";
            }

            return $"LayoutGrid(rowSizes:[\n{rowSizes}\n],\ncolumnSizes: [\n{columnSizes}\n],\nchildren: [\n{childWidgets}\n])";
        }

        static string ConvertGridSize(string gridSize)
        {
            if (gridSize == "auto")
                return "auto";

            if (gridSize.Contains("*"))
            {
                if (gridSize.Length == 1)
                {
                    return "1.fr";
                }
                else
                {
                    return $"{gridSize.TrimEnd('*')}.fr";
                }
            }

            return $"{gridSize}.px";
        }

    }
}
