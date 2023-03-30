namespace Toast.Blazor;
public interface IToastService : IDisposable
{
    const byte DefaultDurationInSeconds = 5;
    void ShowError(string heading, string message, 
        byte timeToShowInSeconds = DefaultDurationInSeconds);

    void ShowInfo(string heading, string message, 
        byte timeToShowInSeconds = DefaultDurationInSeconds);

    void ShowWarning(string heading, string message,
        byte timeToShowInSeconds = DefaultDurationInSeconds);

    void ShowSuccess(string heading, string message,
        byte timeToShowInSeconds = DefaultDurationInSeconds);

    internal event OnShowEventHandler OnShow;
    internal event EventHandler OnHide; // ¿Debería ser público para notificar al código que el usuario ha cerrado el toast?
    internal void Hide(); 
}
