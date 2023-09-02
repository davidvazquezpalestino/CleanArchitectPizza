namespace Membership.Blazor.UI.Components;
public partial class RegisterComponent
{
    [Inject]
    IUserWebApiGateway Gateway { get; set; }

    [Parameter]
    public EventCallback<UserForRegistrationDto> OnRegister { get; set; }

    UserToRegister User = new();
    async Task Register()
    {
        UserForRegistrationDto newUser = new UserForRegistrationDto(
            User.UserName, User.Password, User.FirstName, User.LastName);
        await Gateway.RegisterUserAsync(newUser);
        await OnRegister.InvokeAsync(newUser);
    }
}
