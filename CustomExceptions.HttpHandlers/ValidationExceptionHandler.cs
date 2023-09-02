namespace CustomExceptions.HttpHandlers;
internal class ValidationExceptionHandler : IHttpExceptionHandler<ValidationException>
{
    public ProblemDetails Handle(ValidationException exception)
    {
        var errors = new Dictionary<string, List<string>>();
        foreach (IValidationError error in exception.Errors)
        {
            if (errors.ContainsKey(error.PropertyName))
            {
                errors[error.PropertyName].Add(error.Message);
            }
            else
            {
                errors.Add(error.PropertyName, new List<string> { error.Message });
            }
        }

        ProblemDetails problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Error de validación",
            Detail = "Corrige los siguientes problemas:",
            InvalidParams = errors
        };

        return problemDetails;
    }
}
