namespace SweetAlert.Blazor;
public sealed class SweetAlertService : IAsyncDisposable
{
    readonly Lazy<Task<IJSObjectReference>> GetJsObjectReferenceTask;

    public SweetAlertService(IJSRuntime jsRuntime)
    {
        GetJsObjectReferenceTask = new Lazy<Task<IJSObjectReference>>(() =>
        GetJsObjectReference(jsRuntime));
    }

    Task<IJSObjectReference> GetJsObjectReference(IJSRuntime jSRuntime)
    {
        return jSRuntime.InvokeAsync<IJSObjectReference>(
            "import",
            "./_content/SweetAlert.Blazor/sweetalertModule.js")
            .AsTask();
    }

    public async ValueTask<bool> ConfirmAsync(ConfirmArgs args) =>
        await InvokeAsync<bool>(args);

    public async ValueTask<T> FireAsync<T>(object parameters) =>
        await InvokeAsync<T>(parameters);

    public async ValueTask FireVoidAsync(object parameters) =>
        await InvokeVoidAsync(parameters);

    async ValueTask<T> InvokeAsync<T>(object parameters)
    {
        T result = default;
        try
        {
            IJSObjectReference jsObjectReference =
                await GetJsObjectReferenceTask.Value;
            result = await jsObjectReference.InvokeAsync<T>("sweetAlert",
                parameters);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"SweetAlertService: {ex.Message}");
        }
        return result;
    }

    async ValueTask InvokeVoidAsync(object parameters)
    {
        try
        {
            IJSObjectReference jsObjectReference =
                await GetJsObjectReferenceTask.Value;
            await jsObjectReference.InvokeVoidAsync("sweetAlert",
                parameters);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"SweetAlertService: {ex.Message}");
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (GetJsObjectReferenceTask.IsValueCreated)
        {
            IJSObjectReference module = await GetJsObjectReferenceTask.Value;
            await module.DisposeAsync();
        }
    }
}
