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
        GeolocationLatLong position = await Service.GetPositionAsync();

        if (!position.Equals(default(GeolocationLatLong)))
        {
            LeafletLatLong mapPosition = new LeafletLatLong(position.Latitude, position.Longitude);
            await Map.SetViewMapAsync(mapPosition);
            MarkerId = await Map.AddDraggableMarkerAsync(mapPosition, "Mi ubicación",
                "");
            await UpdateAddress(position.Latitude, position.Longitude);
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
        GeocodingAddress address = await Geocoder.GetGeocodingAddressAsync(latitude, longitude);

        string message =
          $"{address.DisplayAddress}<br/>Latitud: {latitude}<br/>Longitud: {longitude}";
        await Map.SetPopupMarkerContentAsync(MarkerId, message);
        await OnSetPosition.InvokeAsync(address);

    }

}