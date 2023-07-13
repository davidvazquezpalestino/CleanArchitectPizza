namespace Leaflet.Blazor;
public sealed partial class Map : IAsyncDisposable
{
    #region Parámetros
    [Parameter]
    public LeafletLatLong OriginalPoint { get; set; } = new LeafletLatLong(0,0);

    [Parameter]
    public EventCallback<Map> OnCreatedMapAsync { get; set; }

    [Parameter]
    public byte ZoomLevel { get; set; } = 1;

    [Parameter]
    public EventCallback<DragendMarkerEventArgs> OnMarkerDragendAsync { get; set; }

    #endregion

    #region Inyección de servicios
    [Inject]
    LeafletService LeafletService { get; set; }
    #endregion

    #region Variables
    string MapId = $"map-{Guid.NewGuid()}";
    bool IsMapReady = false;
    DotNetObjectReference<Map> MarkerHelper;
    #endregion

    #region Overrides
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try
            {
                await LeafletService.InvokeVoidAsync("createMap", MapId,
                    OriginalPoint, ZoomLevel);
                await OnCreatedMapAsync.InvokeAsync(this);
                IsMapReady = true;
                StateHasChanged();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    #endregion

    #region Método públicos

    public async Task<int> AddMarkerAsync(LeafletLatLong point, string title,
        string description, string iconUrl = null)
    {
        return await LeafletService.InvokeAsync<int>("addMarker", MapId,
            point, title, description, BuildIconUrl(iconUrl));
    }

    public async Task<int> AddDraggableMarkerAsync(LeafletLatLong point, string title,
    string popupDescription, string iconUrl = null)
    {
        await SetDotNetObjectReference();

        return await LeafletService.InvokeAsync<int>("addDraggableMarker", MapId,
            point, title, popupDescription, BuildIconUrl(iconUrl));
    }

    async ValueTask SetDotNetObjectReference()
    {
        if (MarkerHelper == null)
        {
            MarkerHelper = DotNetObjectReference.Create(this);
            await LeafletService.InvokeVoidAsync("setMarkerHelper", MapId,
                MarkerHelper, nameof(DragendHandler));
        }
    }

    string BuildIconUrl(string iconUrl) =>
        iconUrl == null ? iconUrl :
        iconUrl.Contains('.') ? iconUrl :
        $"{ContentHelper.ContentPath}/css/images/{iconUrl}.png";


    public async ValueTask RemoveMarkersAsync() =>
        await LeafletService.InvokeVoidAsync("removeMarkers", MapId);

    public async ValueTask DrawCircleAsync(LeafletLatLong center, string lineColor,
        string fillColor, double fillOpacity, double radius) =>
        await LeafletService.InvokeVoidAsync("drawCircle", MapId,
            center, lineColor, fillColor, fillOpacity, radius);

    public async Task SetViewMapAsync(LeafletLatLong point) =>
        await LeafletService.InvokeVoidAsync("setView", MapId, point);

    public async ValueTask MoveMarkerAsync(int markerId, LeafletLatLong newPosition)
    {
        await LeafletService.InvokeVoidAsync("moveMarker", MapId, markerId,
            newPosition);
    }

    public async ValueTask SetPopupMarkerContentAsync(int markerId, string content) =>
        await LeafletService.InvokeVoidAsync("setPopupMarkerContent", 
            MapId, markerId, content);

    #endregion

    #region JavaScript Events

    [JSInvokable]
    public async Task DragendHandler(DragendMarkerEventArgs e)
    {
       await OnMarkerDragendAsync.InvokeAsync(e);
    }

    #endregion

    #region IAsyncDisposable
    public async ValueTask DisposeAsync()
    {
        await LeafletService.InvokeVoidAsync("deleteMap", MapId);
        MarkerHelper?.Dispose();
    }
    #endregion
}
