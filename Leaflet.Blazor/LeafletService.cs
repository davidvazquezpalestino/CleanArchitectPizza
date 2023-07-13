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
        var Module = await ModuleTask.Value;
        T Result = default;

        try
        {
            if (parameters != null)
            {
                Result = await Module.InvokeAsync<T>(methodName, parameters);
            }
            else
            {
                Result = await Module.InvokeAsync<T>(methodName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"LeafletService: {ex}");
        }
        return Result;
    }

    internal async Task InvokeVoidAsync(string methodName,
        params object[] parameters)
    {
        var Module = await ModuleTask.Value;

        try
        {
            if (parameters != null)
            {
                await Module.InvokeVoidAsync(methodName, parameters);
            }
            else
            {
                await Module.InvokeVoidAsync(methodName);
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
            var Module = await ModuleTask.Value;
            await Module.DisposeAsync();
        }
    }
}
