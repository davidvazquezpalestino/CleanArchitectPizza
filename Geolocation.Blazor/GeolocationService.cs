using Microsoft.JSInterop;

namespace Geolocation.Blazor;
// This class provides an example of how JavaScript functionality can be wrapped
// in a .NET class for easy consumption. The associated JavaScript module is
// loaded on demand when first needed.
//
// This class can be registered as scoped DI service and then injected into Blazor
// components for use.

public class GeolocationService : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> ModuleTask;

    public GeolocationService(IJSRuntime jsRuntime)
    {
        ModuleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Geolocation.Blazor/geolocation.js").AsTask());
    }

    public async ValueTask<GeolocationLatLong> GetPositionAsync()
    {
        var Module = await ModuleTask.Value;
        GeolocationLatLong Position = default;
        try
        {
            Position = await Module.InvokeAsync<GeolocationLatLong>("getPositionAsync");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetPosition: {ex.Message}");
        }
        return Position;
    }
       
    public async ValueTask DisposeAsync()
    {
        if (ModuleTask.IsValueCreated)
        {
            var module = await ModuleTask.Value;
            await module.DisposeAsync();
        }
    }
}
