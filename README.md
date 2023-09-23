# Migration

## Summary 
Migrates XAML from Xamarin.Forms or MAUI to Flutter.

Migrating from Xamarin.Forms or MAUI to Flutter doesn't have a one size fits all migration path. Manual intervention will always be required for every migration.

This project enables you to recreate XAML UI in Flutter. Not all Elements or Widgets have been created and properties need to be wired up. However this is a good starting point that can provide a one shot initial push to Flutter, with manual clean up required after.

You are welcome to add or contribute to the project, or expand on your own locally to help your project migration.

The basic premise for these scenarios have been accounted for:
- Elements with multiple children
- Elements with a single child
- Attached Properties
- Wrapped Widgets (e.g. Padding in Flutter wraps the child widget, however in XAML it is just a property on the Element)

## Running

1) Open the Migration solution
2) Set the rootFolder to the location of your XAML pages
3) Set the outputDirectory
4) Run the app

All .dart pages will be output to the outputDirectory. From there you can put them in a Flutter project and manually clean up.

### Special Notes
1) Run `flutter pub add flutter_layout_grid` on your Flutter project. I use this plugin to best mimic the Xamarin Grid control.
