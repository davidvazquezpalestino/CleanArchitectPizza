namespace HttpMessageHandlers;
public class ExceptionDelegatingHandler : DelegatingHandler
{
    protected async override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage? response = await base.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            Exception ex;
            try
            {
                JsonElement jsonResponse =
                    await response.Content.ReadFromJsonAsync<JsonElement>();
                ex = new ProblemDetailsException(jsonResponse);
            }
            catch
            {
                string message = response.StatusCode switch
                {
                    HttpStatusCode.NotFound =>
                    "El recurso solicitado no fue encontrado.",
                    _ => $"{(int)response.StatusCode} {response.ReasonPhrase}"
                };
                ex = new Exception(message);
            }
            throw ex;
        }
        return response;
    }
}
