namespace Membership.Blazor.UI.Components;
public partial class LoginComponent
{
    [Inject]
    IUserWebApiGateway Gateway { get; set; }

    [Inject]
    IAuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Parameter]
    public EventCallback<UserTokensDto> OnLogin { get; set; }

    UserCredentials User = new();
    async Task Login()
    {
        UserCredentialsDto credentials = new(
            User.UserName, User.Password);
        UserTokensDto tokens = await Gateway.LoginAsync(credentials);

        await AuthenticationStateProvider.LoginAsync(tokens);

        await OnLogin.InvokeAsync(tokens);

    }
}
