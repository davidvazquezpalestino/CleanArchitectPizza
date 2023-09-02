namespace CustomExceptions.HttpHandlers;
internal class HttpExceptionHandlerMiddleware
{
    public static async Task WriteResponse(HttpContext context,
        bool includeDetails,
        IHttpExceptionHandlerHub hub)
    {
        IExceptionHandlerFeature exceptionDetail =
            context.Features.Get<IExceptionHandlerFeature>();

        Exception exception = exceptionDetail.Error;

        if (exception != null)
        {
            ProblemDetails problemDetails = hub.Handle(exception, includeDetails);

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = problemDetails.Status;
            Stream stream = context.Response.Body;
            await JsonSerializer.SerializeAsync(stream, problemDetails);
        }
    }
}
