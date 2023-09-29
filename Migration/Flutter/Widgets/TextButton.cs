using Migration.Flutter.Widgets.Base;

namespace Migration.Flutter.Widgets
{
    internal sealed class TextButton : Widget
    {
        readonly string _text;
        readonly string _function;
        readonly string _parameter;
        internal TextButton(string text, string function, string parameter)
        {
            _text = text;
            _function = function;
            _parameter = parameter;
        }

        internal override string Build()
        {
            var onPressed = "null";

            if (!string.IsNullOrEmpty(_function))
            {
                var name = _function.GetBinding().PropertyNameToDart();

                Services.AddFunction(name, !string.IsNullOrEmpty(_parameter));

                var arg = "";

                if (!string.IsNullOrEmpty(_parameter))
                {
                    arg = $"'{_parameter}'";
                }

                onPressed = $"() => {State.Prefix}{name}({arg})";
            }

            return $"""
                TextButton(
                    style: TextButton.styleFrom(
                        textStyle: const TextStyle(fontSize: 20),
                    ),
                    onPressed: {onPressed},
                    child: const Text('{_text}'),
                )
                """;
        }
    }
}
