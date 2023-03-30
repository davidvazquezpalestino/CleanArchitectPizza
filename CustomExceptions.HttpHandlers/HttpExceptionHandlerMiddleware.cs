namespace CustomExceptions.HttpHandlers;
internal class HttpExceptionHandlerMiddleware
{
    public static async Task WriteResponse(HttpContext context,
        bool includeDetails,
        IHttpExceptionHandlerHub hub)
    {
        IExceptionHandlerFeature ExceptionDetail =
            context.Features.Get<IExceptionHandlerFeature>();

        Exception Exception = ExceptionDetail.Error;

        if (Exception != null)
        {
            var ProblemDetails = hub.Handle(Exception, includeDetails);

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = ProblemDetails.Status;
            var Stream = context.Response.Body;
            await JsonSerializer.SerializeAsync(Stream, ProblemDetails);
        }
    }
}
