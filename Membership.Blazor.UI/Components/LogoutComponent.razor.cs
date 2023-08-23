namespace Membership.Blazor.UI.Components;

public partial class LogoutComponent
{
    [Inject]
    IAuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    NavigationManager NavigationManager { get; set; }
    async void Logout()
    {
        await AuthenticationStateProvider.LogoutAsync();
        NavigationManager.NavigateTo("");
    }
}