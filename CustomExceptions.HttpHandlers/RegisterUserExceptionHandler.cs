using Membership.Entities.Exceptions;

namespace CustomExceptions.HttpHandlers;
internal class RegisterUserExceptionHandler :
    IHttpExceptionHandler<RegisterUserException>
{
    public ProblemDetails Handle(RegisterUserException exception)
    {
        var errors = new Dictionary<string, List<string>>()
       {
           { "Errors" , exception.Errors}
        };

        ProblemDetails problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = exception.Message,
            Detail = "Corrige los siguientes problemas:",
            InvalidParams = errors
        };
        return problemDetails;
    }
}
