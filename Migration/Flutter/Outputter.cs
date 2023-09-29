using Migration.Flutter.Widgets.Base;
using Migration.Framework;

namespace Migration.Flutter
{
    internal sealed class Outputter
    {
        public static void Output(string path, FrameworkType framework, string name, Widget widgetTree, List<string> models, List<string> stateProperties, List<string> functions, List<string> localStyles)
        {
            var output = widgetTree.Build();

            string? directoryPath = Path.GetDirectoryName(path + "\\");

            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            Formatter formatter = framework switch
            {
                FrameworkType.Stacked => new Stacked(),
                _ => new Default(),
            };

            File.WriteAllText(Path.Combine(path, $"{name.ToSnakeCase()}.dart"),
                              formatter.BuildOutput(name,
                                                    output,
                                                    string.Join('\n', functions.ToArray()),
                                                    string.Join('\n', models.ToArray()),
                                                    string.Join('\n', stateProperties.ToArray()),
                                                    string.Join('\n', localStyles.ToArray())
                                          )
                              );

            Console.WriteLine($"Converted: {name}");
        }
    }
}
