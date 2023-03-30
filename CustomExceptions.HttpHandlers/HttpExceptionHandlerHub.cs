namespace CustomExceptions.HttpHandlers;
internal class HttpExceptionHandlerHub : IHttpExceptionHandlerHub
{
    //
    // {ValidationException, ValidationExceptionHandler}
    // {PersistenceException, PersistenceExceptionHandler}

    readonly Dictionary<Type, Type> ExceptionHandlers = new();

    public HttpExceptionHandlerHub(Assembly assembly)
    {
        Type[] Types = assembly.GetTypes();
        foreach (Type T in Types)
        {
            var Handlers = T.GetInterfaces()
                .Where(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IHttpExceptionHandler<>));
            foreach (Type Handler in Handlers)
            {
                // IHttpExceptionHandler<ValidationException>
                var ExceptionType = Handler.GetGenericArguments()[0];
                ExceptionHandlers.TryAdd(ExceptionType, T);
            }
        }
    }
    public ProblemDetails Handle(Exception ex, bool includeDetails)
    {
        ProblemDetails Problem;

        if (ExceptionHandlers.TryGetValue(ex.GetType(), out Type HandlerType))
        {
            var HandlerInstace = Activator.CreateInstance(HandlerType);

            Problem = (ProblemDetails)
                (HandlerType
                .GetMethod(nameof(IHttpExceptionHandler<Exception>.Handle))
                .Invoke(HandlerInstace, new object[] { ex }));
        }
        else
        {
            string Title = "Ha ocurrido un error al procesar la respuesta";
            string Detail;
            if (includeDetails)
            {
                Detail = ex.Message + ex.ToString();
            }
            else
            {
                Detail = "Conulte al administrador.";
            }
            Problem = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = StatusCodes.Status500InternalServerErrorType,
                Title = Title,
                Detail = Detail
            };


        }

        // Log

        return Problem;
    }
}
