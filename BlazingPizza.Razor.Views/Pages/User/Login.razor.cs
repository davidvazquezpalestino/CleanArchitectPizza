namespace BlazingPizza.Razor.Views.Pages.User;
public partial class Login
{
    [Inject]
    NavigationManager NavigationManager { get; set; }
    void OnLogin(UserTokensDto tokens)
    {
        Console.WriteLine($"Sesión iniciada.");
        NavigationManager.NavigateTo("");
    }
}
