using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal sealed class TextButton : Widget
    {
        readonly string _text;
        internal TextButton(string text)
        {
            _text = text;
        }

        internal override string Build()
        {
            return $"""
                TextButton(
                    style: TextButton.styleFrom(
                        textStyle: const TextStyle(fontSize: 20),
                    ),
                    onPressed: null,
                    child: const Text('{_text}'),
                )
                """;
        }
    }
}
