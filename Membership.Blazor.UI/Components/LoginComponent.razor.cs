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
        UserCredentialsDto Credentials = new(
            User.UserName, User.Password);
        var Tokens = await Gateway.LoginAsync(Credentials);

        await AuthenticationStateProvider.LoginAsync(Tokens);

        await OnLogin.InvokeAsync(Tokens);

    }
}
