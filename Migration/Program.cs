using Migration.Discovery;
using Migration.Flutter;


#if FORMS
const string rootFolder = "..\\..\\..\\..\\Xamarin.Sample\\";
var discovery = new Xaml(rootFolder, DiscoveryType.XamarinForms);
#elif MAUI
const string rootFolder = "..\\..\\..\\..\\Maui.Sample\\";
var discovery = new Xaml(rootFolder, DiscoveryType.Maui);
#endif

var outputDirectory = "";

var xamlPages = discovery.Find();

foreach (var xamlPage in xamlPages)
{
    var widget = Builder.Build(xamlPage.Xaml);
    Outputter.Output(outputDirectory, CleanFileName(xamlPage.FileName), widget);
}

string CleanFileName(string filename) => filename.Replace(".xaml", "");