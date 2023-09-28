using Migration;
using Migration.Discovery;
using Migration.Flutter;

#if FORMS
const string rootFolder = "..\\..\\..\\..\\Xamarin.Sample\\";
var discovery = new Xaml(rootFolder, DiscoveryType.XamarinForms);
#elif MAUI
const string rootFolder = "..\\..\\..\\..\\Maui.Sample\\";
var discovery = new Xaml(rootFolder, DiscoveryType.Maui);
#endif

// Create an empty Flutter app at this location. This way you can view the output
var outputDirectory = "..\\..\\..\\..\\..\\flutter_ui\\lib";

var xamlPages = discovery.Find();

foreach (var xamlPage in xamlPages)
{
    var widget = Builder.Build(xamlPage.Xaml);
    Outputter.Output(Path.Combine(outputDirectory, xamlPage.Folder.PathToDart()), CleanFileName(xamlPage.FileName), widget, Services.Models, Services.StateProperties, Services.Functions, Services.LocalStyles);
    Services.Clear();
}

// Will format the outputted files
Terminal.Run(outputDirectory, "dart format .");

string CleanFileName(string filename) => filename.Replace(".xaml", "");