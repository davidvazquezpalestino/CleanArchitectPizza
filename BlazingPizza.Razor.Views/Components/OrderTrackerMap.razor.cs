namespace BlazingPizza.Razor.Views.Components;

public partial class OrderTrackerMap : IDisposable
{
    #region Servicios
    [Inject]
    IOrderStatusNotificator Notificator { get; set; }
    #endregion

    #region Parámetros
    [Parameter]
    public byte ZoomLevel { get; set; } = 13;

    [Parameter]
    public GetOrderDto Order { get; set; }

    [Parameter]
    public EventCallback<OrderStatusNotification> OnNotificationReceived { get; set; }

    #endregion

    #region Variables
    bool IsTracking;
    int DroneId;
    int TrackingOrderId = 0;
    #endregion
    #region Map
    Map Map;
    async Task OnCreatedMapAsync(Map map)
    {
        Map = map;
        await TryStartTracking(Order);

    }
    #endregion

    #region Overrides
    protected override async Task OnParametersSetAsync()
    {
        await TryStartTracking(Order);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await TryStartTracking(Order);
        }
    }
    #endregion

    #region Métodos
    async Task TryStartTracking(GetOrderDto order)
    {
        if (Map != null)
        {
            if (!IsTracking)
            {
                await StartTracking(Order);
            }
            else
            {
                if (order.Id != TrackingOrderId)
                {
                    Notificator.UnSubscribe(TrackingOrderId);
                    await StartTracking(Order);
                }
            }
        }
    }
    async Task StartTracking(GetOrderDto order)
    {
        IsTracking = true;
        TrackingOrderId = order.Id;
        DroneId = -1;
        await Map.RemoveMarkersAsync();
        await Map.SetViewMapAsync(FromLatLong(order.DeliveryLocation));
        LatLong origin = await Notificator.SubscribeAsync(order, OnMove);
        await Map.AddMarkerAsync(FromLatLong(origin), "Pizza Store", 
            "Pizza Store", "pizzastore");
        await Map.AddMarkerAsync(FromLatLong(order.DeliveryLocation), "Usted",
            "Lugar de entrega",
            "destination");
    }

    async void OnMove(OrderStatusNotification notification)
    {
        if (DroneId == -1)
        {
            DroneId = await Map.AddMarkerAsync(FromLatLong(
                notification.CurrentPosition),
                "Drón", "ubicación actual", "drone");
        }
        else
        {
            await Map.MoveMarkerAsync(DroneId, 
                FromLatLong(notification.CurrentPosition));
        }

        await OnNotificationReceived.InvokeAsync(notification);
        if (notification.OrderStatus == OrderStatus.Delivered)
        {
            IsTracking = false;
        }
    }

    LeafletLatLong FromLatLong(LatLong latLong) =>
        new LeafletLatLong(latLong.Latitude, latLong.Longitude);
    public void Dispose()
    {
        Notificator.UnSubscribe(Order.Id);
    }
    #endregion
}
