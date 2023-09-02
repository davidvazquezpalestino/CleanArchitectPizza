namespace CustomExceptions.HttpHandlers;
internal class HttpExceptionHandlerHub : IHttpExceptionHandlerHub
{
    readonly Dictionary<Type, Type> ExceptionHandlers = new();

    public HttpExceptionHandlerHub(Assembly assembly)
    {
        Type[] types = assembly.GetTypes();
        foreach (Type T in types)
        {
            var handlers = T.GetInterfaces()
                .Where(type =>
                type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(IHttpExceptionHandler<>));
            foreach (Type handler in handlers)
            {
                Type exceptionType = handler.GetGenericArguments()[0];
                ExceptionHandlers.TryAdd(exceptionType, T);
            }
        }
    }
    public ProblemDetails Handle(Exception ex, bool includeDetails)
    {
        ProblemDetails problem;

        if (ExceptionHandlers.TryGetValue(ex.GetType(), out Type handlerType))
        {
            var handlerInstace = Activator.CreateInstance(handlerType);

            problem = (ProblemDetails)
                (handlerType.GetMethod(nameof(IHttpExceptionHandler<Exception>.Handle))
                            .Invoke(handlerInstace, new object[] { ex }));
        }
        else
        {
            string title = "Ha ocurrido un error al procesar la respuesta";
            string detail;
            if (includeDetails)
            {
                detail = ex.Message + ex;
            }
            else
            {
                detail = "Conulte al administrador.";
            }
            problem = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = StatusCodes.Status500InternalServerErrorType,
                Title = title,
                Detail = detail
            };
        }

        return problem;
    }
}
