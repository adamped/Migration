namespace Migration
{
    internal static class State
    {
        /// <summary>
        /// If the state is managed in another object
        /// </summary>
        internal static string Prefix { get; private set; } = "";
        internal static FrameworkType Framework { get; private set; }

        internal static void SetFramework(FrameworkType framework)
        {
            Framework = framework;

            Prefix = framework switch
            {
                FrameworkType.Stacked => "viewModel.",
                _ => "",
            };
        }
    }
}
