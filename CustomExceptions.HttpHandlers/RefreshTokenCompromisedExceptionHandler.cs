using Membership.Entities.Exceptions;

namespace CustomExceptions.HttpHandlers;
internal class RefreshTokenCompromisedExceptionHandler :
    IHttpExceptionHandler<RefreshTokenCompromisedException>
{
    public ProblemDetails Handle(RefreshTokenCompromisedException exception) =>
        new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Revoked Refresh Token"
        };
}
