namespace SweetAlert.Blazor;
public class AlertArgs
{
    public string Title { get; }
    public string Text { get; }
    public string Icon { get; }

    public AlertArgs(string title, string text, string icon)
    {
        Title = title;
        Text = text;
        Icon = icon;
    }
}
