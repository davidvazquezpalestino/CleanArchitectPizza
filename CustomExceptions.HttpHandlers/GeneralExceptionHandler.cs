namespace CustomExceptions.HttpHandlers;
internal class GeneralExceptionHandler : IHttpExceptionHandler<GeneralException>
{
    public ProblemDetails Handle(GeneralException exception)
    {
        ProblemDetails problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = StatusCodes.Status500InternalServerErrorType,
            Title = exception.Message,
            Detail = exception.Detail
        };

        return problemDetails;
    }
}
