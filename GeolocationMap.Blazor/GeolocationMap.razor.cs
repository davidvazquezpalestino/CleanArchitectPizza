namespace GeolocationMap.Blazor;
public partial class GeolocationMap
{
    #region Servicios
    [Inject]
    GeolocationService Service { get; set; }

    [Inject]
    IGeocoder Geocoder { get; set; }
    #endregion

    #region Parámetros
    [Parameter]
    public EventCallback<GeocodingAddress> OnSetPosition { get; set; }

    #endregion
    #region Variable
    int MarkerId;
    #endregion

    #region Map
    Map Map;
    async void OnCreatedMapAsync(Map map)
    {
        Map = map;
        await ShowLocation();
    }
    #endregion

    async Task ShowLocation()
    {
        var Position = await Service.GetPositionAsync();

        if (!Position.Equals(default(GeolocationLatLong)))
        {
            var MapPosition = new LeafletLatLong(Position.Latitude, Position.Longitude);
            await Map.SetViewMapAsync(MapPosition);
            MarkerId = await Map.AddDraggableMarkerAsync(MapPosition, "Mi ubicación",
                "");
            await UpdateAddress(Position.Latitude, Position.Longitude);
        }
        else
        {
            Console.WriteLine("GeolocationMap: No se pudo obtener la ubicación");
        }
    }

    async Task OnMarkerDragendAsync(DragendMarkerEventArgs e)
    {
        await UpdateAddress(e.Position.Latitude, e.Position.Longitude);
    }

    async Task UpdateAddress(double latitude, double longitude)
    {
        var Address = await Geocoder.GetGeocodingAddressAsync(latitude, longitude);

        string Message =
          $"{Address.DisplayAddress}<br/>Latitud: {latitude}<br/>Longitud: {longitude}";
        await Map.SetPopupMarkerContentAsync(MarkerId, Message);
        await OnSetPosition.InvokeAsync(Address);

    }

}