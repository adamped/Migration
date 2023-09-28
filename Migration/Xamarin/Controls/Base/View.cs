using Migration.Flutter.Widgets.Base;
using Migration.Xamarin.Entity;
using System.Xml.Linq;

namespace Migration.Xamarin.Controls.Base
{
    internal abstract class View : VisualElement
    {
        internal static List<Recognizer> GetGestureRecognizers(XElement element)
        {
            var recognizers = new List<Recognizer>();

            var nodes = element.Elements().ToList();

            var gestureRecognizers = nodes.FirstOrDefault(x => x.Name.LocalName.Contains("GestureRecognizers"));

            if (gestureRecognizers == null)
            {
                return recognizers;
            }

            var tapGestureRecognizers = gestureRecognizers.Elements().Where(x => x.Name.LocalName == "TapGestureRecognizer").ToList();

            foreach (var recognizer in tapGestureRecognizers)
            {
                var command = recognizer.Attributes().FirstOrDefault(x => x.Name.LocalName == "Command")?.Value ?? "";

                var parameter = recognizer.Attributes().FirstOrDefault(x => x.Name.LocalName == "CommandParameter")?.Value ?? "";

                recognizers.Add(new Recognizer(RecognizerType.Tap, command, parameter));
            }

            return recognizers;
        }

    }
}
