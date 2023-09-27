namespace Migration.Xamarin.Controls.Entity
{
    internal record Recognizer(RecognizerType Type, string Command, string Parameter);

    internal enum RecognizerType
    {
        Tap,
    }
}
