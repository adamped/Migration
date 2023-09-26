using System.Xml.Linq;

namespace Migration.Discovery
{
    internal sealed class Xaml
    {
        public string RootFolder { get; init; }
        public DiscoveryType DiscoveryType { get; init; }

        public Xaml(string rootFolder, DiscoveryType discoveryType)
        {
            RootFolder = rootFolder;
            DiscoveryType = discoveryType;
        }

        public List<Page> Find()
        {
            var files = Directory.GetFiles(RootFolder, "*.xaml", SearchOption.AllDirectories);

            var pages = new List<Page>();

            foreach (var file in files)
            {
                var document = XDocument.Load(file);

                if (document?.Root?.Name.LocalName == "ContentPage")
                {
                    pages.Add(new Page(GetSubFolder(RootFolder, file), Path.GetFileName(file), document));
                }
            }

            return pages;

        }

        static string GetSubFolder(string rootDirectory, string filePath)
        {
            var fileName = Path.GetFileName(filePath);

            return filePath.Replace(rootDirectory, "").Replace(fileName, "");
        }
    }
}
