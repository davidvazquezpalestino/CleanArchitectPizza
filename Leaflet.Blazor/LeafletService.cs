namespace Leaflet.Blazor;
public sealed class LeafletService : IAsyncDisposable
{
    readonly Lazy<Task<IJSObjectReference>> ModuleTask;

    public LeafletService(IJSRuntime jsRuntime)
    {
        // TODO: Cargar el archivo Leaftlet.css

        ModuleTask = new Lazy<Task<IJSObjectReference>>(() =>
        jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", $"./{ContentHelper.ContentPath}/js/leafletService.js")
        .AsTask());
    }

    internal async Task<T> InvokeAsync<T>(string methodName,
        params object[] parameters)
    {
        IJSObjectReference module = await ModuleTask.Value;
        T result = default;

        try
        {
            if (parameters != null)
            {
                result = await module.InvokeAsync<T>(methodName, parameters);
            }
            else
            {
                result = await module.InvokeAsync<T>(methodName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"LeafletService: {ex}");
        }
        return result;
    }

    internal async Task InvokeVoidAsync(string methodName,
        params object[] parameters)
    {
        IJSObjectReference module = await ModuleTask.Value;

        try
        {
            if (parameters != null)
            {
                await module.InvokeVoidAsync(methodName, parameters);
            }
            else
            {
                await module.InvokeVoidAsync(methodName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"LeafletService: {ex}");
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (ModuleTask.IsValueCreated)
        {
            IJSObjectReference module = await ModuleTask.Value;
            await module.DisposeAsync();
        }
    }
}
