using Membership.Entities.Dtos;

namespace Membership.Entities.Interfaces.Login;
public interface ILoginPresenter
{
    UserTokensDto UserTokens { get; }
    Task HandleUserDataAsync(UserDto userData);
}
