namespace Membership.Entities.Interfaces;
public interface IUserManagerService
{
    Task<List<string>> RegisterAsync(UserForRegistrationDto userData);
    async Task ThrowIfUnableToRegisterAsync(UserForRegistrationDto userData)
    {
        var Errors = await RegisterAsync(userData);
        if (Errors != null && Errors.Any())
        {
            throw new RegisterUserException(Errors);
        }
    }

    Task<UserDto> GetUserByCredentialsAsync(UserCredentialsDto userCredentials);
    async Task<UserDto> ThrowIfUnableToGetUserByCredentialsAsync(
        UserCredentialsDto userCredentials)
    {
        var User = await GetUserByCredentialsAsync(userCredentials);
        if (User == default)
            throw new LoginUserException();
        return User;
    }
}
