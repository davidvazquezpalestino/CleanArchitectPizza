using Membership.Entities.Dtos;

namespace Membership.Entities.Interfaces.Register;
public interface IRegisterInputport
{
    Task RegisterAsync(Shared.Entities.UserForRegistrationDto userData);
}
