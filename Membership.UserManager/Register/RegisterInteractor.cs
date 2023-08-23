using Membership.Entities.Dtos;
using Membership.Entities.Interfaces;
using Membership.Entities.Interfaces.Register;

namespace Membership.UserManager.Register;
internal class RegisterInteractor : IRegisterInputport
{
    readonly IUserManagerService UserManagerService;

    public RegisterInteractor(IUserManagerService userManagerService)
    {
        UserManagerService = userManagerService;
    }

    public async Task RegisterAsync(Shared.Entities.UserForRegistrationDto userData)
    {
        await UserManagerService.ThrowIfUnableToRegisterAsync(
            new UserForRegistrationDto
            {
                UserName = userData.UserName,              
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Password = userData.Password
            });
    }
}
