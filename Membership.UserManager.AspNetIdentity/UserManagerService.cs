namespace Membership.UserManager.AspNetIdentity;
internal class UserManagerService : IUserManagerService
{
    readonly UserManager<User> UserManager;

    public UserManagerService(UserManager<User> userManager)
    {
        UserManager = userManager;
    }

    public async Task<List<string>> RegisterAsync(UserForRegistrationDto userData)
    {
        User user = new User
        {
            UserName = userData.UserName,
            Email = userData.UserName,
            FirstName = userData.FirstName,
            LastName = userData.LastName,
        };

        IdentityResult result = await UserManager.CreateAsync(user, userData.Password);
        List<string> errors = null;
        if (!result.Succeeded)
        {
            errors = result.Errors
                .Select(e => e.Description)
                .ToList();
        }
        return errors;
    }

    public async Task<UserDto> GetUserByCredentialsAsync(
        UserCredentialsDto userCredentials)
    {
        UserDto foundUser = default;

        User user = await UserManager.FindByNameAsync(
            userCredentials.Email);
        
        if (user != null &&
            await UserManager.CheckPasswordAsync(user,
            userCredentials.Password))
        {
            foundUser = new UserDto(user.UserName,
                user.FirstName, user.LastName);
        }

        return foundUser;
    }
}
