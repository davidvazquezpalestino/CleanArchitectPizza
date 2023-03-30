namespace CustomExceptions;
public interface IHttpExceptionHandlerHub
{
    ProblemDetails Handle(Exception ex, bool includeDetails);
}
