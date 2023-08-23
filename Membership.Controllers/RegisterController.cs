using Membership.Entities.Interfaces.Register;

namespace Membership.Controllers;
internal class RegisterController : IRegisterController
{
    readonly IRegisterInputport Inputport;

    public RegisterController(IRegisterInputport inputport)
    {
        Inputport = inputport;
    }

    public Task RegisterAsync(UserForRegistrationDto userData) =>
        Inputport.RegisterAsync(userData);
}
