namespace CustomExceptions;
public interface IHttpExceptionHandler<TExceptionType> where TExceptionType : Exception
{
    ProblemDetails Handle(TExceptionType exception);
}
