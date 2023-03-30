namespace CustomExceptions;
public interface IHttpExceptionHandler<ExceptionType> where ExceptionType : Exception
{
    ProblemDetails Handle(ExceptionType exception);
}
