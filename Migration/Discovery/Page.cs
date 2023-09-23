using System.Xml.Linq;

namespace Migration.Discovery
{
    internal sealed record Page(string FileName, XDocument Xaml);
}
