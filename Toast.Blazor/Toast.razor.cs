namespace Toast.Blazor;
public sealed partial class Toast : ComponentBase, IDisposable
{
    [Inject]
    IToastService ToastService { get; set; }

    string Heading;
    string Message;
    bool IsVisible;
    string ColorsCssClass;
    string IconCssClass;
    bool IsCloseIconVisible;

    protected override void OnInitialized()
    {
        ToastService.OnShow += ShowToast;
        ToastService.OnHide += HideToast;
    }

    void ShowToast(object sender, ShowToastEventArgs e)
    {
        BuildToastSettings(e.Heading, e.Message, e.Level);
        IsVisible = true;
        IsCloseIconVisible = e.ShowCloseIcon;
        StateHasChanged();
    }

    void HideToast(object sender, EventArgs e)
    {
        IsVisible = false;
        StateHasChanged();
    }

    void HideToast() => HideToast(null, null);
    void BuildToastSettings(string heading, string message, ToastLevel level)
    {
        switch (level)
        {
            case ToastLevel.Info:
                ColorsCssClass = "bg-info text-dark";
                IconCssClass = "info";
                break;
            case ToastLevel.Success:
                ColorsCssClass = "bg-success text-white";
                IconCssClass = "check";
                break;
            case ToastLevel.Warning:
                ColorsCssClass = "bg-warning text-dark";
                IconCssClass = "warning";
                break;
            case ToastLevel.Error:
                ColorsCssClass = "bg-danger text-white";
                IconCssClass = "x";
                break;
        }
        Message = message;
        Heading = heading;
    }

    void IDisposable.Dispose()
    {
        ToastService.OnShow -= ShowToast;
        ToastService.OnHide -= HideToast;
    }
}
