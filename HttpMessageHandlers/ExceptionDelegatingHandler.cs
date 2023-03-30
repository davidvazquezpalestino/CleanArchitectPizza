namespace HttpMessageHandlers;
public class ExceptionDelegatingHandler : DelegatingHandler
{
    protected async override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var Response = await base.SendAsync(request, cancellationToken);

        if (!Response.IsSuccessStatusCode)
        {
            Exception Ex;
            try
            {
                JsonElement JsonResponse =
                    await Response.Content.ReadFromJsonAsync<JsonElement>();
                Ex = new ProblemDetailsException(JsonResponse);
            }
            catch
            {
                string Message = Response.StatusCode switch
                {
                    HttpStatusCode.NotFound =>
                    "El recurso solicitado no fue encontrado.",
                    _ => $"{(int)Response.StatusCode} {Response.ReasonPhrase}"
                };
                Ex = new Exception(Message);
            }
            throw Ex;
        }
        return Response;
    }
}
