namespace SweetAlert.Blazor;
public sealed class SweetAlertService : IAsyncDisposable
{
    readonly Lazy<Task<IJSObjectReference>> GetJSObjectReferenceTask;

    public SweetAlertService(IJSRuntime jsRuntime)
    {
        GetJSObjectReferenceTask = new Lazy<Task<IJSObjectReference>>(() =>
        GetJSObjectReference(jsRuntime));
    }

    Task<IJSObjectReference> GetJSObjectReference(IJSRuntime jSRuntime)
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
        T Result = default;
        try
        {
            IJSObjectReference JSObjectReference =
                await GetJSObjectReferenceTask.Value;
            Result = await JSObjectReference.InvokeAsync<T>("sweetAlert",
                parameters);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"SweetAlertService: {ex.Message}");
        }
        return Result;
    }

    async ValueTask InvokeVoidAsync(object parameters)
    {
        try
        {
            IJSObjectReference JSObjectReference =
                await GetJSObjectReferenceTask.Value;
            await JSObjectReference.InvokeVoidAsync("sweetAlert",
                parameters);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"SweetAlertService: {ex.Message}");
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (GetJSObjectReferenceTask.IsValueCreated)
        {
            IJSObjectReference Module = await GetJSObjectReferenceTask.Value;
            await Module.DisposeAsync();
        }
    }
}
