using Migration;
using Migration.Discovery;
using Migration.Flutter;

// Instructions
//
// 1) Set the discovery rootFolder to the location of your project. You can remove the 
//    preprocessors (#if FORMS, #elif MAUI), they are just for demo purposes.
//
// 2) Create an empty Flutter project using your preferred setup method
//
// 3) Set the output directory to the lib folder of this new project
//    ## Packages
//       - Using LayoutGrid for Grid support. Add this package to your Flutter project [flutter pub add flutter_layout_grid]
//
// 4) Set your framework (optional)
//    ## Frameworks
//       - Default
//          No need to do anything extra. Standard StatefulWidget output.
//       - Stacked
//          Add stacked package via [flutter pub add stacked]

#if FORMS
const string rootFolder = "..\\..\\..\\..\\Xamarin.Sample\\";
var discovery = new Xaml(rootFolder, DiscoveryType.XamarinForms);
#elif MAUI
const string rootFolder = "..\\..\\..\\..\\Maui.Sample\\";
var discovery = new Xaml(rootFolder, DiscoveryType.Maui);
#endif

// Config
var outputDirectory = "..\\..\\..\\..\\..\\flutter_ui\\lib"; // Create an empty Flutter app at this location. This way you can view the output
State.SetFramework(FrameworkType.Default); // Select a framework to output to (optional)

// Start Conversion
var xamlPages = discovery.Find();

foreach (var xamlPage in xamlPages)
{
    var widget = Builder.Build(xamlPage.Xaml);
    Outputter.Output(Path.Combine(outputDirectory, xamlPage.Folder.PathToDart()),
                     State.Framework,
                     CleanFileName(xamlPage.FileName), 
                     widget, 
                     Services.Models, 
                     Services.StateProperties, 
                     Services.Functions, 
                     Services.LocalStyles);

    Services.Clear();
}

// Will format the outputted files
Terminal.Run(outputDirectory, "dart format .");

string CleanFileName(string filename) => filename.Replace(".xaml", "");