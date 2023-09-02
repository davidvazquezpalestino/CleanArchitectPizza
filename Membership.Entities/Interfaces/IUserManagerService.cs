namespace Membership.Entities.Interfaces;
public interface IUserManagerService
{
    Task<List<string>> RegisterAsync(UserForRegistrationDto userData);
    async Task ThrowIfUnableToRegisterAsync(UserForRegistrationDto userData)
    {
        var errors = await RegisterAsync(userData);
        if (errors != null && errors.Any())
        {
            throw new RegisterUserException(errors);
        }
    }

    Task<UserDto> GetUserByCredentialsAsync(UserCredentialsDto userCredentials);
    async Task<UserDto> ThrowIfUnableToGetUserByCredentialsAsync(
        UserCredentialsDto userCredentials)
    {
        UserDto user = await GetUserByCredentialsAsync(userCredentials);
        if (user == default)
            throw new LoginUserException();
        return user;
    }
}
