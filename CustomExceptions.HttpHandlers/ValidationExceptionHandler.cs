namespace CustomExceptions.HttpHandlers;
internal class ValidationExceptionHandler : IHttpExceptionHandler<ValidationException>
{
    public ProblemDetails Handle(ValidationException exception)
    {
        var Errors = new Dictionary<string, List<string>>();
        foreach (var Error in exception.Errors)
        {
            if (Errors.ContainsKey(Error.PropertyName))
            {
                Errors[Error.PropertyName].Add(Error.Message);
            }
            else
            {
                Errors.Add(Error.PropertyName, new List<string> { Error.Message });
            }
        }

        ProblemDetails ProblemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Error de validación",
            Detail = "Corrige los siguientes problemas:",
            InvalidParams = Errors
        };

        return ProblemDetails;
    }
}
