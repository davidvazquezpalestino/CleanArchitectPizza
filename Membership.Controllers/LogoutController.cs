namespace Membership.Controllers;
internal class LogoutController : ILogoutController
{
    readonly ILogoutInputPort InputPort;

    public LogoutController(ILogoutInputPort inputPort)
    {
        InputPort = inputPort;
    }

    public async Task LogoutAsync(string refreshToken)
    {
        await InputPort.LogoutAsync(refreshToken);
    }
}
