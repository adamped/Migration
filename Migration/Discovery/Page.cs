using System.Xml.Linq;

namespace Migration.Discovery
{
    internal sealed record Page(string Folder, string FileName, XDocument Xaml);
}
