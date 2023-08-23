﻿namespace Membership.UserManager.AspNetIdentity;
internal class UserManagerService : IUserManagerService
{
    readonly UserManager<User> UserManager;

    public UserManagerService(UserManager<User> userManager)
    {
        UserManager = userManager;
    }

    public async Task<List<string>> RegisterAsync(UserForRegistrationDto userData)
    {
        var User = new User
        {
            UserName = userData.UserName,
            Email = userData.UserName,
            FirstName = userData.FirstName,
            LastName = userData.LastName,
        };

        var Result = await UserManager.CreateAsync(User, userData.Password);
        List<string> Errors = null;
        if (!Result.Succeeded)
        {
            Errors = Result.Errors
                .Select(e => e.Description)
                .ToList();
        }
        return Errors;
    }

    public async Task<UserDto> GetUserByCredentialsAsync(
        UserCredentialsDto userCredentials)
    {
        UserDto FoundUser = default;

        var User = await UserManager.FindByNameAsync(
            userCredentials.Email);
        
        if (User != null &&
            await UserManager.CheckPasswordAsync(User,
            userCredentials.Password))
        {
            FoundUser = new UserDto(User.UserName,
                User.FirstName, User.LastName);
        }

        return FoundUser;
    }
}
