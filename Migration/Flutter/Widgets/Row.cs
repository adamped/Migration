using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal sealed class Row : MultiChildWidget
    {
        internal Row(List<Widget> children) : base(children) {
        }

        internal override string Build()
        {
            var childWidgets = "";

            foreach (var child in Children)
            {
                childWidgets += $"{child.Build()}\n";
            }

            return $"Row(children: [{childWidgets}]),";
        }
    }
}
